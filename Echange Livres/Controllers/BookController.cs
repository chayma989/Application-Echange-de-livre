using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Echange_Livres.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private BookService Bservice = new BookService(new BookRepository(new MyContext()));
        private BookExchangeService bookEx = new BookExchangeService(new BookExchangeRepository(new MyContext()));

        private MyContext context = new MyContext();

        public ActionResult Index(string sortBy, string search, int page = 0)
        {
            List<Book> lstBook = Bservice.GetAll();

            page = (page < 0) ? 0 : page;
            int pageSize = 2;
            int totalPages = 0;
            if ((lstBook.Count() % pageSize) == 0)
            {
                totalPages = lstBook.Count() / pageSize;
            }
            else
            {
                totalPages = (lstBook.Count() / pageSize) + 1;
            }

            lstBook = lstBook.Skip(pageSize * page).Take(pageSize).ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.Page = page + 1;
            ViewBag.PreviousPage = page - 1;

            if (lstBook.Count() < pageSize)
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
                lstBook = lstBook.Where(b => b.Title.Contains(search)).ToList();
            }

            //Tri
            switch (sortBy)
            {
                case "nameAsc":
                    lstBook = lstBook.OrderBy(b => b.Title).ToList();
                    break;
                case "nameDesc":
                    lstBook = lstBook.OrderByDescending(b => b.Title).ToList();
                    break;
                case null:
                    break;
            }
            return View(lstBook);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Photo")]  Book book, HttpPostedFileBase file)
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
            Bservice.Delete(book);
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

        public ActionResult Details(int? id)
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

       public ActionResult calculPoints()
        {
            Book book = new Book();

            if(book.BookState==BookState.VERY_GOOD)
            {
                book.PointValue += 10;
                ViewBag.Message = "you erned " + book.PointValue;
            }
            if (book.BookState == BookState.GOOD)
            {
                book.PointValue += 5;
                ViewBag.Message = "you erned " + book.PointValue;
            }
            if (book.BookState == BookState.MEDIOCRE)
            {
                book.PointValue += 2;
                ViewBag.Message = "you erned " + book.PointValue;
            }
            else
            {
              book.PointValue = 0;
               ViewBag.Message = "you erned 0 points";
            }
            return View(book);

        }

        public ActionResult Exchange(int id, Book b)
        {
            Book book = Bservice.FindById(id);

            if(b!=null || id!=null)
            {
                bookEx.ValidateExchange(b, id);
                ViewBag.Message = "Book Exchanged";
            }
            return RedirectToAction("Exchange");

        }
            

          
        }

    }
