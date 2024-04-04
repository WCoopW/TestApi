using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using RestWeb.DB;
using RestWeb.Models;

namespace RestWeb.Service
{
    public class UserRepo : IDisposable
    {
        UserDbContext _db = new UserDbContext();

		public User ValidateUser(string userDomainName)
        {
                return _db.Users.FirstOrDefault(user =>
                user.UserDomainName.Equals(userDomainName, StringComparison.OrdinalIgnoreCase)
            );
        }
		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
