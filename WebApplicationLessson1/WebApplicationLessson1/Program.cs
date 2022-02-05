using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationLessson1
{
    class Program
    {
       static HttpClient client = new ();
       static readonly string writePath = @"E:\result.txt";
        static async Task Main(string[] args)
        {
            File.Create(writePath);

            for (int i = 4; i < 14; i++)
            {
               string responseBody = await client.GetStringAsync(@"https://jsonplaceholder.typicode.com/posts/" + i);
               await WriteFile(responseBody);
            }     
        }

        static async Task WriteFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                   await sw.WriteAsync($"{text}\n\n");
            }
        }
    }
}
