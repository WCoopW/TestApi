using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestWeb.Models
{
    [Table("UserData")]
	public class UserData
	{
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Entity { get; set; }
    }
}