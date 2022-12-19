using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class UserController : Controller
    {
        private UserService UService = new UserService(new UserRepository());
        private MyContext context = new MyContext();


        public ActionResult Index(string sortBy, string search, int page = 0)
        {
            List<UserDTO> lst = UService.GetAllUser();

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserDTO userDTO, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(userDTO);
            }

            UserDTO user = new UserDTO();

            user.Photo = user.Name + Path.GetExtension(file.FileName);
            file.SaveAs(Server.MapPath("~/Content/UserImages/" + user.Photo));

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Password = user.Password;
            user.Adresse = user.Adresse;
            user.TotalPoints = userDTO.TotalPoints;
            user.IsAdmin = userDTO.IsAdmin;
            user.WishedBooks = userDTO.WishedBooks;

            UService.Add(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = context.UserDTOes.Find(id);

            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(userDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDTO userDTO =context.UserDTOes.Find(id);
            context.UserDTOes.Remove(userDTO);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           UserDTO userDTO = context.UserDTOes.Find(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(userDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                UService.Update(userDTO);
                return RedirectToAction("Index");
            }
            return View(userDTO);
        }

    }
}
