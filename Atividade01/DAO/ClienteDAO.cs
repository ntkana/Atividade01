using Atividade01.Interfaces;
using Atividade01.Models;
using Microsoft.Data.SqlClient;

namespace Atividade01.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        private string _connectionString;

        public ClienteDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Deletar(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE * FROM Cliente WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Incluir(string pNome, string pEmail)
        {
            String query = "INSERT INTO Cliente (Nome, Email) VALUES (@Nome, @Email)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", pNome);
                cmd.Parameters.AddWithValue("@Email", pEmail);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        void IClienteDAO.Atualizar(Cliente pCliente)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Cliente SET Nome = @Nome, Email = @Email WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", pCliente.Nome);
                cmd.Parameters.AddWithValue("@Email", pCliente.Email);
                cmd.Parameters.AddWithValue("@Id", pCliente.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        Cliente IClienteDAO.BuscarPorId(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Cliente() 
                    { 
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Email = reader.GetString(2)
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        List<Cliente> IClienteDAO.ListarTodos()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Cliente> clientes = new List<Cliente>();
                while (reader.Read())
                {
                    clientes.Add(new Cliente()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
                return clientes;
            }
        }
    }
}
