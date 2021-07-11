using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Category name cannot be empty.")]
		public string CategoryName { get; set; }
		public string CategoryDesc { get; set; }
		public bool Status { get; set; }



		public List<Food> Foods { get; set; }  //list burada olduğuna göre bir kategorinin içerisinde birden fazla foods yer alabilir.
	}
}
