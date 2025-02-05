using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectPortfolio
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{   
			services.AddDbContext<Context>();
			services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
			//Register iþleminde Identity tarafýnda hata almamamak için bunun üstündeki iþlemleri
			//tanýmlaman gerekiyor
			services.AddControllersWithViews();

			//Authorize ve Auhentication iþlemleri
			services.AddMvc(config=>
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				                                             //sisteme authentica olan kullanýcý gerekli
				config.Filters.Add(new AuthorizeFilter(policy));
			});
			services.AddMvc();
			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(100);//authontice olan kiþi 10dk sistemde kalabilir
				options.LoginPath = "/User/Login/Index/";
				//sisteme authentica olamayan kullanýcýnýn yönlendirileceði adres
				//yani giriþ yapmayan kullanýcýnýn yönlendirileceði adres
				options.AccessDeniedPath = "/ErrorPage/Index/";
				//ilgili sayfalara eriþimi olan kiþilerin haricindeki kullanýclarýn yönlendirileciði
				//sayfadýr.Örneðin,adminin eriþebileceði yetkili olduðu sayfaya yazar eriþim saðlayamaz
				//o sayfaya girdiði anda accesdeniedpath'e tanýmladýðým sayfaya yönlendirir.
				
            });
			//services.AddAuthentication(
			//	CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
			//	{
			//		x.LoginPath = "/AdminLoginController/Index/";
			//		//sisteme authentica olamayan kullanýcýnýn yönlendirileceði adres
			//		//yani giriþ yapmayan kullanýcýnýn yönlendirileceði adres
			//	});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");//Hata sayfalarýmda yönlendirilecek view
			
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthentication();//authorize konulan viewlerde giriþ yapýldýðý zaman o sayfalara 
			                        //eriþim saðlamak için kullanýyoz

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Default}/{action=Index}/{id?}");
			});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
                );
            });

        }
    }
}
