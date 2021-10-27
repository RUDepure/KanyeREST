using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KanyeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Clear quotations string
            string clearQuotation = string.Empty;
            string clearQuotation2 = string.Empty;

            //Initializing the lists and clients
            var kayneQuotesList = new List<string>();
            var ronQuotesList = new List<string>();
            var kayneClient = new HttpClient();
            var ronClient = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                //Kayne's Section
                //Kayne Response GET
                var kanyeResponse = kayneClient.GetStringAsync("https://api.kanye.rest").Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                //Inserting Kayne's quote into a list
                kayneQuotesList.Add(kanyeQuote);

                //Ron's section
                //Ron Response GET
                var ronResponse = ronClient.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                clearQuotation = ronQuote.Remove(0, 1);
                clearQuotation = clearQuotation.Remove((clearQuotation.Length)-1, 1);

                //Inserting Kayne's quote into a list
                ronQuotesList.Add(clearQuotation);
            }

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine($"Kanye: {kayneQuotesList[j]}");
                Console.WriteLine($"Ron: {ronQuotesList[j]}\n");
            }

            
        }
    }
}
