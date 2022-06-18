namespace BuberDinner.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string Token,
        string FirstName,
        string LastName,
        string Email);

}