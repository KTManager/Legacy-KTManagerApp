namespace KillTeam.ViewModels
{
    public class LanguageViewModel
    {
        public string Name { get; set; }

        public string ShortCode { get; set; }

        public LanguageViewModel(string name, string shortCode)
        {
            Name = name;
            ShortCode = shortCode;
        }
    }
}
