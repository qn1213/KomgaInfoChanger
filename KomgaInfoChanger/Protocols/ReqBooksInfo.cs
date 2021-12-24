using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqBooksInfo
    {
        private const string api = "/api/v1/books";
        private Dictionary<string, string> header;

        public ReqBooksInfo()
        {
            header = new Dictionary<string, string>();
            header.Add(env.AUTH_PREFIX_, env.basicAuthInfo);
        }

        public ConcurrentDictionary<string, Infos.SAttribute> Request()
        {
            string ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, header);

            ConcurrentDictionary<string, Infos.SAttribute> tmp = new ConcurrentDictionary<string, Infos.SAttribute>();

            JObject jObj = JObject.Parse(ret);
            foreach(var item in jObj)
            {
                string k = item.Key;
                if(k == "content")
                {
                    foreach(var item2 in item.Value)
                    {
                        string k2 = item2.ToString();
                        Infos.SAttribute tmpAtri;
                        JObject fJobj = JObject.Parse(k2);

                        tmpAtri.id = fJobj.GetValue("id").ToString();
                        tmpAtri.seriesId = fJobj.GetValue("seriesId").ToString();
                        tmpAtri.libraryId = fJobj.GetValue("libraryId").ToString();
                        
                        string metaData = fJobj.GetValue("media").ToString();
                        JObject fJobj2 = JObject.Parse(metaData);
                        tmpAtri.mediaType = fJobj2.GetValue("mediaType").ToString();
                        
                        tmp.TryAdd(fJobj.GetValue("id").ToString(), tmpAtri);
                    }
                    break;
                }
            }
            return tmp;
        }
    }
}
