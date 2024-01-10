using Refit;
using TA_JeanEdwards.API.Services.Abstracts;

namespace TA_JeanEdwards.API.Services
{
    public class ApiService
    {
        public const string HTTP_CLIENT_KEY = "OMDbAPI";
        private readonly HttpClient _client;
        private readonly RefitSettings _settings;

        public ApiService(IHttpClientFactory http)
        {
            _client = http.CreateClient(HTTP_CLIENT_KEY);
            _settings = new(new NewtonsoftJsonContentSerializer());

            Movie = RestService.For<IMovie>(_client, _settings);
        }

        public IMovie Movie { get; set; }
    }
}
