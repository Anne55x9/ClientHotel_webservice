using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientHotel_webservice
{
    class Program
    {
        static void Main(string[] args)
        {
            Guest g1 = new Guest();

            g1.Guest_No = 200;
            g1.Name = "Martin";

            using (var client = new HttpClient())
            {

            }

        }
    }
}
