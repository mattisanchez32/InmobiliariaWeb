using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class Inquilino
	{
		[Key]
		public int IdInquilino { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
		public int Telefono { get; set; }
		public int Dni { get; set; }
		public string Email { get; set; }



	}
}
