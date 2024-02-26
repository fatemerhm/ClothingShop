using ClothingShop.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ClothingShop.PaymentSystem
{
    public class IDPay
    {
        private HttpClient client = null;
        public IDPay()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.idpay.ir/v1.1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("X-API-KEY", "6a7f99eb-7c20-4412-a972-6dfb7cd253a4");
            client.DefaultRequestHeaders.Add("X-SANDBOX", "1");
        }
        public async Task<Tuple<object, bool>> RequestPayment(PaymentRequestModel obj)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(client.BaseAddress + "payment"),
                    Method = HttpMethod.Post
                };


                request.Content = new StringContent(JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {

                    string _data = await response.Content.ReadAsStringAsync();
                    return new Tuple<object, bool>(JsonConvert.DeserializeObject<SucessRequestRespons>(_data), true);
                }
                else
                {

                    string _data = await response.Content.ReadAsStringAsync();
                    return new Tuple<object, bool>(JsonConvert.DeserializeObject<FailedRequestRespons>(_data), false);
                }
            }
            catch (Exception ex)
            {
                //return new FailedRequestRespons
                //{
                //    error_code = 0,
                //    error_message = ex.Message
                //};
            }
            return null;
        }
        public async Task<object> VerifyPayment(ResultPayment obj)
        {
            try
            {


                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(client.BaseAddress + "payment/verify"),
                    Method = HttpMethod.Post
                };

                request.Content = new StringContent(JsonConvert.SerializeObject(
                    new { id = obj.id, order_id = obj.order_id }
                    ),
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string _data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaymentInfo>(_data);
                }
                else
                {
                    string _data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<FailedRequestRespons>(_data);
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
