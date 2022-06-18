namespace BuberDinner.Infra.Authentication
{
    public class JwtSettings
    {
        public const string Section = "JwtSettings";
        public string Secret { get; init; } = null!;
        public int ExpireMinutes { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}