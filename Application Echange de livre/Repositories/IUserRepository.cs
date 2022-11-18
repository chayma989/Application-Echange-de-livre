using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Repositories
{
     interface IUserRepository
    {
        List<User> FindALL();
        void AddUser(User user);
        void DeleteUser(int id);
        void Update(User user);
    }
}
