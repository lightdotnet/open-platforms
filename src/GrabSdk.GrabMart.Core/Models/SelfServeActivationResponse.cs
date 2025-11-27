using System.Text.Json.Serialization;

namespace Light.Grab.GrabMart.Models
{
    public class SelfServeActivationResponse
    {
        [JsonPropertyName("activationUrl")]
        public string ActivationUrl { get; set; }
    }
}
