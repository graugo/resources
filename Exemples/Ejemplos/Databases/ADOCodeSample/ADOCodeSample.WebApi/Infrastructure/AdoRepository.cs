using ADOCodeSample.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace ADOCodeSample.WebApi.Infrastructure
{
    public class AdoRepository
    {
        private string _connStr;

        public AdoRepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["AdoDB"].ConnectionString;
        }

        public IEnumerable<AdoRequest> GetAll() 
        {
            var result = new List<AdoRequest>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "SELECT * FROM AdoTable";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    result.Add(new AdoRequest
                    {
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2),
                        Id = reader.GetInt32(0)
                    });
                }
                reader.Close();
            }

            return result;
        }

        public int Insert(AdoRequest request) 
        {
            var result = 0;
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "INSERT INTO AdoTable (Name, Age) Values (@name, @age)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@age", request.Age);

                conn.Open();
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Update(AdoRequest request) 
        {
            var result = 0;
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "UPDATE AdoTable SET Name = @name, Age = @age WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@age", request.Age);
                cmd.Parameters.AddWithValue("@id", request.Id);

                conn.Open();
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(int id) 
        {
            var result = 0;
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "DELETE FROM AdoTable WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }
    }
}