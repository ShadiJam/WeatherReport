using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2 {
    class API {
        private string url;

        public API(string url){
            this.url = url;
        }

        public virtual async Task<string> GetJSON(){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(this.url);
            return reply;
        }

        public async Task<T> GetData<T>(){
            string json = await GetJSON();
            T instance = JsonConvert.DeserializeObject<T>(json);
            return instance;
        }

        public static async Task<string> getUrl(string url){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(url);
            return reply;

        }
    }
}
  