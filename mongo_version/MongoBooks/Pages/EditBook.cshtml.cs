using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using BooksApi.Models;
using BooksApi.Services;

namespace BooksApi
{
    public class EditBookModel : PageModel
    {
        private readonly BookService _service;

        public EditBookModel(BookService service)
        {
            _service = service;
        }

        [BindProperty]
        public Book Book { get; set; }

        public string ID { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _service.Get().Find(x => x.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            ID = id;
            return Page();
        }

        public IActionResult OnPost()
        {
            _service.Update(Book.Id, Book);            

            return RedirectToPage("./ListBooks");
        }

    }
}
