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
    public class InquilinosController : Controller
    {

		 IRepositorio<Inquilino> repositorio;
		private readonly IConfiguration config;

		public InquilinosController(IRepositorio<Inquilino> repositorio)
		{
			this.repositorio = repositorio;
			this.config = config;
		}
		// GET: Inquilinos
		[Authorize(Policy = "Administrador")]
		public ActionResult Index()
        {
			var lista = repositorio.ObtenerTodos();
			if (TempData.ContainsKey("IdAlquiler"))
				ViewBag.Id = TempData["IdAlquiler"];





			return View(lista);
		}

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// GET: Inquilinos/Create
		[Authorize(Policy = "Administrador")]
		public ActionResult Create()
        {
            return View();
        }

		// POST: Inquilinos/Create
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
			try
			{
				
				if (ModelState.IsValid)
				{
					repositorio.Alta(inquilino);
					TempData["IdAlquiler"] = inquilino.IdInquilino;
					return RedirectToAction(nameof(Index));
				}
				else
					return View();
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View();
			}
		}

		// GET: Inquilinos/Edit/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Edit(int id)
        {
			var p = repositorio.ObtenerPorId(id);
			return View(p);
		}

		// POST: Inquilinos/Edit/5
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
			Inquilino p = null;
			try
			{
				p = repositorio.ObtenerPorId(id);
				p.Nombre = collection["Nombre"];
				p.Apellido = collection["Apellido"];
				p.Dni = Convert.ToInt32(collection["Dni"]);
				p.Email = collection["Email"];
				p.Telefono = Convert.ToInt32(collection["Telefono"]);
				p.Direccion = collection["Direccion"];
				repositorio.Modificacion(p);
				TempData["Mensaje"] = "Datos guardados correctamente";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View(p);
			}
		}

		// GET: Inquilinos/Delete/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Delete(int id)
        {
			var p = repositorio.ObtenerPorId(id);
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			if (TempData.ContainsKey("Error"))
				ViewBag.Error = TempData["Error"];
			return View(p);
		}

		// POST: Inquilinos/Delete/5
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilino entidad)
        {
			try
			{
				repositorio.Baja(id);
				TempData["Mensaje"] = "Eliminación realizada correctamente";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View(entidad);
			}
		}
    }
}