using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net;
using WebApiCaller.Info.Response;
using WebApiCaller.Utils;
using System.IO;

namespace WebApiCaller.Controllers
{
    public class BaseController : Controller
    {
        private const string _contentType = "application/json";
        private const string _tokenHeaderName = "X-Access-Token";
        private const string _apiTokenKey = "sighthoundApiToken";

        public ResponseInfo RequestApi(string url, string requestMethod, Dictionary<string, string> headers = null)
        {
            ResponseInfo response = new ResponseInfo();

            var request = HttpWebRequest.Create(url);
            request.Method = requestMethod;
            request.ContentType = _contentType;

            request.Headers[_tokenHeaderName] = ConfigurationUtils.GetAppSettingsValue(_apiTokenKey);
            if (headers != null && headers.Count > 0)
            {
                foreach(var header in headers) 
                {
                    if (headers.ContainsKey(header.Key))
                        request.Headers[header.Key] = header.Value;
                }
            }

            var asyncResult = request.BeginGetResponse(ar =>
                {
                    using (var res = request.EndGetResponse(ar))
                    {
                        using (var responseStream = res.GetResponseStream())
                        {
                            using (var reader = new StreamReader(responseStream)) 
                            {
                                response.RawContent = reader.ReadToEnd();
                            }
                        }
                    }
                }, null
            );


            return response;
        }
    }
}