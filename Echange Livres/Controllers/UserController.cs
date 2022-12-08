using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService(new UserRepository());
        public ActionResult Index(string sortBy, string search, int page = 0)
        {
            List<UserDTO> lst = userService.GetAllUser();

            //Pagination

            //if (!page.HasValue) { page = 0; };

            page = (page < 0) ? 0 : page;
            int pageSize = 2;
            int totalPages = 0;
            if ((lst.Count() % pageSize) == 0)
            {
                totalPages = lst.Count() / pageSize;
            }
            else
            {
                totalPages = (lst.Count() / pageSize) + 1;
            }

            lst = lst.Skip(pageSize * page).Take(pageSize).ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.Page = page + 1;
            ViewBag.PreviousPage = page - 1;

            if (lst.Count() < pageSize)
            {
                ViewBag.Next = page;
            }
            else
            {
                ViewBag.Next = page + 1;
            }



            //Filtre
            if (search != null)
            {
                lst = lst.Where(u => u.Name.Contains(search)).ToList();
            }

            //Tri
            switch (sortBy)
            {
                case "nameAsc":
                    lst = lst.OrderBy(u => u.Name).ToList();
                    break;
                case "nameDesc":
                    lst = lst.OrderByDescending(u => u.Name).ToList();
                    break;
                case null:
                    break;
            }


            return View(lst);
        }
    }
}
