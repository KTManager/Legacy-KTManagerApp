using System;
using System.Collections.Generic;
using System.Linq;
using Superpower;
using Superpower.Display;
using Superpower.Model;
using Superpower.Parsers;

namespace KillTeam.Services
{
    enum OperationToken
    {
        None,

        [Token(Category = "wargear", Example = "ABC1")]
        Wargear,

        [Token(Category = "operator", Example = ":")]
        Colon,

        [Token(Category = "parens", Example = "(")]
        LeftParen,

        [Token(Category = "parens", Example = ")")]
        RightParen,

        [Token(Category = "operator", Example = "!")]
        Optional,

        [Token(Category = "operator", Example = "|")]
        Or,

        [Token(Category = "operator", Example = "&")]
        And,

    }

    class Tokenizer : Tokenizer<OperationToken>
    {
        protected OperationToken? GetToken(char c)
        {
            switch (c)
            {
                case ':':
                    return OperationToken.Colon;
                case '(':
                    return OperationToken.LeftParen;
                case ')':
                    return OperationToken.RightParen;
                case '!':
                    return OperationToken.Optional;
                case '&':
                    return OperationToken.And;
                case '|':
                    return OperationToken.Or;
                default:
                    return null;
            }
        }

        protected override IEnumerable<Result<OperationToken>> Tokenize(TextSpan input)
        {
            var next = SkipWhiteSpace(input);
            if (!next.HasValue)
            {
                yield break;
            }

            do
            {
                var token = GetToken(next.Value);
                if (char.IsLetter(next.Value))
                {
                    var keywordStart = next.Location;
                    do
                    {
                        next = next.Remainder.ConsumeChar();
                    } while (next.HasValue && char.IsLetterOrDigit(next.Value));

                    yield return Result.Value(OperationToken.Wargear, keywordStart, next.Location);
                }
                else if (token != null)
                {
                    yield return Result.Value(token.Value, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else
                {
                    yield return Result.Empty<OperationToken>(next.Location, $"unrecognized `{next.Value}`");
                    next = next.Remainder.ConsumeChar();
                }

                next = SkipWhiteSpace(next.Location);
            } while (next.HasValue);
        }
    }

    class Operation
    {
        public WargearExpression Wargear { get; set; }
        public WargearExpression Replacement { get; set; }

        public string ToString(Func<string, string> getName)
        {
            if (Replacement == null)
            {
                return $"This model may take {Wargear.ToString(getName)}";
            }
            else
            {
                return $"This model may replace its {Wargear.ToString(getName)} with {Replacement.ToString(getName)}";
            }
        }
        public override string ToString()
        {
            return this.ToString((n) => n);
        }

    }

    abstract class WargearExpression {
        abstract public string ToString(Func<string, string> getName);
        public override string ToString()
        {
            return this.ToString((n) => n);
        }
    }

    class AndOrExpression : WargearExpression
    {
        public string Operator { get; set; }

        public WargearExpression[] Options { get; set; }

        public override string ToString(Func<string, string> getName)
        {
            return $"({string.Join($" {Operator} ", Options.Select(o => o.ToString(getName)))})";
        }
    }

    class OptionalExpression : WargearExpression
    {

        public WargearExpression Option { get; set; }

        public override string ToString(Func<string, string> getName)
        {
            return $"optional {Option.ToString(getName)}";
        }

    }

    class SingleWargearExpression : WargearExpression
    {
        public string Weapon { get; set; }

        public override string ToString(Func<string, string> getName)
        {
            return getName(Weapon);
        }
    }


    static class OperationParser
    {

        public static TokenListParser<OperationToken, WargearExpression> SingleWargear =
            Token.EqualTo(OperationToken.Wargear)
                .Select(w => (WargearExpression)new SingleWargearExpression { Weapon = w.ToStringValue() });

        public static TokenListParser<OperationToken, WargearExpression> OptionalWargear =
            from optional in Token.EqualTo(OperationToken.Optional)
            from option in Parse.Ref(() => WargearExpression)
            select (WargearExpression)new OptionalExpression { Option = option };

        public static TokenListParser<OperationToken, WargearExpression> OrListWargear =
            from first in Parse.Ref(() => ListElement)
            from op in Token.EqualTo(OperationToken.Or)
            from rest in Parse.Ref(() => ListElement.AtLeastOnceDelimitedBy(Token.EqualTo(OperationToken.Or)))
            select (WargearExpression)new AndOrExpression {
                Operator = "or",
                Options = new[] { first }.Concat(rest).ToArray(),
            };

        public static TokenListParser<OperationToken, WargearExpression> AndListWargear =
            from first in Parse.Ref(() => ListElement)
            from op in Token.EqualTo(OperationToken.And)
            from rest in Parse.Ref(() => ListElement.AtLeastOnceDelimitedBy(Token.EqualTo(OperationToken.And)))
            select (WargearExpression)new AndOrExpression {
                Operator = "and",
                Options = new[] { first }.Concat(rest).ToArray(),
            };

        public static TokenListParser<OperationToken, WargearExpression> ParensWargear =
            from lparen in Token.EqualTo(OperationToken.LeftParen)
            from expr in Parse.Ref(() => WargearExpression)
            from rparen in Token.EqualTo(OperationToken.RightParen)
            select expr;


        public static TokenListParser<OperationToken, WargearExpression> ListElement =
            Parse.Ref(() => ParensWargear.Or(OptionalWargear).Or(SingleWargear));


        // This is the main expression parser
        public static TokenListParser<OperationToken, WargearExpression> WargearExpression =
            Parse.Ref(() => AndListWargear.Try().Or(OrListWargear.Try()).Or(ListElement));

        public static TokenListParser<OperationToken, Operation> Operation = 
            (
                from wargear in WargearExpression
                from replacement in (
                    from colon in Token.EqualTo(OperationToken.Colon)
                    from rep in WargearExpression
                    select rep
                ).OptionalOrDefault().AtEnd()
                select new Operation { Wargear = wargear, Replacement = replacement }
            );

    }
}
