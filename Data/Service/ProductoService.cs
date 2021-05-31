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
    public class ProductoService : IProductoService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public ProductoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<bool> ProductoInsert(Productos producto)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Prod", producto.Codi_Prod, DbType.Int32);
                parameters.Add("Name_Prod", producto.Name_Prod, DbType.String);
                parameters.Add("Desp_Prod", producto.Desp_Prod, DbType.String);
                parameters.Add("Genero", producto.Genero, DbType.String);
                parameters.Add("Imgn_Prod", producto.Imgn_Prod, DbType.String);
                parameters.Add("Pric_Prod", producto.Pric_Prod, DbType.Int32);
                parameters.Add("Descuent_Prod", producto.Descuent_Prod, DbType.Int32);

                const string query = @"INSERT INTO Productos (Codi_Prod, Name_Prod, Desp_Prod, Genero, Imgn_Prod, Pric_Prod, Descuent_Prod) VALUES (@Codi_Prod, @Name_Prod, @Desp_Prod, @Genero, @Imgn_Prod, @Pric_Prod, @Descuent_Prod)";
                await conn.ExecuteAsync(query, new { producto.Codi_Prod, producto.Name_Prod, producto.Desp_Prod, producto.Genero, producto.Imgn_Prod, producto.Pric_Prod, producto.Descuent_Prod }, commandType: CommandType.Text);
            }

            return true;
        }

        public async Task<IEnumerable<Productos>> GetAllProductos()
        {
            IEnumerable<Productos> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT Codi_Prod, Name_Prod, Desp_Prod, Imgn_Prod, Genero, Pric_Prod, Descuent_Prod FROM Productos";
                productos = await conn.QueryAsync<Productos>(query, commandType: CommandType.Text);
            }

            return productos;
        }

        public async Task<IEnumerable<Productos>> Search(string busqueda)
        {
            IEnumerable<Productos> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = "SELECT Codi_Prod, Name_Prod, Imgn_Prod, Genero, Pric_Prod, Descuent_Prod FROM Productos WHERE Name_Prod LIKE '%" + busqueda + "%'";
                productos = await conn.QueryAsync<Productos>(query, commandType: CommandType.Text);
            }

            return productos;
        }

        public async Task<IEnumerable<Productos>> FiltroAventuraGenero(string Genero)
        {
            IEnumerable<Productos> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = "SELECT Codi_Prod, Name_Prod, Imgn_Prod, Genero, Pric_Prod, Descuent_Prod FROM Productos WHERE Genero LIKE '%" + Genero + "%'";
                productos = await conn.QueryAsync<Productos>(query, commandType: CommandType.Text);
            }

            return productos;
        }

        public async Task<Productos> ProductoSelect(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = "SELECT Codi_Prod, Name_Prod, Imgn_Prod, Genero, Pric_Prod, Descuent_Prod, Desp_Prod FROM Productos WHERE Codi_Prod LIKE '%" + id + "%'";
                return await conn.QueryFirstOrDefaultAsync<Productos>(query, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<Productos>> GetAllPuntuacionesProd()
        {
            IEnumerable<Productos> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT a.* FROM Productos a, Puntuaciones b WHERE b.Codi_ProdProductos = a.Codi_Prod AND b.Scor_Punt >= 4";
                productos = await conn.QueryAsync<Productos>(query, commandType: CommandType.Text);
            }

            return productos;
        }

    }
}
