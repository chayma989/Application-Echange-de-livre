using Application_Echange_de_livre.Model;
using AutoMapper;
using Echange_Livres.App_Start;
using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Tools
{
    public class Convertisseur
    {

       

        public static UserDTO UtilisateurDtoFromUtilisateur(UserDTO userDto, User model)
        {

            /* userDto.Id = model.Id;
             userDto.Name = model.Name;
             userDto.Email = model.Email;
             userDto.Password = model.Password;
             userDto.TotalPoints= model.TotalPoints;
             userDto.Photo = model.Photo;
             userDto.IsAdmin = model.IsAdmin;
             userDto.Adresse = model.Adress;*/

            IMapper mapper = MapperConfig.Config.CreateMapper();
            userDto=mapper.Map(model,userDto);
          
            return userDto;


        }

        public static User UtilisateurFromUtilisateurDTO(UserDTO userDto, User user)
        {

            /* user.Id = userDto.Id;
             user.Name = userDto.Name;
             user.Email = userDto.Email;
             user.Password = userDto.Password;
             user.TotalPoints = userDto.TotalPoints;
             user.Photo = userDto.Photo;
             user.IsAdmin = userDto.IsAdmin;
             user.Adress = userDto.Adresse;*/

            IMapper mapper = MapperConfig.Config.CreateMapper();

            user = mapper.Map(userDto, user);

            return user;


        }

    }
}
