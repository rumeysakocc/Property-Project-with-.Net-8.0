using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            //Bağlantı adresi alıyoruz,appsettingsde verdiğimiz key değerini veriyoruz.
            _connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        
    }
}
