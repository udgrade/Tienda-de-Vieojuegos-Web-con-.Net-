using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBlazorApp.Data.Model;

namespace OnlineBlazorApp.Data.Service
{
    public interface IFacturaService
    {
        Task<bool> FacturaInsert(Factura factura);
    }
}
