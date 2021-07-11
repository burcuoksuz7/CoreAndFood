using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class AdminController : Controller
	{
		AdminRepository adminRepository = new AdminRepository();

		//[Authorize]
		//Projede 100 tane controller var ise 100 tane 
		//authorize yazmamak için bu işlemi proje seviyesine çıkarmak gerekir.

		public IActionResult Index()
		{
			return View(adminRepository.TList());
		}

		[HttpGet]
		public IActionResult AdminAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AdminAdd(Admin p)
		{
			if (!ModelState.IsValid)
			{
				return View("AdminAdd");
			}
			adminRepository.TAdd(p);
			return RedirectToAction("Index");
		}


		public IActionResult AdminGet(int id)
		{
			var x = adminRepository.TGet(id);
			Admin ct = new Admin()
			{
				UserName = x.UserName,
				AdminRole = x.AdminRole,
				Password = x.Password,
				AdminId=x.AdminId				
			};
			return View(ct);
		}

		[HttpPost]
		public IActionResult AdminUpdate(Admin p)
		{
			var x = adminRepository.TGet(p.AdminId);
			x.UserName = p.UserName;
			x.AdminRole = p.AdminRole;
			x.Password = p.Password;
			adminRepository.TUpdate(x);
			return RedirectToAction("Index");
		}

		public IActionResult AdminDelete(int id)
		{
			adminRepository.TDelete(new Admin { AdminId = id });
			return RedirectToAction("Index");
		}
	}
}