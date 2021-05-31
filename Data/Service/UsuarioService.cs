using Dapper;
using Microsoft.Data.SqlClient;
using OnlineBlazorApp.Data.Model;
using OnlineBlazorApp.Data.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineBlazorApp.Data.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public UsuarioService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Usuario> UsuarioSelect(string username)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = "SELECT Id, UserName FROM AspNetUsers WHERE UserName LIKE '%" + username + "%'";
                return await conn.QueryFirstOrDefaultAsync<Usuario>(query, commandType: CommandType.Text);
            }
        }

    }
}
