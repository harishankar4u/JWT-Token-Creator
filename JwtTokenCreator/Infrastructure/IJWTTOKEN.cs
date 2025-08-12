namespace JwtTokenCreator.Infrastructure
{
    public interface IJWTTOKEN
    {
        Task<string> CreateTokenAsync(string secretKey, string issuer, string audience);
    }
}
