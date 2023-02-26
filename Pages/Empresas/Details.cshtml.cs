using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using primerParcial.Models;

namespace primerParcial._Pages_Empresas
{
    public class DetailsModel : PageModel
    {
        private readonly primerParcial.Models.VideojuegosDbContext _context;

        public DetailsModel(primerParcial.Models.VideojuegosDbContext context)
        {
            _context = context;
        }

      public Empresa Empresa { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            else 
            {
                Empresa = empresa;
            }
            return Page();
        }
    }
}
