using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Box
{
    internal class HttpHelper
    {
        public class PassQuery
        {
            public string key => "123";
            public string query { get; set; }
        }

        HttpClient client = new HttpClient();

        public HttpHelper()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        //public async Task<string> PostData(string data, string url, Func<JObject, int> handlerData, Func<Exception, int> throwError)
        public async Task<string> PostData(PassQuery data, string url = "https://vps.gins.my.id/database/get.php")
        {
            try
            {
                var json = await client.PostAsJsonAsync(url, data);
                var content = await json.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception e)
            {
                return "Error1 : " + e.Message;
            }
        }
    }
}
