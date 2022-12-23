using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class BookExchangeController : Controller
    {
        private BookExchangeService bookEx = new BookExchangeService(new BookExchangeRepository(new MyContext()));
        private MyContext context = new MyContext();
        // GET: BookExchange
        public ActionResult Index()
        {
            List<BookExchange> lstEx = bookEx.GetAll();
            return View(lstEx);
        }

        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,CreationDate")] BookExchange bookex)
        {
            if (ModelState.IsValid)
            {
                bookEx.SaveAndUpdate(bookex);
                return RedirectToAction("Index");
            }

            return View(bookex);
        }
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,CreationDate")] BookExchange bookex)
        {
            if (ModelState.IsValid)
            {
                bookEx.SaveAndUpdate(bookex);
                return RedirectToAction("Index");
            }
            return View(bookex);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookExchange bookExchange = context.BookExchanges.Find(id);

            if (bookExchange == null)
            {
                return HttpNotFound();
            }
            return View(bookExchange);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookExchange bookex = context.BookExchanges.Find(id);
            bookEx.Delete(bookex);
            return RedirectToAction("Index");
        }


    }
}