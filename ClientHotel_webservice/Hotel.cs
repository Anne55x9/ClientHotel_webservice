﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHotel_webservice
{
    public class Hotel
    {

        
        public int Hotel_No { get; set; }

      
        public string Name { get; set; }

    
        public string Address { get; set; }

       
        public virtual ICollection<Room> Room { get; set; }
    }
}
