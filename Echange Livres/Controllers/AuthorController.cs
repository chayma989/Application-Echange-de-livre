using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Echange_Livres.DTOs;
using Echange_Livres.Repositories;

namespace Echange_Livres.Controllers
{
    public class AuthorController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Author
        public ActionResult Index()
        {
            return View(db.AuthorDTOes.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorDTO authorDTO = db.AuthorDTOes.Find(id);
            if (authorDTO == null)
            {
                return HttpNotFound();
            }
            return View(authorDTO);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                db.AuthorDTOes.Add(authorDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorDTO);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorDTO authorDTO = db.AuthorDTOes.Find(id);
            if (authorDTO == null)
            {
                return HttpNotFound();
            }
            return View(authorDTO);
        }

        // POST: Author/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorDTO);
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorDTO authorDTO = db.AuthorDTOes.Find(id);
            if (authorDTO == null)
            {
                return HttpNotFound();
            }
            return View(authorDTO);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorDTO authorDTO = db.AuthorDTOes.Find(id);
            db.AuthorDTOes.Remove(authorDTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
