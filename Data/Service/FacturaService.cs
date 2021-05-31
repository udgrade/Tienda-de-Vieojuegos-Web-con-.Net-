using Dapper;
using Microsoft.Data.SqlClient;
using OnlineBlazorApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBlazorApp.Data.Service
{
    public class FacturaService : IFacturaService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public FacturaService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FacturaService()
        {
        }

        public async Task<bool> FacturaInsert(Factura factura)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Fact", factura.Codi_Fact, DbType.Int32);
                parameters.Add("Codi_UserUsuarios", factura.Codi_UserUsuarios, DbType.String);
                parameters.Add("Codi_ProdProductos", factura.Codi_ProdProductos, DbType.Int32);
                parameters.Add("Prec_Fact", factura.Prec_Fact, DbType.Double);
                parameters.Add("Fech_Fact", factura.Fech_Fact, DbType.DateTime);

                const string query = @"INSERT INTO Facturas (Codi_UserUsuarios, Codi_ProdProductos, Prec_Fact, Fech_Fact) VALUES (@Codi_UserUsuarios, @Codi_ProdProductos, @Prec_Fact, @Fech_Fact)";
                await conn.ExecuteAsync(query, new { factura.Codi_UserUsuarios, factura.Codi_ProdProductos, factura.Prec_Fact, factura.Fech_Fact }, commandType: CommandType.Text);
            }
            return true;
        }

        public async Task<Productos> FacturaSelect()
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = "SELECT Codi_Fact, Codi_UserUsuario, Codi_ProdProductos, Fech_Fact, Prec_Fact FROM Facturas";
                return await conn.QueryFirstOrDefaultAsync<Productos>(query, commandType: CommandType.Text);
            }
        }

    }
}
