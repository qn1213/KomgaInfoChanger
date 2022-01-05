using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace KomgaInfoChanger
{
    internal class ArchiveLoader
    {
        private static string[] Translate = { "number", "artist", "group", "type", "series", "character", "tag", "language" };

        // path : zip파일들 경로 배열
        public static Dictionary<string, SMetaDataAttribute> GetInfoFromFile(string[] paths)
        {         
            Dictionary<string, SMetaDataAttribute> info = new Dictionary<string, SMetaDataAttribute>();
            foreach(string path in paths)
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            if (entry.FullName.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase))
                            {
                                using (StreamReader sr = new StreamReader(entry.Open()))
                                {
                                    string reader = sr.ReadToEnd().Replace("\n\n", "\n");
                                    string[] attributes = reader.Split(Environment.NewLine.ToCharArray());
                                                                        
                                    SMetaDataAttribute fileAtri = new SMetaDataAttribute();
                                    fileAtri.number = GetDictonaryString(attributes[0]);
                                    fileAtri.artist = GetDic_List(attributes[2]);
                                    fileAtri.group = GetDic_List(attributes[3]);
                                    fileAtri.type = GetDictonaryString(attributes[4]);
                                    fileAtri.series = GetDic_List(attributes[5]);
                                    fileAtri.character = GetDic_List(attributes[6]);
                                    fileAtri.tag = GetDic_List(attributes[7]);
                                    fileAtri.language = GetDictonaryString(attributes[8]);

                                    string titles = Path.GetFileNameWithoutExtension(fs.Name);
                                    info.Add(titles, fileAtri);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return info;
        }

        private static string GetString(string str)
        {
            string[] data = str.Split(new string[] { ": " }, StringSplitOptions.None);
            return data[1];
        }

        private static string[] GetArrayString(string str)
        {
            string[] data1 = str.Split(new string[] {": "}, StringSplitOptions.None);
            string[] data2 = data1[1].Split(new string[] { ", "}, StringSplitOptions.None);

            return data2;
        }

        private static Dictionary<string, string> GetDictonaryString(string str)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string[] data1 = str.Split(new string[] { ": " }, StringSplitOptions.None);           
            string[] data2 = data1[1].Split(new string[] { ", " }, StringSplitOptions.None);

            foreach(string value in data2)
            {
                switch (data1[0])
                {
                    case "갤러리 넘버":
                        data.Add(Translate[0], value);
                        break;                   
                    case "타입":
                        data.Add(Translate[3], value);
                        break;                    
                    case "언어":
                        data.Add(Translate[7], value);
                        break;
                    default:
                        data.Add(data1[0], value);
                        break;
                }
            }

            return data;
        }

        private static Dictionary<string, List<string>> GetDic_List(string str)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            string[] data1 = str.Split(new string[] { ": " }, StringSplitOptions.None);
            string[] data2 = data1[1].Split(new string[] { ", " }, StringSplitOptions.None);

            List<string> list = new List<string>();
            foreach(string value in data2)
            {
                list.Add(value);
            }

            switch(data1[0])
            {
                case "작가":
                    data.Add(Translate[1], list);
                    break;
                case "그룹":
                    data.Add(Translate[2], list);
                    break;
                case "시리즈":
                    data.Add(Translate[4], list);
                    break;
                case "캐릭터":
                    data.Add(Translate[5], list);
                    break;
                default:
                    data.Add(data1[0], list);
                    break;
            }
            

            return data;
        }
    }
}
