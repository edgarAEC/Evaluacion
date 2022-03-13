using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Models
{
    public class TipoCambio
    {
        [Key]
        public Guid ID { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double MTipoCambio { get; set; }
    }
}
