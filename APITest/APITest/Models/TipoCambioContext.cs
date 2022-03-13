using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Models
{
    public class TipoCambioContext : DbContext
    {
        public TipoCambioContext(DbContextOptions<TipoCambioContext> options) : base(options)
        {

        }
        public DbSet<TipoCambio> ListaTipoCambio { get; set; }
    }
}
