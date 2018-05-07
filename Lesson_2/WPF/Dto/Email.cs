using Newtonsoft.Json;

namespace WPF.Dto
{
    public class Email
    {
        [JsonProperty(PropertyName = "Email")]
        public string UserEmail { get; set; }
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return UserEmail;
        }
    }
}
