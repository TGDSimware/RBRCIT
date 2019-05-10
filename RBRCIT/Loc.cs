using System;
using System.Collections.Generic;

namespace RBRCIT
{
    internal static class Loc
    {
        private static Dictionary<int, string> _strings;

        public static string String(int i)
        {
            try
            {
                return _strings[i];
            }
            catch
            {
                return "<language file error>";
            }
        }

        public static  void Load(string languageFilePath)
        {

            INIFile ini = new INIFile(languageFilePath);

            string s;
            int i = 0;
            _strings = new Dictionary<int, string>();
            do
            {
                try
                {
                    s = ini.GetParameterValue(i.ToString(), "strings");
                    if (s != null) _strings.Add(i, s.Replace("\\n", "\n"));
                    else
                        break;
                }
                catch
                {
                    break;
                }
                i++;
            }
            while (true);
        }
    }
}
