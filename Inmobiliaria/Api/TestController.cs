using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
		private readonly DataContext context;

		public TestController(DataContext context)
		{
			this.context = context;
		}

		// GET: api/<controller>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Propietario>>> Get()
		{

			return context.Propietarios;
			/*try
			{
				return Ok(new
				{
					Mensaje = "Éxito",
					Error = 0,
					Resultado = new
					{
						Clave = "Key",
						Valor = "Value"
					},
				});
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}*/
		}

		// GET api/<controller>/5
		[HttpGet("{id}", Name="Get")]
		public ActionResult<Propietario> Get(int id)
		{
			if (id < 0)
			{
				return NotFound();
			}
			else
			{
				return context.Propietarios.First(x => x.IdPropietario == id);
			}
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
