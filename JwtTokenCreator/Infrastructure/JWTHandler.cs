using MediatR;

namespace JwtTokenCreator.Infrastructure
{
    public record GetTokenQuery():IRequest<string>;
    public class JWTHandler:IRequestHandler<GetTokenQuery,string>
    {
        private readonly IJWTTOKEN _jWTTOKEN;
        public JWTHandler(IJWTTOKEN jWTTOKEN)
        {
            _jWTTOKEN = jWTTOKEN;
        }
        public async Task<string> Handle(GetTokenQuery value, CancellationToken cancellationToken)
        {
            var secretKey = "1MmKuV1sSHzMoiPkx1bKfpAzbLdwGVZ4"; //it is the key you have to replace it
            var issuer = "www.google.com"; //it is the issuer you have to replace it
            var audience = "www.myhraki.com"; //it is the audience you have to replace it
            var resp = await _jWTTOKEN.CreateTokenAsync(secretKey, issuer, audience);
            return resp;
        }
    }
}
