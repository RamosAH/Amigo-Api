using System.Data.SqlClient;
using System.Data;
using Amigos_Api.Models;

namespace Amigos_Api.CRUD {
    public static class Crud {

        public static List<Amigo> ConsultarAmigos(SqlConnection conn) {
            string sp = "ConsultarAmigos";
            List<Amigo> amigos = new List<Amigo>();

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Amigo amigo = new Amigo();
                        amigo.Id = (int)reader["Id"];
                        amigo.Nome = reader["Nome"].ToString();
                        amigo.Sobrenome = reader["Sobrenome"].ToString();
                        amigo.Email = reader["Email"].ToString();
                        amigo.Telefone = reader["Telefone"].ToString();
                        amigo.Dtaniversario = DateTime.Parse(reader["Dtaniversario"].ToString());
                        amigos.Add(amigo);
                    }
                }
                conn.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return amigos;
        }

        public static Amigo ConsultarAmigo(SqlConnection conn, int id) {
            string sp = "ConsultarAmigo";
            Amigo amigo = null;

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            try {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        amigo = new Amigo();
                        amigo.Id = (int)reader["Id"];
                        amigo.Nome = reader["Nome"].ToString();
                        amigo.Sobrenome = reader["Sobrenome"].ToString();
                        amigo.Email = reader["Email"].ToString();
                        amigo.Telefone = reader["Telefone"].ToString();
                        amigo.Dtaniversario = DateTime.Parse(reader["Dtaniversario"].ToString());
                    }
                }
                conn.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return amigo;
        }

        public static int InserirAmigo(SqlConnection conn, Amigo amigo) {
            string sp = "InserirAmigo";
            int cont = 0;

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", amigo.Nome);
            cmd.Parameters.AddWithValue("@Sobrenome", amigo.Sobrenome);
            cmd.Parameters.AddWithValue("@Email", amigo.Email);
            cmd.Parameters.AddWithValue("@Telefone", amigo.Telefone);
            cmd.Parameters.AddWithValue("@Dtaniversario", amigo.Dtaniversario);
            conn.Open();
            try {
                cont = cmd.ExecuteNonQuery();
            } catch (System.Exception ex) {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return cont;
        }

        public static int AlterarAmigo(SqlConnection conn, Amigo amigo) {
            string sp = "AlterarAmigo";
            int cont = 0;

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", amigo.Id);
            cmd.Parameters.AddWithValue("@Nome", amigo.Nome);
            cmd.Parameters.AddWithValue("@Sobrenome", amigo.Sobrenome);
            cmd.Parameters.AddWithValue("@Email", amigo.Email);
            cmd.Parameters.AddWithValue("@Telefone", amigo.Telefone);
            cmd.Parameters.AddWithValue("@Dtaniversario", amigo.Dtaniversario);
            conn.Open();
            try {
                cont = cmd.ExecuteNonQuery();
            } catch (System.Exception ex) {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return cont;
        }

        public static int ExcluirAmigo(SqlConnection conn, int id) {
            string sp = "ExcluirAmigo";
            int cont = 0;

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            try {
                cont = cmd.ExecuteNonQuery();
            } catch (System.Exception ex) {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return cont;
        }

    }
}
