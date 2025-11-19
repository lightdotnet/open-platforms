using Light.Shopee.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Light.Shopee
{
    public abstract class ShopeeHttpClient
    {
        private readonly HttpClient _httpClient;

        private readonly IShopeeCredential _credential;

        public ShopeeHttpClient(IHttpClientFactory httpClientFactory, IShopeeCredential credential)
        {
            _httpClient = httpClientFactory.CreateShopeeClient();

            _credential = credential;
        }

        protected async Task<string> BuildSignedUrl(string path, string urlQuery = "")
            => (await _credential.GetCredential()).GenerateSignedUrl(path) + urlQuery;

        protected Task<string> BuildSignedUrl<TRequest>(string path, TRequest request)
            where TRequest : BaseRequest
            => BuildSignedUrl(path, request.UrlQuery);

        protected async Task<IShopeeResult<T>> TryGetAsync<T>(string path)
        {
            try
            {
                var url = await BuildSignedUrl(path);

                using (var response = await _httpClient.GetAsync(url))
                {
                    return await response.ReadAs<T>();
                }
            }
            catch (Exception ex)
            {
                return ShopeeResult<T>.Failed(ex.Message);
            }
        }

        protected async Task<IShopeeResult<T>> TryGetAsync<T>(string path, BaseRequest query)
        {
            try
            {
                var url = await BuildSignedUrl(path, query.UrlQuery);

                using (var response = await _httpClient.GetAsync(url))
                {
                    return await response.ReadAs<T>();
                }
            }
            catch (Exception ex)
            {
                return ShopeeResult<T>.Failed(ex.Message);
            }
        }

        protected async Task<IShopeeResult> TryPostAsync(string path, object data)
        {
            try
            {
                var url = await BuildSignedUrl(path);

                using (var response = await _httpClient.PostAsJsonAsync(url, data))
                {
                    return await response.Read();
                }
            }
            catch (Exception ex)
            {
                return ShopeeResult.Failed(ex.Message);
            }
        }

        protected async Task<IShopeeResult<T>> TryPostAsync<T>(string path, object data)
        {
            try
            {
                var url = await BuildSignedUrl(path);

                using (var response = await _httpClient.PostAsJsonAsync(url, data))
                {
                    return await response.ReadAs<T>();
                }
            }
            catch (Exception ex)
            {
                return ShopeeResult<T>.Failed(ex.Message);
            }
        }

        protected async Task<HttpResponseMessage> GetAsync(string path)
        {
            var url = await BuildSignedUrl(path);

            return await _httpClient.GetAsync(url);
        }

        protected async Task<HttpResponseMessage> GetAsync(string path, BaseRequest query)
        {
            var url = await BuildSignedUrl(path, query);

            return await _httpClient.GetAsync(url);
        }

        protected async Task<HttpResponseMessage> PostAsJsonAsync(string path, object data)
        {
            var url = await BuildSignedUrl(path);

            return await _httpClient.PostAsJsonAsync(url, data);
        }


    }
}
