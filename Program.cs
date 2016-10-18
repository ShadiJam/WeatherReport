using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            prompt().Wait();
            // Console.WriteLine(result);
        }

        public static async Task prompt(){
            string input = Console.ReadLine();
            string result = await getUrl("http://google.com"+input);
            Console.WriteLine(result);
        }

        public static async Task<string> getUrl(string url){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(url);
            return reply;
        }
    }
}
