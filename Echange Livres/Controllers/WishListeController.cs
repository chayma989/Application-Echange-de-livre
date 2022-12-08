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
    public class WishListeController : Controller
    {
        private MyContext db = new MyContext();

        // GET: WishListe
        public ActionResult Index()
        {
            var wishListeDTOes = db.WishListeDTOes.Include(w => w.Book).Include(w => w.User);
            return View(wishListeDTOes.ToList());
        }

        // GET: WishListe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishListeDTO wishListeDTO = db.WishListeDTOes.Find(id);
            if (wishListeDTO == null)
            {
                return HttpNotFound();
            }
            return View(wishListeDTO);
        }

        // GET: WishListe/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: WishListe/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,BookId")] WishListeDTO wishListeDTO)
        {
            if (ModelState.IsValid)
            {
                db.WishListeDTOes.Add(wishListeDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", wishListeDTO.BookId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", wishListeDTO.UserId);
            return View(wishListeDTO);
        }

        // GET: WishListe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishListeDTO wishListeDTO = db.WishListeDTOes.Find(id);
            if (wishListeDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", wishListeDTO.BookId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", wishListeDTO.UserId);
            return View(wishListeDTO);
        }

        // POST: WishListe/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,BookId")] WishListeDTO wishListeDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishListeDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", wishListeDTO.BookId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", wishListeDTO.UserId);
            return View(wishListeDTO);
        }

        // GET: WishListe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishListeDTO wishListeDTO = db.WishListeDTOes.Find(id);
            if (wishListeDTO == null)
            {
                return HttpNotFound();
            }
            return View(wishListeDTO);
        }

        // POST: WishListe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WishListeDTO wishListeDTO = db.WishListeDTOes.Find(id);
            db.WishListeDTOes.Remove(wishListeDTO);
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
