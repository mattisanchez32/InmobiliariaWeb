using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inmobiliaria.Api
{

	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class PropietariosController : Controller
	{
		private readonly DataContext contexto;
		private readonly IConfiguration config;

		public PropietariosController(DataContext contexto, IConfiguration config)
		{
			this.contexto = contexto;
			this.config = config;
		}
		// GET: api/<controller>
		//[HttpGet]
		/*public async Task<ActionResult<IEnumerable<Propietario>>> Get()
		{
			try
			{
				var usuario = User.Identity.Name;
				return Ok(contexto.Propietarios.SingleOrDefault(x => x.Email == usuario));

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}*/

		// GET api/<controller>/5
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var usuario = User.Identity.Name;
				var res = await contexto.Propietarios.SingleOrDefaultAsync(x => x.Email == usuario);
				return Ok(res);

				
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/<controller>/5
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromForm] LoginView loginView)
		{
			try
			{
				string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: loginView.Clave,
				salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 1000,
				numBytesRequested: 256 / 8));
				var p = contexto.Propietarios.FirstOrDefault(x => x.Email == loginView.Usuario);
				if (p == null || p.Clave != hashed)
				{
					return BadRequest("Nombre de usuario o clave incorrecta");
				}
				else
				{
					var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, p.Email),
						new Claim("FullName", p.Nombre + " " + p.Apellido),
						new Claim(ClaimTypes.Role, "Propietario"),
					};

					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(60),
						signingCredentials: credenciales
					);
					return Ok(new JwtSecurityTokenHandler().WriteToken(token));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<IActionResult> Post(Propietario entidad)
		{
			try
			{
				if (ModelState.IsValid)
				{
					contexto.Propietarios.Add(entidad);
					await contexto.SaveChangesAsync();
					return CreatedAtAction(nameof(Get), new { id = entidad.IdPropietario }, entidad);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT api/<controller>/5
		[HttpPut]
		public IActionResult Put(Propietario entidad)
		{
			try
			{
				if (ModelState.IsValid && contexto.Propietarios.AsNoTracking().FirstOrDefault(x => x.Email == User.Identity.Name) != null)
				{
					Propietario propietario = contexto.Propietarios.AsNoTracking().Where(x => x.Email == User.Identity.Name).First();
					entidad.IdPropietario = propietario.IdPropietario;

					contexto.Propietarios.Update(entidad);
					contexto.SaveChanges();
					return Ok(entidad);
				}
				else { return BadRequest(); }


			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var entidad = contexto.Propietarios.FirstOrDefault(e => e.IdPropietario == id && e.Email == User.Identity.Name);
				if (entidad != null)
				{
					contexto.Propietarios.Remove(entidad);
					contexto.SaveChanges();
					return Ok();
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		
	}
}

