using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSV_NetCore
{
    public class HttpClientBase
    {
        public HttpResponseMessage Test()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("");
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.baidu.com");

            request.Content.ReadAsStringAsync();

            var response = client.SendAsync(request);
            var content = response.Result;
            return content;
        }


        //private static async Task PostBasicAsync(object content, CancellationToken cancellationToken)
        //{
        //    using (var client = new HttpClient())
        //    using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
        //    {
        //        var json = JsonConvert.SerializeObject(content);
        //        using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
        //        {
        //            request.Content = stringContent;

        //            using (var response = await client
        //                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
        //                .ConfigureAwait(false))
        //            {
        //                response.EnsureSuccessStatusCode();
        //            }
        //        }
        //    }
        //}

        public async Task<string> Example()
        {
            //The data that needs to be sent. Any object works.
            var pocoObject = new
            {
                Name = "John Doe",
                Occupation = "gardener"
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string json = JsonConvert.SerializeObject(pocoObject);

            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            //The url to post to.
            var url = "https://httpbin.org/post";
            var client = new HttpClient();

            //Pass in the full URL and the json string content
            var response = await client.PostAsync(url, data);

            //It would be better to make sure this request actually made it through
            string result = await response.Content.ReadAsStringAsync();

            //close out the client
            client.Dispose();

            return result;
        }

    }
}
