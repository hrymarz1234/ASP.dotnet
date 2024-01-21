using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Book 
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł")]
        [StringLength(maximumLength: 50, ErrorMessage = "Tytuł jest za długi, max 50 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Proszę podać imie Autora!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Imie jest za długie, max 50 znaków.")]
        public string Author { get; set; }
       
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Pole musi mieć 13 znaków.")]
        public string ISBN { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PublicationYear { get; set; }

        public string Publisher { get; set; }

        public string PageNumber { get; set; }
        

    }
}
