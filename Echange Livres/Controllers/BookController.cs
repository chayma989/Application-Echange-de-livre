using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private BookService Bservice = new BookService(new BookRepository());
        private MyContext context = new MyContext();

        public ActionResult Index()
        {
            List<Book> lstBook = Bservice.GetAll();
            return View(lstBook);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

             Book b = new Book();
             b.Photo = book.Title + Path.GetExtension(file.FileName);
             file.SaveAs(Server.MapPath("~/Content/BookImages/" + b.Photo));

            b.Title = book.Title;
            b.Price =Convert.ToDouble(book.Title);
            b.PointValue = book.PointValue;
            b.Collection = book.Collection;
            b.Editor = book.Title;
            b.Title = book.Editor;
            b.SubTitle = book.SubTitle;
            b.Description = book.Description;
            b.EditionDate = book.EditionDate;
            b.OwnerId = book.OwnerId;
            b.BookState = book.BookState;
            b.Authors = book.Authors;
            b.Categories = book.Categories;

            Bservice.Add(b);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "Id,Title")] Book book)
        {
            if (ModelState.IsValid)
            {
                Bservice.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        
        public ActionResult Search(string search)
        {
            List<Book> lstBook = Bservice.Search(search);
            return View(lstBook);
        }

    }
}