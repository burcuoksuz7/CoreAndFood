using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class ChartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Index2()
		{
			return View();
		}
		public IActionResult VisualizeProductResult()
		{
			return Json(ProList());
		}
		public List<Class1> ProList()
		{
			List<Class1> cs1 = new List<Class1>();
			using (var c = new Context())
			{
				cs1 = c.Foods.Select(x => new Class1
				{
					proname = x.FoodName,
					stock = x.Stock
				}).ToList();
			}
			return cs1;
		}


		public IActionResult Index3()
		{
			return View();
		}

		public IActionResult VisualizeProductResult2()
		{
			return Json(FoodList());
		}
		public List<Class2> FoodList()
		{
			List<Class2> cs2 = new List<Class2>();
			using (var c = new Context())
			{
				cs2 = c.Foods.Select(x => new Class2
				{
					name = x.FoodName,
					foodstock = x.Stock
				}).ToList();
			}
			return cs2;
		}

		public IActionResult Statistics()
		{
			Context c = new Context();

			var value1 = c.Foods.Count();
			ViewBag.v1 = value1;

			var value2 = c.Categories.Count();
			ViewBag.v2 = value2;

			var value3 = c.Foods.Where(x => x.CategoryId == 2).Count();
			ViewBag.v3 = value3;

			var value4 = c.Foods.Where(x => x.CategoryId == 1).Count();
			ViewBag.v4 = value4;

			var value5 = c.Foods.Where(x => x.CategoryId == 4).Count();
			ViewBag.v5 = value5;

			var value6 = c.Foods.Where(x => x.CategoryId == 3).Count();
			ViewBag.v6 = value6;

			var value7 = c.Foods.Where(x => x.CategoryId == 5).Count();
			ViewBag.v7 = value7;

			var value8 = c.Foods.Sum(x => x.Stock);
			ViewBag.v8 = value8;

			var value9 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
			ViewBag.v9 = value9;

			var value10 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
			ViewBag.v10 = value10;

			var value11 = c.Foods.Average(x => x.Price);
			ViewBag.d11 = value11;

			var value12 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
			var value12p = c.Foods.Where(y => y.CategoryId == value12).Sum(x => x.Stock);
			ViewBag.v12 = value12p;

			var value13 = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryId).FirstOrDefault();
			var value13p = c.Foods.Where(y => y.CategoryId == value13).Sum(x => x.Stock);
			ViewBag.v13 = value13p;

			var value14 = c.Categories.Where(x => x.CategoryName == "Grains").Select(y => y.CategoryId).FirstOrDefault();
			var value14p = c.Foods.Where(y => y.CategoryId == value14).Sum(x => x.Stock);
			ViewBag.v14 = value14p;

			var value15 = c.Categories.Where(x => x.CategoryName == "Alcohol-Free Beverage").Select(y => y.CategoryId).FirstOrDefault();
			var value15p = c.Foods.Where(y => y.CategoryId == value15).Sum(x => x.Stock);
			ViewBag.v15 = value15p;

			var value16 = c.Categories.Where(x => x.CategoryName == "Alcoholic Beverage").Select(y => y.CategoryId).FirstOrDefault();
			var value16p = c.Foods.Where(y => y.CategoryId == value16).Sum(x => x.Stock);
			ViewBag.v16 = value16p;

			return View();
		}

	}
}