using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
	public class Food
	{
		public int FoodId { get; set; }
		public string FoodName { get; set; }
		public string FoodDesc { get; set; }
		public double Price { get; set; }
		public string ImgageUrl { get; set; }
		public int Stock { get; set; }

		public int CategoryId { get; set; } //bir food sadece bir kategoride olabilir.
		public virtual Category Category { get; set; }
	}
}
