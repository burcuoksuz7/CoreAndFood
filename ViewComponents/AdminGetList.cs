using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
	public class AdminGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AdminRepository adminRepository = new AdminRepository();
			var adminlist = adminRepository.TList();
			return View(adminlist);
		}
	}
}
