using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Store.WebApi.Handlers
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isValidAPIKey = false;
            IEnumerable<string> lsHeadersKey;

            //Validate that the api key exists
            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out lsHeadersKey);

            if (lsHeadersKey != null)
            {
                if (WebConfigurationManager.AppSettings["API_KEY"] == lsHeadersKey.FirstOrDefault())
                {
                    isValidAPIKey = true;
                }
            }

            //If the key is not valid, return an http status code.
            if (!isValidAPIKey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API Key");
            }

            //Allow the request to process further down the pipeline
            var response = await base.SendAsync(request, cancellationToken);

            //Return the response back up the chain
            return response;
        }
    }
}