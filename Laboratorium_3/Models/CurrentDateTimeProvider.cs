using Laboratorium_3.Services.Interfaces;

namespace Laboratorium_3.Models
{
    public class CurrentDateTimeProvider : IDataTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
