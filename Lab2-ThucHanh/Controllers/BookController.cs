using Lab2_ThucHanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_ThucHanh.Controllers
{
    public class BookController : Controller
    {

        private List<Book> books;
        
        
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBookModel()
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult EditBook(int id, string Title, string Author, string Img_path)
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Img_path = Img_path;
                    break;
                }
                
            }
            
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id, Title, Author, Img_path")]Book book)
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

        public ActionResult DeleteBook(int id)
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));

            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Delete(int id)
        {
            books = new List<Book>();
            books.Add(new Book(1, "Cho Sua Nham Cay", "Nguyen", "/Content/images/cho-sua-nham-cay.jpg"));
            books.Add(new Book(2, "Cuon theo chieu gio", "Thanh", "/Content/images/cuon-theo-chieu-gio.jpg"));
            books.Add(new Book(3, "Yeu tren tung ngon tay", "Long", "/Content/images/yeu-tren-tung-ngon-tay.jpg"));
            Book b = books.Find(s => s.Id == id);
            books.Remove(b);

            return View("ListBookModel", books);
        }

    }
}