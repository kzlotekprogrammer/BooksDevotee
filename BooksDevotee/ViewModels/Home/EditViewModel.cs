using BooksDevotee.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.ViewModels.Home
{
    public class EditViewModel
    {
        public Book Book { get; set; }

        [Display(Name = "Zdjęcie")]
        public IFormFile FormFile { get; set; }
    }
}
