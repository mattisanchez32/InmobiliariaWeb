﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Inmobiliaria
{
	public class Startup
	{
		private readonly IConfiguration configuration;
		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/Home/Login";
					options.LogoutPath = "/Home/Logout";
					options.AccessDeniedPath = "/Home/Restringido";
				})
				.AddJwtBearer(options =>//la api web valida con token
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = configuration["TokenAuthentication:Issuer"],
						ValidAudience = configuration["TokenAuthentication:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(configuration["TokenAuthentication:SecretKey"])),
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
				options.AddPolicy("Propietario", policy => policy.RequireClaim(ClaimTypes.Role, "Propietario"));
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddTransient<IRepositorio<Propietario>, RepositorioPropietario>();
			services.AddTransient<IRepositorioPropietario, RepositorioPropietario>();
			services.AddTransient<IRepositorio<Inquilino>, RepositorioInquilino>();
			services.AddTransient<IRepositorio<Alquiler>, RepositorioAlquiler>();
			services.AddTransient<IRepositorioInmueble, RepositorioInmueble>();
			services.AddTransient<IRepositorioPago, RepositorioPago>();

			services.AddDbContext<DataContext>(
				options => options.UseSqlServer(
					configuration["ConnectionStrings:DefaultConnection"]));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			// Permitir cookies
			app.UseCookiePolicy(new CookiePolicyOptions
			{
				MinimumSameSitePolicy = SameSiteMode.None,
			});
			// Habilitar autenticación
			app.UseAuthentication();

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

			// App en ambiente de desarrollo?
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();//página amarilla de errores
			}
			app.UseMvc(routes =>
			{
				/*routes.MapRoute(
					name: "login",
					template: "login/{**accion}",
					defaults: new { controller = "Home", action = "Login" });*/
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
