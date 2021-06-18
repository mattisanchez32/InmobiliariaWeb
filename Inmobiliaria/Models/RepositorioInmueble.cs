using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
	public class RepositorioInmueble : RepositorioBase, IRepositorioInmueble
	{
		public RepositorioInmueble(IConfiguration configuration) : base(configuration)
		{

		}

		public int Alta(Inmueble p)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Inmueble (Direccion, Tipo, Ambientes, Precio, Uso, Superficie, Latitud, Longitud, Disponibilidad, IdPropietario) " +
					$"VALUES ('{p.Direccion}', '{p.Tipo}', '{p.Ambientes}','{p.Precio}','{p.Uso}','{p.Superficie}','{p.Latitud}','{p.Longitud}','{p.Disponibilidad}','{p.IdPropietario}')";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					command.CommandText = "SELECT SCOPE_IDENTITY()";
					var id = command.ExecuteScalar();
					p.IdInmueble = Convert.ToInt32(id);
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
				string sql = $"DELETE FROM Inmueble WHERE IdInmueble = {id}";
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

		public IList<Inmueble> BuscarPorPropietario(int idPropietario)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Inmueble inmueble)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE Inmueble SET Direccion='{inmueble.Direccion}', Tipo='{inmueble.Tipo}', Ambientes={inmueble.Ambientes}, Uso='{inmueble.Uso}' , Superficie={inmueble.Superficie}, Latitud={inmueble.Latitud}, Longitud={inmueble.Longitud}, Precio = {inmueble.Precio} ,Disponibilidad = '{inmueble.Disponibilidad}' , IdPropietario={inmueble.IdPropietario} " +
					$"WHERE IdInmueble = {inmueble.IdInmueble}";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					/*command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = inmueble.Direccion;
					command.Parameters.Add("@tipo", SqlDbType.VarChar).Value = inmueble.Tipo;
					command.Parameters.Add("@ambientes", SqlDbType.Int).Value = inmueble.Ambientes;
					command.Parameters.Add("@uso", SqlDbType.VarChar).Value = inmueble.Uso;
					command.Parameters.Add("@superficie", SqlDbType.Int).Value = inmueble.Superficie;
					command.Parameters.Add("@latitud", SqlDbType.Decimal).Value = inmueble.Latitud;
					command.Parameters.Add("@longitud", SqlDbType.Decimal).Value = inmueble.Longitud;
					command.Parameters.Add("@Idpropietario", SqlDbType.Int).Value = inmueble.IdPropietario;*/
					
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public Inmueble ObtenerPorId(int id)
		{
			Inmueble entidad = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInmueble, Direccion, Tipo, Ambientes, Uso, Superficie, Latitud, Longitud, p.IdPropietario, p.Nombre, p.Apellido,Precio ,Disponibilidad" +
					$" FROM Inmueble i INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario" +
					$" WHERE IdInmueble=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						entidad = new Inmueble 
						{
							IdInmueble = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							Tipo = reader.GetString(2),
							Ambientes = reader.GetInt32(3),
							Uso = reader.GetString(4),
							Superficie = reader.GetInt32(5),
							Latitud = reader.GetDecimal(6),
							Longitud = reader.GetDecimal(7),
							IdPropietario = reader.GetInt32(8),
							Propietarios = new Propietario
							{
								IdPropietario = reader.GetInt32(8),
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
							},
							Precio = reader.GetDecimal(11),
							Disponibilidad = reader.GetBoolean(12)
						};
					}
					connection.Close();
				}
			}
			return entidad;
		}

		public IList<Inmueble> ObtenerTodos()
		{
			IList<Inmueble> res = new List<Inmueble>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInmueble, Direccion, Tipo, Ambientes, Uso, Superficie, Latitud, Longitud, p.IdPropietario, p.Nombre, p.Apellido, Precio,Disponibilidad" +
					$" FROM Inmueble i INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inmueble entidad = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							Tipo = reader.GetString(2),
							Ambientes = reader.GetInt32(3),
							Uso = reader.GetString(4),
							Superficie = reader.GetInt32(5),
							Latitud = reader.GetDecimal(6),
							Longitud = reader.GetDecimal(7),
							IdPropietario = reader.GetInt32(8),
							Propietarios = new Propietario
							{
								IdPropietario = reader.GetInt32(8),
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
							},
							Precio = reader.GetDecimal(11),
							Disponibilidad = reader.GetBoolean(12)
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
