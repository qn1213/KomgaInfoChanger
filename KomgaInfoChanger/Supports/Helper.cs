using System;
using System.Text;
using System.Net.Http.Headers;
using System.IO;

namespace KomgaInfoChanger
{
    internal class Helper
    {
        public static void SetServerInfo()
        {
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\acc.txt");
            string readData = null;
            readData = sr.ReadToEnd().Replace("\r\n", "\n");
            string[] ret = readData.Split(Environment.NewLine.ToCharArray());

            env.info.serverAddr = ret[0];
            env.info.serverID = ret[1];
            env.info.serverPW = ret[2];
        }

        public static string EncodeBase64(string _value)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(_value);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        public static string DecodeBase64(string _value)
        {
            byte[] baseByte = Convert.FromBase64String(_value);
            string ret = Encoding.Unicode.GetString(baseByte);
            return ret;
        }

        public static string GetBasicAuthBase64(string _id, string _pw)
        {
            var byteAry = Encoding.ASCII.GetBytes($"{_id}:{_pw}");
            var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteAry));

            return authHeader.ToString();
        }

        public static string GetDate()
        {
            DateTime nowDate = DateTime.Now;
            return nowDate.ToString("yyyy-MM-dd");
        }

        public static string GetTime()
        {
            DateTime nowTime = DateTime.Now;
            return nowTime.ToString("HH:mm:ss");
        }

        public static string GetDateTime()
        {
            return GetDate() + ":" + GetTime();
        }

        public static int GetInt(string value)
        {
            if (Int32.TryParse(value, out int val))
                return val;
            else return -1;
        }

        public class Pair<T, U>
        {
            public Pair() { }

            public Pair(T first, U second)
            {
                this.First = first;
                this.Second = second;
            }

            public T First { get; set; }
            public U Second { get; set; }
        }
    }


}
