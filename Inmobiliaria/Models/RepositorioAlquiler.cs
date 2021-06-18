using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class RepositorioAlquiler : RepositorioBase, IRepositorio<Alquiler>
	{
		public RepositorioAlquiler(IConfiguration configuration) : base(configuration)
		{

		}

		public int Alta(Alquiler p)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Alquiler (Precio, FechaInicio, FechaFin, IdInquilino, IdInmueble) " +
					$"VALUES ('{p.Precio}', '{p.FechaInicio}', '{p.FechaFin}','{p.IdInquilino}','{p.IdInmueble}')";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					command.CommandText = "SELECT SCOPE_IDENTITY()";
					var id = command.ExecuteScalar();
					p.IdAlquiler = Convert.ToInt32(id);
					connection.Close();
				}
			}
			return res;
		}

		public int Baja(int id)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"DELETE FROM Alquiler WHERE IdAlquiler = {id}";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public int Modificacion(Alquiler alquiler)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE Alquiler SET Precio=@precio, FechaInicio=@fechaInicio, FechaFin=@fechaFin, IdInquilino=@inquilinoId , IdInmueble=@inmuebleId " +
					$"WHERE IdAlquiler = {alquiler.IdAlquiler}";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@precio", SqlDbType.Int).Value = alquiler.Precio;
					command.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = alquiler.FechaInicio;
					command.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = alquiler.FechaFin;
					command.Parameters.Add("@inquilinoId", SqlDbType.Int).Value = alquiler.IdInquilino;
					command.Parameters.Add("@inmuebleId", SqlDbType.Int).Value = alquiler.IdInmueble;
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public Alquiler ObtenerPorId(int id)
		{
			Alquiler entidad = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdAlquiler, i.Precio, FechaInicio, FechaFin, p.IdInquilino, p.Nombre, p.Apellido, j.IdInmueble, j.Direccion, j.Tipo" +
					$" FROM Alquiler i INNER JOIN Inquilinos p ON i.IdInquilino = p.IdInquilino INNER JOIN Inmueble j ON i.IdInmueble = j.IdInmueble" +
					$" WHERE IdAlquiler=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						entidad = new Alquiler
						{
							IdAlquiler = reader.GetInt32(0),
							Precio = reader.GetDecimal(1),
							FechaInicio = reader.GetDateTime(2),
							FechaFin = reader.GetDateTime(3),
							IdInquilino = reader.GetInt32(4),
							Inqui = new Inquilino
							{
								IdInquilino = reader.GetInt32(4),
								Nombre = reader.GetString(5),
								Apellido = reader.GetString(6),
							},
							IdInmueble = reader.GetInt32(7),
							Inmu = new Inmueble
							{
								IdInmueble = reader.GetInt32(7),
								Direccion = reader.GetString(8),
								Tipo = reader.GetString(9),
							}
						};
					}
					connection.Close();
				}
			}
			return entidad;
		}

		public IList<Alquiler> ObtenerTodos()
		{
			IList<Alquiler> res = new List<Alquiler>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdAlquiler, i.Precio, FechaInicio, FechaFin, p.IdInquilino, p.Nombre, p.Apellido, j.idInmueble, j.Direccion, j.Tipo" +
					$" FROM Alquiler i INNER JOIN Inquilinos p ON i.IdInquilino = p.IdInquilino INNER JOIN Inmueble j ON i.IdInmueble = j.IdInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Alquiler entidad = new Alquiler
						{
							IdAlquiler = reader.GetInt32(0),
							Precio = reader.GetDecimal(1),
							FechaInicio = reader.GetDateTime(2),
							FechaFin = reader.GetDateTime(3),
							IdInquilino = reader.GetInt32(4),
							Inqui = new Inquilino
							{
								IdInquilino = reader.GetInt32(4),
								Nombre = reader.GetString(5),
								Apellido = reader.GetString(6),
							},
							IdInmueble = reader.GetInt32(7),
							Inmu = new Inmueble
							{
								IdInmueble = reader.GetInt32(7),
								Direccion = reader.GetString(8),
								Tipo = reader.GetString(9),
							}
						    
						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}
	}
}
