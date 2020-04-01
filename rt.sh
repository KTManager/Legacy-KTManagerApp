#!/bin/bash
set -exo pipefail

# run from the MobileApp directory
cd "${BASH_SOURCE%/*}/" || exit

# build the rules in the KTRules directory
../KTRules/build.py clean release

# import the rules to the db then show the cost of the arguments
dotnet run --project KillTeam.RulesTool -- import -r ../KTRules/out
dotnet run --project KillTeam.RulesTool -- cost "$@"