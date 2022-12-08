using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Echange_Livres.DTOs.BookDTOs;
using Echange_Livres.Repositories;

namespace Echange_Livres.Controllers
{
    public class BookEchangeController : Controller
    {
        private MyContext db = new MyContext();

        // GET: BookEchange
        public ActionResult Index()
        {
            return View(db.BookEchangeDTOes.ToList());
        }

        // GET: BookEchange/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEchangeDTO bookEchangeDTO = db.BookEchangeDTOes.Find(id);
            if (bookEchangeDTO == null)
            {
                return HttpNotFound();
            }
            return View(bookEchangeDTO);
        }

        // GET: BookEchange/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookEchange/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreationDate")] BookEchangeDTO bookEchangeDTO)
        {
            if (ModelState.IsValid)
            {
                db.BookEchangeDTOes.Add(bookEchangeDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookEchangeDTO);
        }

        // GET: BookEchange/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEchangeDTO bookEchangeDTO = db.BookEchangeDTOes.Find(id);
            if (bookEchangeDTO == null)
            {
                return HttpNotFound();
            }
            return View(bookEchangeDTO);
        }

        // POST: BookEchange/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreationDate")] BookEchangeDTO bookEchangeDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookEchangeDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookEchangeDTO);
        }

        // GET: BookEchange/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEchangeDTO bookEchangeDTO = db.BookEchangeDTOes.Find(id);
            if (bookEchangeDTO == null)
            {
                return HttpNotFound();
            }
            return View(bookEchangeDTO);
        }

        // POST: BookEchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookEchangeDTO bookEchangeDTO = db.BookEchangeDTOes.Find(id);
            db.BookEchangeDTOes.Remove(bookEchangeDTO);
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
