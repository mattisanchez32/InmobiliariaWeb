using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class Pago
	{
		[Display(Name = "Código")]
		public int Id { get; set; }
		public int NroPago { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Fecha { get; set; }
		public decimal Importe { get; set; }

		[Display(Name = "Alquiler")]
		public int AlquilerId { get; set; }
		[ForeignKey("AlquilerId")]
		public Alquiler Alqui { get; set; }

	}
}
