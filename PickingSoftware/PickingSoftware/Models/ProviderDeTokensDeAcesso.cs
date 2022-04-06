using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(PickingSoftware.Models.ProviderDeTokensDeAcesso))]

namespace PickingSoftware.Models
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Models.Utilizador _user = new Utilizador()
            {
                Nome = context.UserName,
                Password = context.Password,
            };

            if (Utilizador.UserLogin(_user))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                return;
            }
        }
    }
}
