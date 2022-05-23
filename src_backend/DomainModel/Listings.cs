﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Listings
    {
        public int? idPerson { get; set; }

        public int ListingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdAdress { get; set; }
        public string AdlistingDescription { get; set; }
        public double? Price { get; set; }
        public string Title { get; set; }
        public int PetId { get; set; }
        public bool? IsActiv { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[EmailAddress]
        //[Display(Name = "Email")]
        public string email { get; set; }

        //[Required]
        //[MaxLength(20)]
        //[Display(Name = "Password")]
        public string password { get; set; }

        public string sessionId { get; set; }


        public string PetName { get; set; } 
        public  string adress { get; set; }     




    }
}
