using Newtonsoft.Json;

namespace WPF.Dto
{
    public class SmtpSettings
    {
        [JsonProperty("Address") ]
        public string Address { get; set; }
        [JsonProperty("Port")]
        public int Port { get; set; }
    }
}
