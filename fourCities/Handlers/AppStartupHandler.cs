using fourCities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace fourCities.Handlers
{
    internal class AppStartupHandler
    {
        public static void StartupChecks()
        {
            CheckConfigFile();
        }

        private static void CheckConfigFile()
        {
            if (!TomlModel.CheckIfTOMLFileExist())
            {
                TomlModel.MakeTOMLFile();
            }
        }
    }
}
