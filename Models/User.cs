using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestWeb.Models
{
	[Table("Users")]
	public class User
	{
        public Guid Id { get; set; }
        public string UserDomainName { get; set; }
    }
}