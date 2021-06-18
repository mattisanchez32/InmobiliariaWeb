using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {

		private readonly IRepositorioInmueble repositorio;
		private readonly IRepositorioPropietario repoPropietario;

		public InmueblesController(IRepositorioInmueble repositorio, IRepositorioPropietario repoPropietrio)
		{
			this.repositorio = repositorio;
			this.repoPropietario = repoPropietrio;
		}
		// GET: Inmuebles
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

		// GET: Inmuebles/Details/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Details(int id)
        {
            return View();
        }

		// GET: Inmuebles/Create
		[Authorize(Policy = "Administrador")]
		public ActionResult Create()
        {
			ViewBag.Propietarios = repoPropietario.ObtenerTodos();
			return View();
		}

		// POST: Inmuebles/Create
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble entidad)
        {
			try
			{
				if (ModelState.IsValid)
				{
					repositorio.Alta(entidad);
					TempData["IdAlquiler"] = entidad.IdInmueble;
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.Propietarios = repoPropietario.ObtenerTodos();
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

		// GET: Inmuebles/Edit/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Edit(int id)
        {
			var entidad = repositorio.ObtenerPorId(id);
			ViewBag.Propietarios = repoPropietario.ObtenerTodos();
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			if (TempData.ContainsKey("Error"))
				ViewBag.Error = TempData["Error"];
			return View(entidad);
		}

		// POST: Inmuebles/Edit/5
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble entidad)
        {
			try
			{
				entidad.IdInmueble = id;
				repositorio.Modificacion(entidad);
				TempData["Mensaje"] = "Datos guardados correctamente";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Propietarios = repoPropietario.ObtenerTodos();
				ViewBag.Error = ex.Message;
				ViewBag.StackTrate = ex.StackTrace;
				return View(entidad);
			}
		}

		// GET: Inmuebles/Delete/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Delete(int id)
        {
			var entidad = repositorio.ObtenerPorId(id);
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			if (TempData.ContainsKey("Error"))
				ViewBag.Error = TempData["Error"];
			return View(entidad);
		}

		// POST: Inmuebles/Delete/5
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble entidad)
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