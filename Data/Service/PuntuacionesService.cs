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
    public class PuntuacionesService : IPuntuacionesService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public PuntuacionesService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> PuntuacionesInsert(Puntuaciones puntuacion)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                
                parameters.Add("Codi_UserUsuarios", puntuacion.Codi_UserUsuarios, DbType.String);
                parameters.Add("Codi_ProdProductos", puntuacion.Codi_ProdProductos, DbType.Int32);
                parameters.Add("Scor_Punt", puntuacion.Scor_Punt, DbType.Int32);

                const string query = @"INSERT INTO Puntuaciones (Codi_UserUsuarios, Codi_ProdProductos, Scor_Punt) VALUES (@Codi_UserUsuarios, @Codi_ProdProductos, @Scor_Punt)";
                await conn.ExecuteAsync(query, new { puntuacion.Codi_UserUsuarios, puntuacion.Codi_ProdProductos, puntuacion.Scor_Punt }, commandType: CommandType.Text);
            }
            return true;
        }


    }
}