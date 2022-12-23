using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using Echange_Livres.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserDTO FindUserByUserNameAndPassword(LoginDTO loginDTO)
        {
            UserDTO userDto = new UserDTO();

          
            using (var context = new MyContext())
            {
                User model =
                context.Users.FirstOrDefault(u => u.Email.Equals(loginDTO.Email) &&
                u.Password.Equals(loginDTO.Password));
                userDto = Convertisseur.UtilisateurDtoFromUtilisateur(userDto, model);
            }
            return userDto;
        }


        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> lstDTO = new List<UserDTO>();
            using (var context = new MyContext())
            {
                List<User> lstModel = context.Users.ToList();
                foreach (var model in lstModel)
                {
                    lstDTO.Add(Convertisseur.UtilisateurDtoFromUtilisateur(new UserDTO(), model));
                }
            }

            return lstDTO;

        }

       

        public void Add(UserDTO userDTO)
        {
            User u = Convertisseur.UtilisateurFromUtilisateurDTO(userDTO, new User());
            using (var context = new MyContext())
            {
                context.Users.Add(u);
                context.SaveChanges();
            }
        }

        public void Delete(UserDTO userDTO)
        {
            User u = Convertisseur.UtilisateurFromUtilisateurDTO(userDTO, new User());
            using (var context = new MyContext())
            {
                context.Entry(userDTO).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(UserDTO userDTO)
        {
            User u = Convertisseur.UtilisateurFromUtilisateurDTO(userDTO, new User());
            using (var context = new MyContext())
            {            
                context.Entry(userDTO).State = EntityState.Modified;
                context.SaveChanges();
            }
           
        }

    }
}