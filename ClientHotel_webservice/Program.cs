using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientHotel_webservice
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost.fiddler:18953";

            //Guest g1 = new Guest();

            //g1.Guest_No = 200;
            //g1.Name = "Martin";


          

            Console.WriteLine("Opgave 1. Get hotel 3.");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                
                string urlString = "api/hotels/3";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel3 = response.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine("hotel : " + hotel3.Name + "hoteladresse : " + hotel3.Address);

                        //foreach (var hotel in hotelList)
                        //{
                        //    Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                        //}
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }

                Console.WriteLine("Opgave 2. Get alle hoteller:");


                using (var client2 = new HttpClient())
                {
                    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client2.BaseAddress = new Uri(serverUrl);
                    client2.DefaultRequestHeaders.Clear();

                    string urlString2 = "api/hotels";

                    try
                    {
                        HttpResponseMessage response2 = client2.GetAsync(urlString2).Result;
                        if (response2.IsSuccessStatusCode)
                        {
                            var hotelList = response2.Content.ReadAsAsync < List < Hotel>>().Result;

                            foreach (var hotel in hotelList)
                            {
                                Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                            }

                            var hotelRoskilde = from h in hotelList
                                                where h.Address.Contains("Roskilde")
                                                select h;


                            foreach (var item in hotelRoskilde)
                            {
                                Console.WriteLine("hotel : " + item.Name + "hoteladresse : " + item.Address);
                            }


                        }

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Der er sket en fejl : " + e.Message);
                    }

                 

                }

                Console.ReadLine();
            }

        }
    }
}
