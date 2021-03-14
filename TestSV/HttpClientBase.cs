using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestSV
{
    public class WeatherForecastRq
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    public class Result
    {
        public string StatusCode { set; get; }
        public string ReasonPhrase { set; get; }

        public List<WeatherForecast> data { set; get; }
    }
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
    public class HttpClientBase
    {
        private string ulrBase;
        private string Action;
        public HttpClientBase()
        {
            ulrBase = System.Configuration.ConfigurationManager.AppSettings["ApiUrlBase"];
            Action = System.Configuration.ConfigurationManager.AppSettings["ApiAction"];
        }
        public HttpResponseMessage Exercute<TIn>(string method, string baseUrl, string action, TIn input, Dictionary<string, string> header = null)
        {
            try
            {
                HttpResponseMessage result = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var req = new HttpRequestMessage(new HttpMethod(method), ulrBase + Action);
                    //req.Headers.Add("Referer", "login.microsoftonline.com");
                    req.Headers.Add("Accept", "application/x-www-form-urlencoded");

                    if (header != null)
                    {
                        foreach (KeyValuePair<string, string> item in header)
                        {
                            req.Headers.Add(item.Key, item.Value);
                        }
                    }
                    HttpContent cont = null;
                    if (input != null)
                    {
                        //string objJson = JsonConvert.SerializeObject(input);
                        ////var rqContent = new StringContent(objJson, Encoding.UTF8, "application/json");
                        //var rqContent = new StringContent(objJson);
                        //cont = rqContent;
                        //// cont.Headers.Add("", "application/json");

                        //req.Content = rqContent;
                        //req.Content.Headers.ContentType.CharSet = @"utf-8";

                        var parameters = new List<KeyValuePair<string, string>>();
                        var types = input.GetType().GetProperties();
                        foreach (var propertyInfo in types)
                        {
                            parameters.Add(new KeyValuePair<string, string>(propertyInfo.Name, "1"));
                        }
                        // Thiết lập Content
                        var content = new FormUrlEncodedContent(parameters);
                    }
                    try
                    {
                        //result = client.PostAsync(ulrBase + Action, cont).Result;
                        result = client.SendAsync(req).Result;
                        var lst = result.Content.ReadAsStringAsync().Result;
                        var lstObj = JsonConvert.DeserializeObject<List<WeatherForecast>>(lst);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
