using Microsoft.Owin.Security.OAuth;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PickingSoftware.App_Start
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            Models.Utilizador _user = new Models.Utilizador()
            {
                Nome = context.UserName,
                Password = context.Password
            };

            var test = Models.Utilizador.UserLogin(_user);

            Debug.WriteLine("");
            Debug.WriteLine(test.ToString());
            Debug.WriteLine("");

            if (test)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Geral"));
                identity.AddClaim(new Claim("Password", context.Password));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                context.Validated(identity);
            }

            else
            {
                context.SetError("invalid_grant", "Credenciais incorretas");

                return;
            }
        }
    }
}
