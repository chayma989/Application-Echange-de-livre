using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public User UserId { get; set; }
        public bool IsAbo { get; set; }
    }

    }
