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

        private int getCount = 0;
        public ReqBooksInfo(int count = 0)
        {
            header = new Dictionary<string, string>();
            header.Add(env.AUTH_PREFIX_, env.basicAuthInfo);

            if (count < 0)
                getCount = 0;
            getCount = count;
        }

        public Dictionary<string, SBookAttribute> Request()
        {
            string ret = null;
            if (getCount > 0)
            {   // 서버에 저장된 파일 수만큼 가져올 수 있게 해줘야함
                // API인자로 Page, Size가 있는데...
                // Page는 먼지 몰?루 겠음
                Dictionary<string, string> query = new Dictionary<string, string>();
                query.Add("size", getCount.ToString());
                ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, header, query);
            }
            else
                ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, header);

            Dictionary<string, SBookAttribute> server_data = new Dictionary<string, SBookAttribute>();

            JObject jObj = JObject.Parse(ret);
            foreach(var item in jObj)
            {
                string k = item.Key;
                if(k == "content")
                {
                    foreach(var item2 in item.Value)
                    {
                        string k2 = item2.ToString();
                        SBookAttribute tmpAtri;
                        JObject fJobj = JObject.Parse(k2);

                        tmpAtri.id = fJobj.GetValue("id").ToString();
                        tmpAtri.seriesId = fJobj.GetValue("seriesId").ToString();
                        tmpAtri.libraryId = fJobj.GetValue("libraryId").ToString();
                        
                        string metaData = fJobj.GetValue("media").ToString();
                        JObject fJobj2 = JObject.Parse(metaData);
                        tmpAtri.mediaType = fJobj2.GetValue("mediaType").ToString();

                        if (!server_data.ContainsKey(fJobj.GetValue("name").ToString()))
                            server_data.Add(fJobj.GetValue("name").ToString(), tmpAtri);
                        else
                            continue;

                    }
                    break;
                }
            }
            return server_data;
        }
    }
}
