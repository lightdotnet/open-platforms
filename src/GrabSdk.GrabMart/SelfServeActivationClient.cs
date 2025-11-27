using Light.Contracts;
using Light.Grab.GrabMart.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Light.Grab.GrabMart
{
    public class SelfServeActivationClient : GrabMartHttpClient, ISelfServeActivation
    {
        public SelfServeActivationClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Result<SelfServeActivationResponse>> GetActivationUrl(string partnerMerchantId)
        {
            var uri = "partner/v1/self-serve/activation";

            var request = new
            {
                partner = new
                {
                    merchantID = partnerMerchantId
                }
            };

            var json = JsonSerializer.Serialize(request);

            var response = await PostAsJsonAsync(uri, request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<SelfServeActivationResponse>();
                return Result<SelfServeActivationResponse>.Success(data);
            }
            else
            {
                var resultError = $"{response.StatusCode}: {await response.Content.ReadAsStringAsync()}";
                return Result<SelfServeActivationResponse>.Error(resultError);
            }
        }
    }
}
