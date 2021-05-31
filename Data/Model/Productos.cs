using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBlazorApp.Data.Model
{
    public class Productos
    {
        public int Codi_Prod { get; set; }
        public string Name_Prod { get; set; }
        public string Desp_Prod { get; set; }
        public string Imgn_Prod { get; set; }
        public string Genero { get; set; }
        public int Pric_Prod { get; set; }
        public int Descuent_Prod { get; set; }
    }
}
