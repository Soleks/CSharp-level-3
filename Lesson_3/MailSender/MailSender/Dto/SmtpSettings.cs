using Newtonsoft.Json;

namespace Dto
{
    public class SmtpSettings
    {
        [JsonProperty(PropertyName ="Address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "Port")]
        public int Port { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
