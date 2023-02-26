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
    public class DeleteModel : PageModel
    {
        private readonly primerParcial.Models.VideojuegosDbContext _context;
        [TempData]
        public string MensajeBorrado { get; set; }

        public DeleteModel(primerParcial.Models.VideojuegosDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa != null)
            {
                Empresa = empresa;
                MensajeBorrado = "Se elimino correctamente la Empresa";
                _context.Empresas.Remove(Empresa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
