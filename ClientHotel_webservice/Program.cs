﻿using System;
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
                            Console.WriteLine("Hoteller i Roskilde:");

                            ///Lamda sætning. 
                            // var hotellistRoskildeRum = response3.Content.ReadAsAsync<List<Hotel>>().Result.Where(x => x.Address.Contains("Roskilde");


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

                Console.WriteLine("Opgave 3, Get all hotels in roskilde and their rooms:");

                using (var client3 = new HttpClient())
                {
                    client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client3.BaseAddress = new Uri(serverUrl);
                    client3.DefaultRequestHeaders.Clear();
                    string urlString3 = "api/hotels";

                    try
                    {
                        HttpResponseMessage response3 = client3.GetAsync(urlString3).Result;
                        if (response3.IsSuccessStatusCode)
                        {
                            var hotelList = response3.Content.ReadAsAsync<List<Hotel>>().Result;

                            Console.WriteLine("Alle hoteller:");

                            foreach (var hotel in hotelList)
                            {
                                Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                            }

                            var hotelRoskilde = from h in hotelList
                                                where h.Address.Contains("Roskilde")
                                                select h;

                            Console.WriteLine("Hoteller i Roskilde:");

                            foreach (var item in hotelRoskilde)
                            {
                                Console.WriteLine("hotel : " + item.Name + "hoteladresse: " + item.Address);
                            }
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Der er sket en fejl : " + e.Message);
                    }

                }

                Console.WriteLine("Opgave 3 Fortsat:");

                

                using (var client4 = new HttpClient())
                {
                    client4.BaseAddress = new Uri(serverUrl);
                    client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client4.DefaultRequestHeaders.Clear();
                    string urlString4 = "api/rooms";
                    string urlString5 = "api/hotels";

                    


                    try
                    {
                        
                        HttpResponseMessage response4 = client4.GetAsync(urlString4).Result;
                        HttpResponseMessage response5 = client4.GetAsync(urlString5).Result; 
                        if (response4.IsSuccessStatusCode && response5.IsSuccessStatusCode)
                        {
                           

                            Console.WriteLine("alle rum:");

                            var rumliste = response4.Content.ReadAsAsync<List<Room>>().Result;

                           

                            var hotelliste = response5.Content.ReadAsAsync<List<Hotel>>().Result;

                            var hotelRoskilde = from h in hotelliste
                                                where h.Address.Contains("Roskilde")
                                                select h;

                            foreach (var item in hotelRoskilde)
                            {
                                Console.WriteLine($"{item.Address} {item.Name}");
                            }

                            //var rumliste2  = 
                            //    from r in rumliste
                            //    join h in hotelliste
                            //    on r.Hotel_No equals h.Hotel_No

                            var rumlisteRoskilde =
                             from h in hotelRoskilde
                             join r in rumliste
                             on h.Hotel_No equals r.Hotel_No
                             where h.Address.Contains("Roskilde")
                             select new
                             {
                                 r.Types,
                                 h.Name,
                                 h.Address
                             };

                            foreach (var item in rumlisteRoskilde)
                            {
                                Console.WriteLine(item);
                            }
                                

                               

                            //foreach (var item in rumliste)
                            //{
                            //    Console.WriteLine($"Rum type: {item.Types} , Pris: {item.Price}, Nummer {item.Room_No}");
                            //}




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
