using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local.Models.utilities
{
    public static class PathHelper
    {
        public static string UserFolderPath
        {
            get
            {
                // Get base directory (e.g., ...\bin\Debug\)
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                // Go UP 2 levels to reach the project root
                string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\"));

                // Then into a *single* bin folder and then users
                return Path.Combine(projectRoot, "users");
            }
        }
    }


}
