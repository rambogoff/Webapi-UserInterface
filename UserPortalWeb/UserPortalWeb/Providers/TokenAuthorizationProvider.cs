using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserPortalWeb.Models;

namespace UserPortalWeb.Providers
{
    public class TokenAuthorizationProvider: OAuthAuthorizationServerProvider    
    {
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = new User();
            context.OwinContext.Response.Headers.Add("Acces-Control-Allow-Orijin", new[] { "*" });

            using (var db = new Context())
            {
                user = db.Users.SingleOrDefault(x => x.Mail == context.UserName && x.Password == context.Password);
            }

            if(user != null)
            {
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Kullanıcı adı veya sifre yanlis");
            }


       
        }
    }
}