using Microsoft.Owin.Security.OAuth;
using RestWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace RestWeb.Provider
{
	public class AppAuthServerProvider : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			using (UserRepo repo = new UserRepo())
			{
				var user = repo.ValidateUser(context.UserName);

				if (user == null) 
				{
					context.SetError("invalid_grant", "Username is incorrect!");
					return;
				}
				var identity = new ClaimsIdentity(context.Options.AuthenticationType);
				identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

				context.Validated(identity);
			}
		}
	}
}