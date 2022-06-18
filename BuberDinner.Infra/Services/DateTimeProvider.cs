using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Infra.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}