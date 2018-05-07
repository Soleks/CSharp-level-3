using Newtonsoft.Json;

namespace WPF.Dto
{
    public class SmtpSettings
    {
        [JsonProperty(PropertyName ="Address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "Port")]
        public int Port { get; set; }
    }
}
