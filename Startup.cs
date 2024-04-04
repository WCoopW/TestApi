using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RestWeb.Provider;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(RestWeb.Startup))]

namespace RestWeb
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

			OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions 
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				Provider = new AppAuthServerProvider()
			};
			app.UseOAuthAuthorizationServer(options);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
			var config = new HttpConfiguration();
			WebApiConfig.Register(config);

		}
	}
}
