using System.Text.Json;

namespace Interview.Ui.Helper
{
    public class GenericApiProxy
    {
        private readonly HttpClient client;

        public GenericApiProxy(HttpClient client) 
        { 
            this.client = client;
        }

        public async Task<string> Get(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var rsp = await client.GetAsync(url, cancellationToken);
            rsp.EnsureSuccessStatusCode();

            return await rsp.Content.ReadAsStringAsync();
        }

        public async Task<T> Get<T>(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            return JsonSerializer.Deserialize<T>(await Get(url, cancellationToken));
        }

        public async Task Post<T>(string url, T data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var bdy = new StringContent(JsonSerializer.Serialize(data));
            var rsp = await client.PostAsync(url, bdy, cancellationToken);
            rsp.EnsureSuccessStatusCode();
        }

        public async Task Put<T>(string url, T data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var bdy = new StringContent(JsonSerializer.Serialize(data));
            var rsp = await client.PutAsync(url, bdy, cancellationToken);
            rsp.EnsureSuccessStatusCode();
        }
    }
}
