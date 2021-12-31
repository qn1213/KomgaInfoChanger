using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace KomgaInfoChanger
{
    // Multiple
    // BookID
    //  {
    //      "authors" :
    //          [
    //              {
    //                  "role" : "Lang",
    //                  "name" : "Korean"
    //              },
    //              {
    //                  "role" : "tags",
    //                  "name" : "test1",
    //                  "name" : "test2"
    //              }
    //         ]
    //  }

    // Single
    // Server Address QueryParam => /api/v1/books/{bookID}/metadata
    //      "authors" :
    //          [
    //              {
    //                  "role" : "Lang",
    //                  "name" : "Korean"
    //              },
    //              {
    //                  "role" : "tags",
    //                  "name" : "test1",
    //                  "name" : "test2"
    //              }
    //         ]

    using BODYDATA = Dictionary<string, Dictionary<string, List<string>>>;
    using BODYDATAS = Dictionary<string, Dictionary<string, List<Dictionary<string, string>>>>;

    using USERDATA = Dictionary<string, SMetaDataAttribute>; // 클라이언트 파일

    internal class BodyDataMaker
    {
        private static string[] Role = { "role", "name" };

        // 인자로 ref를 쓰는 이유는 메모리 아끼려고. 대신 userData는 수정X! 주의해야함.
        public static void MakeMultipleBody(ref USERDATA userData, ref string outPut)
        {
            BODYDATAS finalyData = new BODYDATAS();

            foreach (var serverData in env.bookInfo)
            {
                SMetaDataAttribute metaData;
                userData.TryGetValue(serverData.Key, out metaData);
                                
                List<Dictionary<string, string>> attributeData = new List<Dictionary<string, string>>();

                // 갤러리 넘버
                foreach (var data in metaData.number)
                {
                    Dictionary<string, string> attri = new Dictionary<string, string>();
                    attri.Add(Role[0], data.Key);
                    attri.Add(Role[1], data.Value);

                    attributeData.Add(attri);
                }

                // 작가
                foreach (var data in metaData.artist)
                {
                    foreach (var tags in data.Value)
                    {
                        Dictionary<string, string> attri = new Dictionary<string, string>();
                        attri.Add(Role[0], data.Key);
                        attri.Add(Role[1], tags);

                        attributeData.Add(attri);
                    }
                }
                // 그룹
                foreach (var data in metaData.group)
                {
                    foreach (var tags in data.Value)
                    {
                        Dictionary<string, string> attri = new Dictionary<string, string>();
                        attri.Add(Role[0], data.Key);
                        attri.Add(Role[1], tags);

                        attributeData.Add(attri);
                    }
                }
            
                // 타입
                foreach (var data in metaData.type)
                {
                    Dictionary<string, string> attri = new Dictionary<string, string>();
                    attri.Add(Role[0], data.Key);
                    attri.Add(Role[1], data.Value);

                    attributeData.Add(attri);
                }

                // 시리즈
                foreach (var data in metaData.series)
                {
                    foreach (var tags in data.Value)
                    {
                        Dictionary<string, string> attri = new Dictionary<string, string>();
                        attri.Add(Role[0], data.Key);
                        attri.Add(Role[1], tags);

                        attributeData.Add(attri);
                    }
                }

                // 캐릭터
                foreach (var data in metaData.character)
                {
                    foreach (var tags in data.Value)
                    {
                        Dictionary<string, string> attri = new Dictionary<string, string>();
                        attri.Add(Role[0], data.Key);
                        attri.Add(Role[1], tags);

                        attributeData.Add(attri);
                    }
                }

                // 태그
                foreach (var data in metaData.tag)
                {
                    foreach (var tags in data.Value)
                    {
                        Dictionary<string, string> attri = new Dictionary<string, string>();
                        string[] tagData = tags.Split(':');

                        for (int i = 0; i < Role.Length; i++)
                            attri.Add(Role[i], tagData[i]);

                        attributeData.Add(attri);
                    }
                }

                // 언어
                foreach (var data in metaData.language)
                {
                    Dictionary<string, string> attri = new Dictionary<string, string>();
                    attri.Add(Role[0], data.Key);
                    attri.Add(Role[1], data.Value);

                    attributeData.Add(attri);
                }

                Dictionary<string, List<Dictionary<string, string>>> authorData = new Dictionary<string, List<Dictionary<string, string>>>();
                authorData.Add("authors", attributeData);

                finalyData.Add(serverData.Value.id, authorData);
            }

            string json = JsonConvert.SerializeObject(finalyData, Formatting.Indented);
        }

        public static void MakeBody(ref USERDATA userData, ref List<string> outPut)
        {

        }
    }
}
