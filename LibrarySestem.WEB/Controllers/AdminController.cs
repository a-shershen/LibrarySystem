using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibrarySestem.WEB.Mappers;

namespace LibrarySestem.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private BLL.Interfaces.IBookService bookService;

        private BLL.Interfaces.ILibraryService libService;

        private BLL.Interfaces.IReaderService readerService;
        

        public AdminController(BLL.Interfaces.ILibraryService libService,
            BLL.Interfaces.IBookService bookService,
            BLL.Interfaces.IReaderService readerService)
        {
            this.libService = libService;
            this.bookService = bookService;
            this.readerService = readerService;
        }

        public ActionResult ControlPanel()
        {
            return View();
        }

        
        public ActionResult BooksPanel()
        {
            if(Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return null;
            }
        }

        public PartialViewResult ShowBooks()
        {
            return PartialView("ShowBooks", bookService.GetAllBooks().ToView());
        }

        public PartialViewResult AddNewBook()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddNewBook(Models.AddBookModel book)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    bookService.AddNewBook(book.ToDto());
                    return RedirectToAction("ShowBooks");
                }
                else
                {
                    return PartialView(book);
                }
            }
            else
            {
                return null;
            }
        }

        public ActionResult ReadersPanel()
        {
            if(Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return null;
            }
        }

        public ActionResult ShowReaders()
        {
            if(Request.IsAjaxRequest())
            {
                return PartialView("ShowReaders", readerService.GetAll().ToView());
            }
            else
            {
                return null;
            }
        }

        public ActionResult AddNewReader()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddNewReader(Models.AddNewReader reader)
        {
            if(Request.IsAjaxRequest())
                {
                if(ModelState.IsValid)
                {
                    readerService.AddNewReader(reader.ToDto());
                    return RedirectToAction("ShowReaders");
                }
                else
                {
                    return PartialView(reader);
                }
            }
            else
            {
                return null;
            }
        }

        public ActionResult LibraryPanel()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return null;
            }
        }

        public ActionResult ShowLibrary()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("ShowLibrary", libService.GetAllBooks().ToView());
            }
            else
            {
                return null;
            }
        }

        public ActionResult ShowReaderRecord()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("ShowReaderRecord", readerService.GetAll().ToView());
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult ShowReaderBooks(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("ShowReaderBooks", libService.GetAllUserBooks(id).ToView());
            }
            else
            {
                return null;
            }
        }

        public ActionResult ShowNotReturnedReaderBooks(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("ShowReaderBooks", libService.GetAllNotReturnedUserBooks(id).ToView());
            }
            else
            {
                return null;
            }
        }

        public ActionResult GiveBookForUser()
        {
            return PartialView();
        }
    }

}