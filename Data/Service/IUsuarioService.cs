using OnlineBlazorApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBlazorApp.Data.Service
{
    public interface IUsuarioService
    {

        Task<Usuario> UsuarioSelect(string username);

    }
}