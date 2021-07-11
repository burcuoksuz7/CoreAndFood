using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace CoreAndFood.Controllers
{
	public class FoodController : Controller
	{
		Context c = new Context();

		FoodRepository foodRepository = new FoodRepository();
		public IActionResult Index(int page=1)
		{
			return View(foodRepository.TList("Category").ToPagedList(page,10));
		}

		[HttpGet]
		public IActionResult FoodAdd()
		{
			List<SelectListItem> values = (from x in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryId.ToString()
										   }).ToList();
			ViewBag.v1 = values;
			return View();
		}

		[HttpPost]
		public IActionResult FoodAdd(Food p)
		{
			foodRepository.TAdd(p);
			return RedirectToAction("Index");
		}

		public IActionResult FoodDelete(int id)
		{
			foodRepository.TDelete(new Food { FoodId = id });
			return RedirectToAction("Index");
		}

		public IActionResult FoodGet(int id)
		{
			var x = foodRepository.TGet(id);
			List<SelectListItem> values = (from y in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = y.CategoryName,
											   Value = y.CategoryId.ToString()
										   }).ToList();
			ViewBag.v1 = values;
			Food f = new Food()
			{
				FoodId = x.FoodId,
				FoodName = x.FoodName,
				FoodDesc = x.FoodDesc,
				Price = x.Price,
				ImgageUrl = x.ImgageUrl,
				Stock = x.Stock,
				CategoryId = x.CategoryId
			};
			return View(f);
		}

		[HttpPost]
		public IActionResult FoodUpdate(Food p)
		{
			var x = foodRepository.TGet(p.FoodId);
			x.FoodName = p.FoodName;
			x.Stock = p.Stock;
			x.Price = p.Price;
			x.ImgageUrl = p.ImgageUrl;
			x.FoodDesc = p.FoodDesc;
			x.CategoryId = p.CategoryId;
			foodRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
	}
}