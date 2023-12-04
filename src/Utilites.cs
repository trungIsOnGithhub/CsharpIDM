using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    public static class Utilities
    {
        public static string SelectAppropriateFileSizeFormat(long bytes)
        {
            if (bytes > 1048576 && bytes < 1073741824)
            {
                double megabytes = (bytes / 1048576f);
                double rounded = Math.Round(megabytes, 2);
                return (rounded + "MB");
            }
            if (bytes > 1073741824)
            {
                double gigabytes = (bytes / 1073741824f);
                double rounded = Math.Round(gigabytes, 2);
                return (rounded + "GB");
            }
            else
            {
                double kilobytes = (bytes / 1024f);
                double rounded = Math.Round(kilobytes, 2);
                return (rounded + "KB");
            }
        }

        public static bool IsValidPath(string path)
        {
            string[] fileOrDirNames = path.Split(Path.DirectorySeparatorChar);

            Regex fileNamePattern = new Regex(@"^[\w\s_.:]*$");
            
            foreach (string fileOrDirName in fileOrDirNames)
            {
                Match matchResult = fileNamePattern.Match(fileOrDirName);
                
                if (matchResult == Match.Empty)
                {
                return false;
                }
            }
            
            return true;
        }

        public static string GetSystemInfo()
        {
            StringBuilder systemInfo = new StringBuilder(string.Empty);
    
            systemInfo.AppendFormat("OS Type:\t\t{0}\n", Environment.OSVersion);
            systemInfo.AppendFormat("Version:\t\t{0}\n", Environment.Version);
            systemInfo.AppendFormat("Architecture:\t\t{0}\n", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            systemInfo.AppendFormat("SystemDirectory:\t\t{0}\n", Environment.SystemDirectory);
            systemInfo.AppendFormat("UserName:\t\t{0}\n", Environment.UserName);

            return systemInfo.ToString();
        }

        public static char filterKey(char character) {
            if (character == ' ' || character == '?')
            {
                return character;
            }

            int keyInASCII = (int)character;

            if (keyInASCII <= (int)'z' && keyInASCII >= (int)'a')
            {
                return character;
            }

            if (keyInASCII <= (int)'Z' && keyInASCII >= (int)'A')
            {
                return character;
            }

            return '\0';
        }
    }

    class KeyVault
    {
        public static string getKeyFor(string baseURI)
        {
            return "1";
        }
    }
}