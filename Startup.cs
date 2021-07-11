using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CoreAndFood
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddAuthentication(
				CookieAuthenticationDefaults.AuthenticationScheme).
				AddCookie(x =>
				{
					x.LoginPath = "/Default/Index/";
				});

			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder().
							   RequireAuthenticatedUser().     //authorize işlemini controller seviyesine çıkarır.
							   Build();							//bütün controllerlara uygulanır, login sayfasını işlem dışı bırakmak gerekir.
				config.Filters.Add(new AuthorizeFilter(policy));
			});
		}
		//eğer kişi sistemde yetkili değilse ve yetki gerektiren
		//sayfaya erişim saylamaya çalışıyorsa 
		//kişiye hata vermek yerine kişiyi Index sayfasına gönderir.

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("Hello World!");
			//});

			app.UseStaticFiles();
			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Category}/{action=Index}/{id?}");
			});
		}
	}
}
