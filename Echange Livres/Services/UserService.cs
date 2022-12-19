using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class UserService : IUserService
    {
        private UserRepository repository;

        public UserService(UserRepository repository)
        {
            this.repository = repository;
        }

        public void Add(UserDTO userDTO)
        {
            repository.Add(userDTO);
        }

        public void Delete(UserDTO userDTO)
        {
            repository.Delete(userDTO);
        }

        public UserDTO FindUserByUserNameAndPassword(LoginDTO loginDTO)
        {
            return repository.FindUserByUserNameAndPassword(loginDTO);
        }

        public List<UserDTO> GetAllUser()
        {
            return repository.GetAllUser();
        }

        public void Update(UserDTO userDTO)
        {
            repository.Update(userDTO);
        }
    }
}