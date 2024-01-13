using System.Collections.Specialized;
using System.Web;

namespace TA_JeanEdwards.API.Services
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private string _apiKey { get; }
        public ApiKeyHandler(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("ApiKey").Value!;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            UriBuilder uriBuilder = new (request.RequestUri!);
            NameValueCollection? query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["apikey"] = _apiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
