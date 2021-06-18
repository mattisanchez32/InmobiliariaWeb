using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {

		IRepositorio<Propietario> repositorio;
		private readonly IConfiguration config;
		

		public PropietariosController(IRepositorio<Propietario> repositorio)
		{
			this.repositorio = repositorio;
			this.config = config;

		}


		// GET: Propietario
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

        // GET: Propietario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// GET: Propietario/Create
		[Authorize(Policy = "Administrador")]
		public ActionResult Create()
        {
            return View();
        }

		// POST: Propietario/Create
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Propietario propietario)
        {
			try
			{


				if (ModelState.IsValid)
				{


					propietario.Clave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
						password: propietario.Clave,
						salt: System.Text.Encoding.ASCII.GetBytes("SALADA"),
						prf: KeyDerivationPrf.HMACSHA1,
						iterationCount: 1000,
						numBytesRequested: 256 / 8));


					repositorio.Alta(propietario);
					TempData["IdAlquiler"] = propietario.IdPropietario;
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

		// GET: Propietario/Edit/5
		[Authorize(Policy = "Administrador")]
		public ActionResult Edit(int id)
        {
			var p = repositorio.ObtenerPorId(id);
			return View(p);
        }

		// POST: Propietario/Edit/5
		[Authorize(Policy = "Administrador")]
		[HttpPost]
        [ValidateAntiForgeryToken]
		
		public ActionResult Edit(int id, IFormCollection collection)
        {
			Propietario p = null;
			try
			{
				p = repositorio.ObtenerPorId(id);
				p.Nombre = collection["Nombre"];
				p.Apellido = collection["Apellido"];
				p.Dni = Convert.ToInt32(collection["Dni"]);
				p.Email = collection["Email"];
				p.Telefono = Convert.ToInt32(collection["Telefono"]);
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

		// GET: Propietario/Delete/5
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

        // POST: Propietario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Policy = "Administrador")]
		public ActionResult Delete(int id, Propietario entidad)
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