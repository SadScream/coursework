using Newtonsoft.Json.Linq;
using PlumMessenger.Connection.Errors;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Requests
{
    public abstract class DefaultRequest : Base
    {
        protected string ApiTemplate { get; set; } = "api/{0}";

        public DefaultRequest(string host) : base(host)
        { }

        protected async Task<JObject> GetJsonFromHttpContent(HttpContent content)
        {
            string result = await content.ReadAsStringAsync();
            return JObject.Parse(result);
        }

        protected async void ConfirmAuthorization(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                JObject json = await GetJsonFromHttpContent(response.Content);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Unauthorized(json["message"].ToString());
                }
            }
        }
    }
}
