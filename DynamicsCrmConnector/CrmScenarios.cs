using Newtonsoft.Json.Linq;

namespace DynamicsCrmConnector
{
    public class CrmScenarios
    {
        private WebApiConfiguration _configuration;
        private ServiceFactory _serviceFactory;

        public CrmScenarios()
        {
            _configuration = new WebApiConfiguration();
            _serviceFactory = new ServiceFactory();
        }

        public async Task GetAccountNames(int top)
        {
            // Send a WebAPI message request for the top 3 account names.
            var response = await _serviceFactory.SendMessageAsync(_configuration, HttpMethod.Get,
                _configuration.ServiceRoot + $"accounts?$select=name&$top={top}");

            // Format and then output the JSON response to the console.
            if (response.IsSuccessStatusCode)
            {
                JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(body.ToString());
            }
            else
            {
                Console.WriteLine("The request failed with a status of '{0}'",
                       response.ReasonPhrase);
            }
        }
    }
}