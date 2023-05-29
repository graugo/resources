using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Impl.Mappers;
using HiveApp.Infrastructure.Impl.Models;
using HiveApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.Infrastructure.Impl.Impl
{
    public class BeeRepository : IBeeRepository
    {
        private readonly string _connStr;
        private readonly IRepoMapper _repoMapper;

        public BeeRepository(IRepoMapper repoMapper)
        {
            _connStr = ConfigurationManager.ConnectionStrings["HiveDb"].ConnectionString;
            _repoMapper = repoMapper;
        }
        public int DeleteBee(int id)
        {
            throw new NotImplementedException();
        }

        public List<BeeEntity> GetBees()
        {
            var result = new List<BeeDTO>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "SELECT * FROM bee";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new BeeDTO
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Recolection = reader.GetDecimal(2),
                        Time = reader.GetInt64(3),
                        State = reader.GetBoolean(4),
                        Incidents = reader.GetInt32(5),
                    });
                }
                reader.Close();
            }

            return _repoMapper.ToBeeEntityList(result);
        }

        public List<BeeEntity> GetBeesByFilter(decimal polen, int incidents, bool state)
        {
            throw new NotImplementedException();
        }
        
        public int PostBee(BeeEntity bee)
        {
            var result = 0;
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var query = "INSERT INTO Bee (Name, Recolection, Time, State, Incidents) " +
                    "Values (@name, @recolection, @time, @state, @incidents)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", bee.Name);
                cmd.Parameters.AddWithValue("@recolection", bee.Recolection);
                cmd.Parameters.AddWithValue("@time", bee.Time);
                cmd.Parameters.AddWithValue("@incidents", bee.Incidents);
                cmd.Parameters.AddWithValue("@state", bee.State);

                conn.Open();
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int PutBee(int id, BeeEntity bee)
        {
            throw new NotImplementedException();
        }
    }
}
