using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AjusteProlex_WPF.Download
{
    public class DownloadParameters
    {
        public static DownloadParameters Instance { get; private set; }

        // Parâmentros contidos no arquivo JSON servido pelo servidor da Automatiza
        public string Firebird_Url_X86 { get; set; }
        public string Firebird_Hash_X86 { get; set; }
        public string Firebird_Url_X64 { get; set; }
        public string Firebird_Hash_X64 { get; set; }
        public string Prolex6_Url { get; set; }
        public string Prolex6_Hash { get; set; }
        public string ProlexTDPJ_Url { get; set; }
        public string ProlexTDPJ_Hash { get; set; }
        public string ProlexNet_Url { get; set; }
        public string ProlexNet_Hash { get; set; }

        public const string AplicationsUrl = "https://automatizabox.azurewebsites.net/uploads/applicationlist.json";

        public static async Task ApplicationListAsync()
        {
            WebClient client = new WebClient();

            var json = await client.DownloadStringTaskAsync(AplicationsUrl);
            Instance = DeserializeJson(json);
        }

        public static DownloadParameters DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject<DownloadParameters>(json);
        }
    }
}
