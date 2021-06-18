
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;

namespace Inmobiliaria.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Propietario> Propietarios { get; set; }
		public DbSet<Inquilino> Inquilinos { get; set; }
		public DbSet<Inmueble> Inmueble { get; set; }
		public DbSet<Inmobiliaria.Models.Alquiler> Alquiler { get; set; }
	}
}
