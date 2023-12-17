using System.Xml.Linq;

namespace Laboratorium_2.Models
{
    public class Birth
    {
        public string? Imie { get; set; }
        public DateTime DataUr { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Imie) && DataUr<DateTime.Now;
        }
        public int birth() 
        { 
            var dzisiejsza = DateTime.Now;
            var wiek = dzisiejsza.Year- DataUr.Year;
            if (DataUr.Date > dzisiejsza.Date.AddYears(-wiek))
                wiek--;
            return wiek;
        }
    }
}
