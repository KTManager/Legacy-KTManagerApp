using KillTeam.Services;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillTeam.RulesTool
{
    class KTUserContextDesignTimeFactory : IDesignTimeDbContextFactory<KTUserContext>
    {
        KTUserContext IDesignTimeDbContextFactory<KTUserContext>.CreateDbContext(string[] _args)
        {
            return new KTUserContext(KTContext.DBPath);
        }
    }
}
