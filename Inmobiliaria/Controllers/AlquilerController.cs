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
    public class AlquilerController : Controller
    {

		IRepositorio<Alquiler> repositorio;
		private readonly IRepositorio<Inquilino> repoInquilino;
		private readonly IRepositorioInmueble repoInmueble;
		private readonly IConfiguration config;

		public AlquilerController(IRepositorio<Alquiler> repositorio, IRepositorio<Inquilino> repoInquilino, IRepositorioInmueble repoInmueble)
		{
			this.repositorio = repositorio;
			this.repoInquilino = repoInquilino;
			this.repoInmueble = repoInmueble;
			this.config = config;
		}

		// GET: Alquiler
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

        // GET: Alquiler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// GET: Alquiler/Create
		[Authorize(Policy = "Administrador")]
		public ActionResult Create()
        {
			ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
			ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
			return View();
		}

		// POST: Alquiler/Create
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alquiler alquiler)
        {
			try
			{

				if (ModelState.IsValid)
				{
					repositorio.Alta(alquiler);
					TempData["IdAlquiler"] = alquiler.IdAlquiler;
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

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int id)
        {
			var entidad = repositorio.ObtenerPorId(id);
			ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
			ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			if (TempData.ContainsKey("Error"))
				ViewBag.Error = TempData["Error"];
			return View(entidad);
		}

        // POST: Alquiler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Alquiler entidad)
        {
			try
			{
				entidad.IdAlquiler = id;
				repositorio.Modificacion(entidad);
				TempData["Mensaje"] = "Datos guardados correctamente";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
				ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View(entidad);
			}
		}

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int id)
        {
			var entidad = repositorio.ObtenerPorId(id);
			ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
			ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			if (TempData.ContainsKey("Error"))
				ViewBag.Error = TempData["Error"];
			return View(entidad);
		}

        // POST: Alquiler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Alquiler entidad)
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