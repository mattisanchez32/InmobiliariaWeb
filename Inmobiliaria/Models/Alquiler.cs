using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class Alquiler
	{
		[Key]
		[Display(Name = "Código")]
		public int IdAlquiler { get; set; }
		public decimal Precio { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime FechaInicio { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime FechaFin { get; set; }

		[Display(Name = "Inquilino")]
		public int IdInquilino { get; set; }
		[ForeignKey("IdInquilino")]
		public Inquilino Inqui { get; set; }

		[Display(Name = "Inmueble")]
		public int IdInmueble { get; set; }
		[ForeignKey("IdInmueble")]
		public Inmueble Inmu { get; set; }

	}
}
