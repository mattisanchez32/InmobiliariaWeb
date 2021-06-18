using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class RepositorioPago : RepositorioBase, IRepositorioPago
	{
		public RepositorioPago(IConfiguration configuration) : base(configuration)
		{

		}

		public int Alta(Pago p)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Pago (NroPago, Fecha, Importe, IdAlquiler) " +
					$"VALUES ('{p.NroPago}', '{p.Fecha}','{p.Importe}','{p.AlquilerId}')";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					command.CommandText = "SELECT SCOPE_IDENTITY()";
					var id = command.ExecuteScalar();
					p.Id = Convert.ToInt32(id);
					connection.Close();
				}
			}
			return res;
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Pago> BuscarPorAlquiler(int idAlquiler)
		{
			IList<Pago> res = new List<Pago>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPago, NroPago, Fecha, Importe, p.IdAlquiler, p.IdInquilino, p.IdInmueble" +
					$" FROM Pago i INNER JOIN Alquiler p ON i.IdAlquiler = p.IdAlquiler " +
					$" WHERE i.IdAlquiler=@idAlquiler";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idAlquiler", SqlDbType.Int).Value = idAlquiler;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Pago entidad = new Pago
						{
							Id = reader.GetInt32(0),
							NroPago = reader.GetInt32(1),
							Fecha = reader.GetDateTime(2),
							Importe = reader.GetDecimal(3),
							AlquilerId = reader.GetInt32(4),
							Alqui = new Alquiler
							{
								IdAlquiler = reader.GetInt32(4),
								IdInquilino = reader.GetInt32(5),
								IdInmueble = reader.GetInt32(6),
							}
							
						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}

		public int Modificacion(Pago p)
		{
			throw new NotImplementedException();
		}

		public Pago ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Pago> ObtenerTodos()
		{
			IList<Pago> res = new List<Pago>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPago, NroPago, Fecha, Importe, p.IdAlquiler, p.IdInquilino, p.IdInmueble" +
					$" FROM Pago i INNER JOIN Alquiler p ON i.IdAlquiler = p.IdAlquiler";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Pago entidad = new Pago
						{
							Id = reader.GetInt32(0),
							NroPago = reader.GetInt32(1),
							Fecha = reader.GetDateTime(2),
							Importe = reader.GetDecimal(3),
							AlquilerId = reader.GetInt32(4),
							Alqui = new Alquiler
							{
								IdAlquiler = reader.GetInt32(4),
								IdInquilino = reader.GetInt32(5),
								IdInmueble = reader.GetInt32(6),
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
