using System;
using WebApiClient.Exception;

namespace WebApiClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using ModernHttpClient;

    using Newtonsoft.Json;

    public class WebApiClient
    {
        /// <summary>
        /// TODO The formatter.
        /// </summary>
        private const string Formatter = "application/json";

        /// <summary>
        /// The http client.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// The path.
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiClient"/> class.
        /// </summary>
        /// <param name="baseUri">
        /// The base uri.
        /// </param>
        public WebApiClient(string baseUri)
        {
            HttpClientHandler handler = new NativeMessageHandler();
            this.client =
                new HttpClient(handler) { BaseAddress = new Uri(baseUri), Timeout = TimeSpan.FromSeconds(60) };
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Formatter));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiClient"/> class.
        /// </summary>
        /// <param name="baseUri">
        /// The base uri.
        /// </param>
        /// <param name="authenticationScheme">
        /// The authentication scheme.
        /// </param>
        /// <param name="authenticationParameter">
        /// The authentication parameter.
        /// </param>
        /// <param name="tenantId">
        /// The tenant id.
        /// </param>
        public WebApiClient(string baseUri, string authenticationScheme, string authenticationParameter, string tenantId = null)
            : this(baseUri)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                authenticationScheme,
                authenticationParameter);
            this.client.DefaultRequestHeaders.Add("X-TENANTID", tenantId);
        }

        public async Task<TResponse> GetAsync<TResponse>()
        {
            var responseMessage = await this.client.GetAsync(this.path);

            this.EnsureSuccessStatusCode(responseMessage);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(responseString);
            return response;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest request)
        {
            var requestRawJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestRawJson, Encoding.UTF8, Formatter);
            var responseMessage = await this.client.PutAsync(this.path, content);

            this.EnsureSuccessStatusCode(responseMessage);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(responseString);
            return response;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var requestRawJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestRawJson, Encoding.UTF8, Formatter);
            var responseMessage = await this.client.PostAsync(this.path, content);

            this.EnsureSuccessStatusCode(responseMessage);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(responseString);
            return response;
        }

        public async Task<TResponse> DeleteAsync<TResponse>()
        {
            var responseMessage = await this.client.DeleteAsync(this.path);

            this.EnsureSuccessStatusCode(responseMessage);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(responseString);
            return response;
        }

        private void EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = response.Content?.ReadAsStringAsync().Result;
                response.Content?.Dispose();
                throw new HttpResponseException(response.StatusCode, content);
            }
        }

        public void SetRelativePath(string path)
        {
            if (!path.ToLowerInvariant().Contains("api/"))
            {
                path = $"api/{path}";
            }

            this.path = path;
        }
    }
}
