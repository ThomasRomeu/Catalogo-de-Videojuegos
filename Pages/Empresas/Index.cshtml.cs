using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using primerParcial.Models;
using primerParcial.Servicios;

namespace primerParcial._Pages_Empresas
{
    public class IndexModel : PageModel
    {
        private readonly primerParcial.Models.VideojuegosDbContext _context;
         [TempData]
        public string MensajeExitoso { get; set; }
        [TempData]
        public string MensajeBorrado { get; set; }
        [TempData]
        public string MensajeEditado { get; set; }

        public IndexModel(primerParcial.Models.VideojuegosDbContext context)
        {
            _context = context;
        }

        public IList<Empresa> Empresa { get; set; } = default!;

        public async Task OnGetAsync(string CampoOrden, string filtroNombre, string filtroPais, string LimpiarFiltros)
        {
            if (_context.Empresas != null)
            {
                Empresa = await _context.Empresas.ToListAsync();
            }
            if (LimpiarFiltros != null && LimpiarFiltros.Length > 0)
            {
                Empresa =  _context.Empresas.ToList();
            }
            if (filtroNombre != null && filtroNombre.Length > 0)
            {
                Empresa = Empresa.Where(x => x.Nombre.ToUpper().Contains(filtroNombre.ToUpper())).ToList();
            }
            if (filtroPais != null && filtroPais.Length > 0)
            {
                Empresa = Empresa.Where(x => x.Pais.ToUpper().Contains(filtroPais.ToUpper())).ToList();
            }
            switch (CampoOrden)
            {
                case "Fecha_Asc":
                    Empresa = Empresa.OrderBy(x => x.FechaFundada).ToList();
                    break;
                case "Fecha_Desc":
                    Empresa = Empresa.OrderByDescending(x => x.FechaFundada).ToList();
                    break;
                default:
                    Empresa = Empresa.OrderBy(x => x.Id).ToList();
                    break;    
            }
        }
        
    }
}
