using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Controllers
{
    public class PagosController : Controller
    {

		private readonly IRepositorioPago repositorio;
		private readonly IRepositorio<Alquiler> repoAlquiler;
		private readonly IConfiguration config;

		public PagosController(IRepositorioPago repositorio, IRepositorio<Alquiler> repoAlquiler)
		{
			this.repositorio = repositorio;
			this.repoAlquiler = repoAlquiler;
			this.config = config;
		}

		// GET: Pagos
		[Authorize(Policy = "Administrador")]
		public ActionResult Index()
        {
			var lista = repositorio.ObtenerTodos();
			if (TempData.ContainsKey("IdAlquiler"))
				ViewBag.Id = TempData["IdAlquiler"];
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			return View(lista);
		}

        // GET: Pagos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// GET: Pagos/Create
		[Authorize(Policy = "Administrador")]
		public ActionResult Create()
        {
			ViewBag.Alquileres = repoAlquiler.ObtenerTodos();
			return View();
		}

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Policy = "Administrador")]
		public ActionResult Create(Pago entidad)
        {
			try
			{
				if (ModelState.IsValid)
				{
					repositorio.Alta(entidad);
					TempData["IdAlquiler"] = entidad.Id;
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.Alquileres = repoAlquiler.ObtenerTodos();
					return View(entidad);
				}
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View(entidad);
			}
		}

		[Authorize(Policy = "Administrador")]
		public ActionResult ListaPagos(int id) 
		{
			var lista = repositorio.BuscarPorAlquiler(id);
			if (TempData.ContainsKey("IdAlquiler"))
				ViewBag.Id = TempData["IdAlquiler"];
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			return View(lista);
		}

        // GET: Pagos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}