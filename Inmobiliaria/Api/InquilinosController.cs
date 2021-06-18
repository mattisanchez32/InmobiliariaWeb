using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Api
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class InquilinosController : ControllerBase
    {
		private readonly DataContext contexto;
		private readonly IConfiguration config;

		public InquilinosController(DataContext contexto, IConfiguration config)
		{
			this.contexto = contexto;
			this.config = config;
		}
		// GET: api/Inquilinos
		[HttpGet]
        public async Task<IActionResult> Get()
        {
			try
			{
				var usuario = User.Identity.Name;
				return Ok(contexto.Inquilinos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // GET: api/Inquilinos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			try
			{
				return Ok(contexto.Inquilinos.SingleOrDefault(x => x.IdInquilino == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // POST: api/Inquilinos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inquilinos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
