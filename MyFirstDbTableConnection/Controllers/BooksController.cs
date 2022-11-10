﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDbTableConnection.Data;
using MyFirstDbTableConnection.Models;
using MyFirstDbTableConnection.Models.Entity;

namespace MyFirstDbTableConnection.Controllers
{
    public class BooksController : Controller
    {
        private BookstoreDbContext context;

        public BooksController(BookstoreDbContext context)
        {
            this.context = context;
        }

        // GET: BooksController
        public ActionResult Index()
        {
            List<BookViewModel> listOfBooksWithCategories = new List<BookViewModel>();

            List<Book> books = context.Books.ToList();

            foreach (Book book in books)
            {
                List<BookCategories> bookCategories = context.BookCategories.Where(bc => bc.BookID == book.BookID).ToList();
                List<BookCategories> bookCategories1 = 
                      (from BookCategories in context.BookCategories
                      where BookCategories.BookID == book.BookID
                      select BookCategories).ToList();

                List <Category> listOfCategories = new List<Category>();

                foreach (BookCategories bookCategory in bookCategories)
                {
                    listOfCategories.Add(context.Categories.FirstOrDefault(c => c.CategoryID == bookCategory.CategoryID));
                }

                listOfBooksWithCategories.Add(new BookViewModel(book, listOfCategories));
            }

            return View(listOfBooksWithCategories);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
