using RestSharp;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BookingHotel.Interface.Configurations
{
    public class CreateClient
    {
        public static RestClient _restClient;
        public static void IntializeClientRequest()
        {
            _restClient = new RestClient(@"http://localhost:44385/");
        }
        public static async Task<RestResponse> SendRestPostRequest(string resource, Method method ,string token= "", object body = null)
        {
            IntializeClientRequest();
            RestRequest request = new RestRequest();
            request.Resource = new Uri(@"https://localhost:44385/" + resource).ToString();
            request.Method = method;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("content-type", "application/json");

            var response = await _restClient.ExecuteAsync(method == Method.Get ? request : request.AddJsonBody(body));

            return response;
        }
    }
}
