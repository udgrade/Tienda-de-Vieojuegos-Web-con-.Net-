using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBlazorApp.Data.Model
{
    public class Factura
    {

        public int Codi_Fact { get; set; }
        public string Codi_UserUsuarios { get; set; }
        public int Codi_ProdProductos { get; set; }
        public DateTime Fech_Fact { get; set; }
        public double Prec_Fact { get; set; }

    }
}
