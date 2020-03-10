using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serv.IniFile
{
    class ClassIniFiles
    {
        private String File = "";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileInt(String Section, String Key, int Value, String FilePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(String Section, String Key, String Value, String FilePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(String Section, String Key, int Default, String FilePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(String Section, String Key, String Default, StringBuilder retVal, int Size, String FilePath);

        public ClassIniFiles(String IniFile)
        {
            this.File = IniFile;
        }

        public String ReadString(String Section, String Key, String Default)
        {
            StringBuilder StrBu = new StringBuilder(10000);
            GetPrivateProfileString(Section, Key, Default, StrBu, 10000, File);
            return StrBu.ToString();
        }

        public int ReadInt(String Section, String Key, int Default)
        {
            return GetPrivateProfileInt(Section, Key, Default, File);
        }

        public void WriteString(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, File);
        }

        public void WriteInt(String Section, String Key, int Value)
        {
            WritePrivateProfileInt(Section, Key, Value, File);
        }
    }
}
