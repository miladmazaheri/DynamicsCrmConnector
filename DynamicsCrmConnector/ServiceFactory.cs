using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsCrmConnector
{
    internal class ServiceFactory
    {
        public async Task<HttpResponseMessage> SendMessageAsync(WebApiConfiguration webConfig,
            HttpMethod httpMethod, string messageUri, string body = null)
        {
            // Get the access token that is required for authentication.
            var authentication = new Authentication();
            var accessToken = await authentication.GetAccessToken(webConfig.ClientId, webConfig.Secret, webConfig.TenantId, webConfig.ResourceUri);

            // Create an HTTP message with the required WebAPI headers populated.
            var client = new HttpClient();
            var message = new HttpRequestMessage(httpMethod, messageUri);

            message.Headers.Add("OData-MaxVersion", "4.0");
            message.Headers.Add("OData-Version", "4.0");
            message.Headers.Add("Prefer", "odata.include-annotations=*");
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Add any body content specified in the passed parameter.
            if (body != null)
                message.Content = new StringContent(body, UnicodeEncoding.UTF8, "application/json");

            // Send the message to the WebAPI.
            return await client.SendAsync(message);
        }
    }
}