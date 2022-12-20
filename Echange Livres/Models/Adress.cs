using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Models
{
    public class Adress : UserDTO
    {
        public string Street { get; set; }
        public string CodePostale { get; set; }
        public string Country { get; set; }
        public string State { get; set; }




        //Générer les constructeurs.
        public Adress()
        {
        }



        public Adress(string street, string codePostale, string country, string state)
        {
            Street = street;
            CodePostale = codePostale;
            Country = country;
            State = state;
        }
    }
}