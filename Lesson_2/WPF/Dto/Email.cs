using Newtonsoft.Json;

namespace WPF.Dto
{
    public class Email
    {
        [JsonProperty("Email")]
        public string UserEmail { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
