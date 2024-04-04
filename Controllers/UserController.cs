using Newtonsoft.Json;
using RestWeb.DB;
using RestWeb.Methods;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;


namespace RestWeb.Controllers
{
    public class UserController : ApiController
    {
        UserDbContext _db = new UserDbContext();
        [Authorize]
        [Route("api/lastrade")]
        public HttpResponseMessage GetLastTrade()
        {
			var userName = User.Identity.Name;
            // Распарсим токен с помощью JwtSecurityTokenHandler

            var user = _db.Users.FirstOrDefault(u => u.UserDomainName == userName);
            var id = user?.Id;
            var lastTrade = TradeMethods.GetMaxAmountByUser(id);
           
			
			return Request.CreateResponse(HttpStatusCode.OK, lastTrade);
            //return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    
    }
}