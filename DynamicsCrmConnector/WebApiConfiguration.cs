using Microsoft.Extensions.Configuration;

namespace DynamicsCrmConnector
{
    public class WebApiConfiguration
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string TenantId { get; set; }
        public string ResourceUri { get; set; }
        public string ServiceRoot { get; set; }

        public WebApiConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            ClientId = configuration["ClientId"];
            Secret = configuration["ClientSecret"];
            TenantId = configuration["TenantId"];
            ResourceUri = configuration["ResourceUri"];
            ServiceRoot = configuration["ServiceRootUri"];
        }
    }
}