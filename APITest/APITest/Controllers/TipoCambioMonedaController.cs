using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    public class TipoCambioMonedaController : Controller
    {
        private readonly TipoCambioContext _context;

        public TipoCambioMonedaController(TipoCambioContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult ObtenerTipoCambio(double Monto , string MonedaOrigen,string MonedaDestino)
        {
            var users = _context.ListaTipoCambio.ToArray();
            //.ToArrayAsync();

            var x =  _context.ListaTipoCambio.Where(e => e.MonedaOrigen == MonedaOrigen && e.MonedaDestino == MonedaDestino).FirstOrDefault();

            if (x != null)
            {
                var result = new ResultTipoCambio();
                result.TipoCambio = x.MTipoCambio;
                result.MonedaDestino = x.MonedaDestino;
                result.MonedaOrigen = x.MonedaOrigen;
                result.MontoConTipoCambio = Math.Round(x.MTipoCambio * Monto, 2);
                return Ok(result);
            }else
            {
                return Ok("No se encontro un tipo de cambio para la MonedaOrigen igual a " + MonedaOrigen + " y MonedaDestino igual a " + MonedaDestino);
            }

            
        }

    }
}
