using System;
using System.Text;

namespace KomgaInfoChanger
{
    internal class Helper
    {
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
            string id = EncodeBase64(_id);
            string pw = EncodeBase64(_pw);
            string seperate = EncodeBase64(":");

            return id + seperate + pw;
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
    }


}
