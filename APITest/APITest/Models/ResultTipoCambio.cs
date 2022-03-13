using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Models
{
    public class ResultTipoCambio
    {
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double TipoCambio { get; set; }
        public double MontoConTipoCambio { get; set; }
    }
}
