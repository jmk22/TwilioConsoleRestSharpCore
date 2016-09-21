using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace TwilioConsole
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/AC7e610a536403b0228f065c7830d4212b/Messages.json", Method.POST);

            request.AddParameter("To", "+14049812892");
            request.AddParameter("From", "+14703278015");
            request.AddParameter("Body", "Hello again!");

            client.Authenticator = new HttpBasicAuthenticator("AC7e610a536403b0228f065c7830d4212b", "84a465c46678a067da6bfec5bebd9d4f");
            var tcs = new TaskCompletionSource<string>();
            String response = "";
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request);
            }).Wait();
            Console.WriteLine(response);
            Console.ReadLine();
        }

        public static Task<string> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<string>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response.Content);
            });
            return tcs.Task;
        }

    }
}
