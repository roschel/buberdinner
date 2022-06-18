namespace BuberDinner.Contracts.Authentication
{
    public record AutheticationResponse
    (
        Guid Id,
        string Email,
        string Token,
        string FirstName,
        string LastName
    );
}