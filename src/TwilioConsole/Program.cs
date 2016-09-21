using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace TwilioConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var authToken = "5bb0e7c6e8ed9c670a74baba7dcdf2e3";
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/AC7e610a536403b0228f065c7830d4212b/Messages", Method.POST);

            request.AddParameter("To", "+14049812892");
            request.AddParameter("From", "+14703278015");
            request.AddParameter("Body", "Hello again!");

            client.Authenticator = new HttpBasicAuthenticator("AC7e610a536403b0228f065c7830d4212b", "84a465c46678a067da6bfec5bebd9d4f");
            client.ExecuteAsync(request);
            Console.ReadLine();
        }
    }
}
