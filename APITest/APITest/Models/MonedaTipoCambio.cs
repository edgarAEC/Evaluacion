using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Models
{
    public class MonedaTipoCambio
    {
        public double Monto{ get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
    }
}
