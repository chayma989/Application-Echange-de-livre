using Echange_Livres.DTOs;
using System.Collections.Generic;

namespace Echange_Livres.Repositories
{
    public interface IUserRepository
    {
        UserDTO FindUserByUserNameAndPassword(LoginDTO loginDTO);
        List<UserDTO> GetAllUser();
        void Add(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        void Update(UserDTO userDTO);
      

    }
}