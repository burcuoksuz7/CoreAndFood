using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }

		[StringLength(30)]
		public string UserName { get; set; }

		[StringLength(10)]
		public string Password { get; set; }

		[StringLength(1)]  //a ise ... b ise ... gibi
		public string AdminRole { get; set; }
	}
}
