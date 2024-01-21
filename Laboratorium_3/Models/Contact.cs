using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium_3.Models
{
    public enum Priority
    {
        [Display(Name = "Niski")] Low = 1,
        [Display(Name = "Normalny")] Normal = 2,
        [Display(Name = "Wysoki")] High = 3,
        [Display(Name = "Pilny")] Urgent = 4
    }
    public class Contact
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Musisz podac imie")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

        public int? OrganizationId { get; set; }
        [ValidateNever]
        public List<SelectListItem> OrganizationList { get; set; }



    }

}
