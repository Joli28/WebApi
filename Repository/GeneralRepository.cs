using Contracts;
using Dapper;
using Entities.DataTransferObjects;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        public string _connectionString = string.Empty;
        //private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=OrariProvimeve;Encrypt=False;Integrated Security=True;User ID=\"DESKTOP-T1LCAF0\\Redi Zogolli\"";


        public bool isSetConnectionString()
        {
            return _connectionString != string.Empty;
        }
        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<string> GetDeget()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("GetDeget", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<DitaDto> GetDitet()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<DitaDto>("GetDitet", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<KlasaDto> GetKlasa()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<KlasaDto>("GetKlasa", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<OrariDateKlaseDto> GetOrariDateKlaseDtos(int klasa, int dita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@klasa", klasa);
            parameters.Add("@dita", dita);
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<OrariDateKlaseDto>("GetOrariByKlaseAndDate", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<OrariStudentDto> GetOrariStudent(string dega, int viti, string paraleli)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@dega", dega);
            parameters.Add("@viti", viti);
            parameters.Add("@paraleli", paraleli);
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<OrariStudentDto>("GetOrariByDegeVitParalel", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<OrarPedagogDto> GetOrarPedagog(string emri)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Emri", emri);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<OrarPedagogDto>("provimePedagog", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<string> GetParaleli(string dega, int viti)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@dega", dega);
            parameters.Add("@vit", viti);
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("GetParaleli", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<string> GetPedagog()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("GetPedagog", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public List<int> GetVitetPerDege(string dega)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<int>("GetVitetPerDege", param: new { dega = dega }, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

    }
}
