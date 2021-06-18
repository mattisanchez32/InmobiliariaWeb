using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Api
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class InmuebleController : ControllerBase
    {
		private readonly DataContext contexto;
		private readonly IConfiguration config;

		public InmuebleController(DataContext contexto, IConfiguration config)
		{
			this.contexto = contexto;
			this.config = config;
		}
		// GET: api/Inmueble
		[HttpGet]
        public async Task<IActionResult>  Get()
        {
			try
			{
				var usuario = User.Identity.Name;
				return Ok(contexto.Inmueble.Include(e => e.Propietarios).Where(e => e.Propietarios.Email == usuario));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // GET: api/Inmueble/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			try
			{
				var usuario = User.Identity.Name;
				return Ok(contexto.Inmueble.Include(e => e.Propietarios).Where(e => e.Propietarios.Email == usuario).Single(e => e.IdInmueble == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}


		[HttpGet("PorContrato/{id}")]
		public async Task<ActionResult<Inmueble>> GetPorContrato(int id)
		{
			try
			{
				var usuario = User.Identity.Name;
				var inmueble = await contexto.Alquiler.Include(e => e.Inmu)
					.Where(e => e.Inmu.Propietarios.Email == usuario && e.IdAlquiler == id)
					.Select(x => x.Inmu).SingleAsync();
				return Ok(inmueble);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/Inmueble
		[HttpPost]
        public async Task<IActionResult> Post(Inmueble entidad)
        {
			try
			{
				if (ModelState.IsValid)
				{
					entidad.IdPropietario = contexto.Propietarios.Single(e => e.Email == User.Identity.Name).IdPropietario;
					contexto.Inmueble.Add(entidad);
					contexto.SaveChanges();
					return CreatedAtAction(nameof(Get), new { id = entidad.IdInmueble }, entidad);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // PUT: api/Inmueble/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inmueble entidad)
        {
			try
			{
				if (ModelState.IsValid && contexto.Inmueble.AsNoTracking().Include(e => e.Propietarios).FirstOrDefault(e => e.IdInmueble == id && e.Propietarios.Email == User.Identity.Name) != null)
				{
					entidad.IdInmueble = id;
					var x = contexto.Propietarios.FirstOrDefault(e => e.Email == User.Identity.Name);
					entidad.IdPropietario = x.IdPropietario;
					contexto.Inmueble.Update(entidad);
					contexto.SaveChanges();
					return Ok(entidad);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			/*try
			{
				var entidad = contexto.Inmueble.Include(e => e.Duenio).FirstOrDefault(e => e.IdInmueble == id && e.Duenio.Email == User.Identity.Name);
				var contrato = contexto.Alquiler.Include(e => e.Inmueble).FirstOrDefault(e => e.InmuebleId == id);
				if (entidad != null && contrato == null)
				{
					contexto.Inmueble.Remove(entidad);
					contexto.SaveChanges();
					return Ok("Se borro she bien");
				}
				return BadRequest("El inmueble esta en un contrato ahorita");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);*/
			}
		
    }
}
