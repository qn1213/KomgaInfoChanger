using System;
using System.IO;
using System.IO.Compression;

namespace KomgaInfoChanger
{
    internal class ArchiveLoader
    {
        public SMetaDataAttribute GetInfoFromFile(string path)
        {
            SMetaDataAttribute fileAtri = new SMetaDataAttribute();

            using (FileStream fs = File.OpenRead(path))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if(entry.FullName.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase))
                        {
                            using (StreamReader sr = new StreamReader(entry.Open()))
                            {
                                string name = sr.ReadToEnd().Replace("\n\n","\n");
                                string[] test = name.Split(Environment.NewLine.ToCharArray());

                                /*
                                    for(int i = 0; i < test.Length; i++)
                                    {
                                        // test[i]\r\n UI 호출해서 뿌려주면됨
                                    }
                                */
                                
                                fileAtri.number = GetString(test[0]);
                                fileAtri.title = GetString(test[1]);
                                fileAtri.authors = GetArrayString(test[2]);
                                fileAtri.tags = GetArrayString(test[3]);

                                //Console.WriteLine(name);
                                return fileAtri;
                            }
                        }
                    }
                }
            } 
            return fileAtri;
        }

        private string GetString(string str)
        {
            string[] data = str.Split(new string[] { ": " }, StringSplitOptions.None);
            return data[1];
        }

        private string[] GetArrayString(string str)
        {
            string[] data1 = str.Split(new string[] {": "}, StringSplitOptions.None);
            string[] data2 = data1[1].Split(new string[] { ", "}, StringSplitOptions.None);

            return data2;
        }
    }
}
