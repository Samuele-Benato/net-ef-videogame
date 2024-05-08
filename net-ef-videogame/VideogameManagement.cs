using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManagement
    {
        const string CONNECT_DATABASE = "Server=localhost;Database=db-newvideogames;Trusted_Connection=True";
        public static void InsertVideogame( string name, string overview, DateTime relesedate, DateTime createdat, DateTime updatedat, int softwarehouseid, SoftwareHouse softwarehouse)
        {
            Videogame videogame = new Videogame(name, overview, relesedate, createdat, updatedat, softwarehouseid, softwarehouse);

            string query = "INSERT INTO videogames(name, overview, release_date, created_at, updated_at, software_house_id) VALUES (@name, @overview, @relesedate, @createdat, @updatedat, @softwarehouseid)";

            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@relesedate", relesedate));
                cmd.Parameters.Add(new SqlParameter("@createdat", createdat));
                cmd.Parameters.Add(new SqlParameter("@updatedat", updatedat));
                cmd.Parameters.Add(new SqlParameter("@softwarehouseid", softwarehouseid));

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally
            {
                connect.Close();
            }
        }

        public static string GetVideogameById(int id)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return $"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}";
                }
                return "Videogame not found.";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                connect.Close();
            }
        }

        public static string GetVideogameByInput(string input)
        {
            string query = "SELECT * FROM videogames WHERE name LIKE @input OR overview LIKE @input";
            //string query = "SELECT * FROM videogames WHERE CAST(name AS NVARCHAR(MAX)) = @input OR CAST(overview AS NVARCHAR(MAX)) = @input";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@input", "%" + input + "%"));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return $"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}";
                }
                return "Videogame not found";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                connect.Close();
            }
        }

        public static void DeleteVideogame(string name)
        {
            string query = "DELETE FROM videogames WHERE name = @name";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
