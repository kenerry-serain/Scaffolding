using Dapper;
using $DomainInterfaceNamespace$;
using $DomainEntitiesNamespace$;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace $RepositoryNamespace$
{
    public class $Entity$Repository : I$Entity$Repository
    {
        private IConfiguration _configuration;
        public $Entity$Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<$Entity$> Create($Entity$ $lowerEntity$)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var created$Entity$ = await connection.QuerySingleAsync<$Entity$>(string.Format("INSERT INTO $Entity$ VALUES ('{0}'); SELECT * FROM $Entity$ WHERE Id = (SELECT SCOPE_IDENTITY()) ", $lowerEntity$.Name));
                return created$Entity$;
            }
        }

        public async Task<IEnumerable<$Entity$>> ReadAll()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var $lowerEntity$List = await connection.QueryAsync<$Entity$>("SELECT * FROM $Entity$");
                return $lowerEntity$List;
            }
        }

        public async Task<$Entity$> ReadById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var $lowerEntity$ = await connection.QuerySingleAsync<$Entity$>(string.Format("SELECT * FROM $Entity$ WHERE Id={0}", id));
                return $lowerEntity$;
            }
        }

        public async Task Remove(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                await connection.QueryAsync<$Entity$>(string.Format("DELETE FROM $Entity$ WHERE Id={0}", id));
            }
        }

        public async Task<$Entity$> Update($Entity$ $lowerEntity$)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var created$Entity$ = await connection.QuerySingleAsync<$Entity$>(string.Format("UPDATE $Entity$ SET Name= '{0}' WHERE Id={1}; SELECT * FROM $Entity$ WHERE Id = {1}", $lowerEntity$.Name, $lowerEntity$.Id));
                return created$Entity$;
            }
        }
    }
}
