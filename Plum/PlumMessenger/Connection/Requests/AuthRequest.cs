using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using PlumMessenger.Connection.Errors;
using Newtonsoft.Json.Linq;
using System.Net;

namespace PlumMessenger.Connection.Requests
{
    public class AuthRequest : DefaultRequest
    {
        public static bool LoggedIn = false;
        string ApiSignUp { get; set; }
        string ApiSignIn { get; set; }
        string ApiLogout { get; set; }

        public AuthRequest(string host = null) : base(host)
        {
            ApiSignUp = String.Format(ApiTemplate, "sign-up/");
            ApiSignIn = String.Format(ApiTemplate, "sign-in/");
            ApiLogout = String.Format(ApiTemplate, "logout/");
        }        

        public async Task SignUpMethod(string login, string password)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(ApiSignUp, new { 
                login = login,
                password = password
            });

            if (!response.IsSuccessStatusCode)
            {
                JObject json = await GetJsonFromHttpContent(response.Content);

                if ((int)response.StatusCode == 422)
                {
                    throw new IncorrectLoginOrPasswordFormat(json["message"].ToString());
                }
                else if (response.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    throw new LoginAlreadyTaken(json["message"].ToString());
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Authorized(json["message"].ToString());
                }
            }
        }

        public async Task<int> SignInMethod(string login, string password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{login}:{password}");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await Client.GetAsync(ApiSignIn);
            JObject json = await GetJsonFromHttpContent(response.Content);

            if (!response.IsSuccessStatusCode)
            {   
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new InvalidLoginOrPassword(json["message"].ToString());
                }
            }
            else if (json["message"] != null)
            {
                throw new Authorized(json["message"].ToString());
            }

            LoggedIn = true;
            Client.DefaultRequestHeaders.Authorization = null;

            return (int)json["user_id"];
        }

        public async Task LogoutMethod(string login, string password)
        {
            HttpResponseMessage response = await Client.GetAsync(ApiLogout);
            ConfirmAuthorization(response);
            LoggedIn = false;
        }
    }
}
