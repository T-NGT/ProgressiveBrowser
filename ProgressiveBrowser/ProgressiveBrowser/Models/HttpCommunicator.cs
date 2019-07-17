using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveBrowser.Models
{
    public class HttpCommunicator : ICommunicator
    {
        public async Task<string> GetAsync(string uri)
        { 
            var client = new HttpClient();

            return await client.GetStringAsync(uri);
        }


        public async Task DownloadImgAsync()
        {
            var client = new HttpClient();
            var uri = "https://www.google.co.jp/images/branding/googleg/1x/googleg_standard_color_128dp.png";
            var res = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = $@"{folder}/img.bmp";

            using (var fileStream = File.Create(path))
            using (var httpStream = await res.Content.ReadAsStreamAsync())
            {
                await httpStream.CopyToAsync(fileStream);
            }
               
        }
    }
}
