using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly DataContext _context;

        public AlquilerController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Alquiler
        [HttpGet]
        public async Task<ActionResult<IList<Alquiler>>> GetAlquiler()
        {
			try
			{
				var propietario = User.Identity.Name;
				var contratos = await _context.Alquiler.Include(x => x.Inmu).ThenInclude(x => x.Propietarios)
					.Where(x => x.Inmu.Propietarios.Email == propietario)
					.Select(x => new { x.IdAlquiler, x.FechaInicio, x.FechaFin, x.Precio, x.Inmu.Direccion })
					.ToListAsync();
				return Ok(contratos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // GET: api/Alquiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alquiler>> GetAlquiler(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);

            if (alquiler == null)
            {
                return NotFound();
            }

            return alquiler;
        }

        // PUT: api/Alquiler/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlquiler(int id, Alquiler alquiler)
        {
            if (id != alquiler.IdAlquiler)
            {
                return BadRequest();
            }

            _context.Entry(alquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlquilerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alquiler
        [HttpPost]
        public async Task<ActionResult<Alquiler>> PostAlquiler(Alquiler alquiler)
        {
            _context.Alquiler.Add(alquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlquiler", new { id = alquiler.IdAlquiler }, alquiler);
        }

        // DELETE: api/Alquiler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alquiler>> DeleteAlquiler(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }

            _context.Alquiler.Remove(alquiler);
            await _context.SaveChangesAsync();

            return alquiler;
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquiler.Any(e => e.IdAlquiler == id);
        }
    }
}
