using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomgaInfoChanger
{
    using BODYDATAS = List<Dictionary<string, Dictionary<string, string>>>;
    using BODYDATA = Dictionary<string, Dictionary<string, string>>;

    internal class BodyDataMaker
    {
        public static void MakeMultipleBody( ref string outPut)
        {

        }

        public static void MakeBody( ref string outPut)
        {

        }
        /*
        Dictionary<string, string> testDic1 = new Dictionary<string, string>();
            testDic1.Add("role", "Lang");
            testDic1.Add("name", "Korean");

            
            Dictionary<string, string> testDic2 = new Dictionary<string, string>();
            testDic2.Add("role", "number");
            testDic2.Add("name", "123456");


            Dictionary<string, string> testDic3 = new Dictionary<string, string>();
            testDic3.Add("role", "type");
            testDic3.Add("name", "dougin");




            List<Dictionary<string, string>> lists = new List<Dictionary<string, string>>();
            Dictionary<string, string> points = new Dictionary<string, string>
            {
                { "role", "r1" },
                { "name", "n1" }

            };
            Dictionary<string, string> points2 = new Dictionary<string, string>
            {
                { "role", "r2" },
                { "name", "n2" }

            };
            lists.Add(testDic1);
            lists.Add(testDic2);
            lists.Add(testDic3);


            lists.Add(points);
            lists.Add(points2);

            //string json = JsonConvert.SerializeObject(lists, Formatting.Indented);

            using (StreamWriter file = File.CreateText(@"C:\Users\psj75\Documents\새 폴더\test.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, lists);
            }
         */

    }
}
