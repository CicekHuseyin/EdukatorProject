using Edukator.BusinessLayer.Abstract;
using Edukator.BusinessLayer.Concrete;
using Edukator.DataAccessLayer.Abstract;
using Edukator.DataAccessLayer.Concrete;
using Edukator.DataAccessLayer.EntityFreamework;
using Edukator.EntityLayer.Concreate;
using Edukator.PresentationLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Layer
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
			services.AddScoped<ICategoryDal, EfCategoryDal>();
			services.AddScoped<ICategoryService,CategoryManager>();

			services.AddScoped<ICourseDal, EfCourseDal>();
			services.AddScoped<ICourseService, CourseManager>();

			services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
			services.AddScoped<ISocialMediaService, SocialMediaManager>();

			services.AddScoped<IFeatureDal, EfFeatureDal>();
			services.AddScoped<IFeatureService, FeatureManager>();

			services.AddScoped<IAboutGridDal, EfAboutGridDal>();
			services.AddScoped<IAboutGridService, AboutGridManager>();

			services.AddScoped<IMailSubscribeDal, EfMailSubscribeDal>();
			services.AddScoped<IMailSubscribeService, MailSubscribeManager>();

			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();
			//Identity de sadece ilişkili eklediğimiz tabloları ekledim.(Appuser,approle)

			services.AddControllersWithViews();
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
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
