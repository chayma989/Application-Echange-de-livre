using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Services
{
    public interface IUserService
    {
        UserDTO FindUserByUserNameAndPassword(LoginDTO loginDTO);
        List<UserDTO> GetAllUser();
        void Add(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        void Update(UserDTO userDTO);
    }
}
