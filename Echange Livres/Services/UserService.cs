using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class UserService
    {
        private UserRepository userRep = new UserRepository();
        private UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserService()
        {
        }

        public UserDTO FindUserByUserNameAndPassword(LoginDTO loginDTO)
        {
            UserDTO userDto = userRep.FindUserByUserNameAndPassword(loginDTO);
            return userDto;
        }

        public void Add(UserDTO userDto)
        {
            userRep.Add(userDto);
        }

        public List<UserDTO> GetAllUser()
        {
            return userRep.GetAllUser();
        }
    }
}