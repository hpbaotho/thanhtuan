using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using PCARegHelper;

namespace WindowsFormsApplication4.lic
{
    class Lc
    {
        public enum Version
        {
            Demo = 0x08,
            Pro = 0x88,
            Enterprise = 0x888
        }
        public static bool Parse(string act,string reg)
        {
            Version version = Version.Demo;
            if (reg.Length != 29)
            {
                Alert.Show("Mã đăng kí không đúng !", Color.Red);
                version = Version.Demo;
                return false;

            }
            
            string x = Backward(reg.ToUpper());
            long num3 = 0;
            long num4 = 0;
            long num2 = 0;
            
            char[] trimChars = new char[] { '0' };
            string str = x.Substring(0, 5);
            if (!isMACValid(str))
            {
                Alert.Show("Mã đăng kí không đúng !", Color.Red);
                version = Version.Demo;
                return false;
            }
            string aaa = x.Substring(5, 6);
            string a = Sc.FillCharacter(SystemInfo.RunQuery("Processor", "ProcessorId"), 3);
            string b = Sc.FillCharacter(SystemInfo.RunQuery("BaseBoard", "Product"), 3);
            if (aaa != a + b)
            {
                Alert.Show("Mã đăng kí không đúng !", Color.Red);
                version = Version.Demo;
                return false;
            }
            Radix.Decode(x.Substring(11, 6).TrimStart(trimChars), 0x24L, ref num3);
            long gUIDValue = GetGUIDValue(act.Replace("-", "").Replace(" ", "").ToUpper());
            if (num3 != gUIDValue)
            {
                Alert.Show("Mã đăng kí không đúng !", Color.Red);
                version = Version.Demo;
                return false;
            }
            Radix.Decode(x.Substring(17, 6).TrimStart(trimChars), 0x24L, ref num4);
            StaticClass.m_Version = (int) num4;
            if ((StaticClass.m_Version & 0x88) == 0x88)
            {
                version = Version.Pro;
            }else if((StaticClass.m_Version & 0x888) == 0x888)
            {
                version = Version.Enterprise;
            }
            else
            {
                version = Version.Demo;
            }
            Radix.Decode(x.Substring(23, 6).TrimStart(trimChars), 0x24L, ref num2);
            DateTime time = DateTime.FromOADate((double)num2);
            if((DateTime.Compare(DateTime.Today, time) > 0))
            {
                Alert.Show("License hết hạn !", Color.Red);
                version = Version.Demo;
                return false;
            }
            StaticClass.version = version;
            return true;
        }
        private static string Backward(string s)
        {
            string str3 = "";
            string str2 = s.Substring(0x11, 6);
            int num = 0;
            int num5 = s.Length - 1;
            for (int i = 0; i <= num5; i++)
            {
                int index = "LAPQMZ01NXOWKS29DJEUCB3I8RYFH475V6TG".IndexOf(s[i]);
                if ((i < 0x11) | (i > 0x16))
                {
                    int num4 = "LAPQMZ01NXOWKS29DJEUCB3I8RYFH475V6TG".IndexOf(str2[num]);
                    index -= num4;
                    if (index < 0)
                    {
                        index += 0x24;
                    }
                    num++;
                    if (num > (str2.Length - 1))
                    {
                        num = 0;
                    }
                }
                str3 = str3 + StringType.FromChar("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[index]);
            }
            return str3;
        }

        private static bool isMACValid(string base36MAC)
        {
            if (StringType.StrCmp(base36MAC, Sc.showMac(), false) == 0)
            {
                return true;
            }
            return false;
        }

        private static int GetGUIDValue(string value)
        {
            int num2 = 0;
            int num4 = value.Length - 1;
            for (int i = 0; i <= num4; i++)
            {

                num2 += Microsoft.VisualBasic.Strings.Asc(value[i]);
            }
            return num2;
        }

        public static void Check()
        {
            string actPath = System.Windows.Forms.Application.StartupPath + @"\actc.reg";
            string regPath = System.Windows.Forms.Application.StartupPath + @"\regc.reg";
            string act = FileReadWrite.ReadFile(actPath);
            string reg = FileReadWrite.ReadFile(regPath);
            if ( act == String.Empty || reg == String.Empty)
            {
                StaticClass.version = Version.Demo;
            }
            else
            {
                Parse(act, reg);
            }
        }

    }
    

}
