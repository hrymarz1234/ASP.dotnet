using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium_3.Models
{
    public class Contact : Controller
    {
        public enum Priority
        {
            Low = 1,
            Normal = 2,
            High = 3,
            Urgent = 4
        }
    }
}
