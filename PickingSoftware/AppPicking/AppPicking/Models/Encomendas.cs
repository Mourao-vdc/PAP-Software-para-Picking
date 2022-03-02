using System;
using System.Collections.Generic;
using System.Text;

namespace AppPicking.Models
{
    class Encomendas
    {
        public int ID { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public bool Situacao { get; set; }
        public int Quant_artigos { get; set; }
    }
}
