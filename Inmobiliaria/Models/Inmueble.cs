using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class Inmueble
	{
		[Key]
		[Display(Name = "Código")]
		public int IdInmueble { get; set; }
		[Required]
		public string Direccion { get; set; }
		[Required]
		public string Tipo { get; set; }
		[Required]
		public int Ambientes { get; set; }
		[Required]
		public string Uso { get; set; }
		[Required]
		public int Superficie { get; set; }
		public bool Disponibilidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Latitud { get; set; }
		public decimal Longitud { get; set; }
		[Display(Name = "Dueño")]
		public int IdPropietario { get; set; }
		[ForeignKey("IdPropietario")]
		public Propietario Propietarios { get; set; }
	}
}
