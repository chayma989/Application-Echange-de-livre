using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;

namespace Echange_Livres.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorService AuthorService = new AuthorService(new AuthorRepository(new MyContext()));
        private MyContext context = new MyContext();



        // GET: Author
        public ActionResult Index()
        {
            List<Author> lst = AuthorService.GetAll();
            return View(lst);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = context.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                AuthorService.Add(author);
                return RedirectToAction("index");
            }
            return View(author);
        }



        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = context.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                AuthorService.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }



        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = context.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }



        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = context.Authors.Find(id);
            AuthorService.Delete(author);
            return RedirectToAction("Index");
        }
    }
}
