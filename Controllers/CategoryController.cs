using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
		CategoryRepository categoryRepository = new CategoryRepository();

		//[Authorize]
		//Projede 100 tane controller var ise 100 tane 
		//authorize yazmamak için bu işlemi proje seviyesine çıkarmak gerekir.

		public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }

		[HttpGet]
		public IActionResult CategoryAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CategoryAdd(Category p)
		{
			if (!ModelState.IsValid)
			{
				return View("CategoryAdd");
			}
			categoryRepository.TAdd(p);
			return RedirectToAction("Index");
		}


		public IActionResult CategoryGet(int id)
		{
			var x = categoryRepository.TGet(id);
			Category ct = new Category()
			{
				CategoryName=x.CategoryName,
				CategoryDesc=x.CategoryDesc,
				Status=x.Status,
				CategoryId=x.CategoryId
			};
			return View(ct);
		}

		[HttpPost]
		public IActionResult CategoryUpdate(Category p)
		{
			var x = categoryRepository.TGet(p.CategoryId);
			x.CategoryName = p.CategoryName;
			x.CategoryDesc = p.CategoryDesc;
			x.Status = true;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}

		public IActionResult CategoryDelete(int id)
		{
			var x = categoryRepository.TGet(id);
			x.Status = false;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
	}
}