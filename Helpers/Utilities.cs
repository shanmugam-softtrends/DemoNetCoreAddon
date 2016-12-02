using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFTAddonDemo.Helpers
{
    public static class Utilities
    {
        public static string GetPGConnectionString(string pDatabaseUrl)
        {
            if (!string.IsNullOrEmpty(pDatabaseUrl))
            {
                string conStrParts = pDatabaseUrl.Replace("//", "");
                string[] strConn = conStrParts.Split(new char[] { '/', ':', '@', '?' });
                strConn = strConn.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                return string.Format("Host={0};Port={1};Database={2};User ID={3};Password={4};sslmode=Require;Trust Server Certificate=true;", strConn[3], strConn[4], strConn[5], strConn[1], strConn[2]);
            }

            return string.Empty;
        }

        public static string GetEnvVarVal(string pKey)
        {
            return Environment.GetEnvironmentVariable(pKey);
        }
    }
}
