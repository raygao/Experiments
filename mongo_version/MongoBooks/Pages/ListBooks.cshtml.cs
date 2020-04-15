using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using BooksApi.Models;
using BooksApi.Services;

namespace BooksApi
{
    public class ListBooksModel : PageModel
    {
        private readonly BookService _service;

        [BindProperty]
        public string myTitle { get; set; }
        public ListBooksModel(BookService service)
        {
            _service = service;
        }

        public IList<Book> BookList { get;set; }

        public void  OnGet()
        {
            BookList = _service.Get().ToList();
        }

        public void OnPostFindTitle()
        {
            myTitle = (myTitle == null) ? "" : myTitle;
            BookList = _service.FindByTitle(myTitle).ToList();
        }
    }
}
