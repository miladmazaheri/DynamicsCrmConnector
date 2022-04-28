using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace DynamicsCrmConnector
{
    internal class Authentication
    {
        public Authentication()
        {
        }

        public async Task<string> GetAccessToken(string clientId, string clientSecret, string tenantId, string resourceUri)
        {
            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new AuthenticationContext(
                "https://login.microsoftonline.com/" + tenantId);
            var result = await authContext.AcquireTokenAsync(resourceUri, credentials);

            return result.AccessToken;
        }
    }
}