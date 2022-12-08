using Application_Echange_de_livre.Model;
using AutoMapper;
using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.App_Start
{
    public class MapperConfig
    {
        public static MapperConfiguration Config { get; set; }
        public static MapperConfiguration Configure()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            return Config;
        }
    }
}
