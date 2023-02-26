using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using primerParcial.Models;

namespace primerParcial._Pages_Empresas
{
    public class CreateModel : PageModel
    {
        private readonly primerParcial.Models.VideojuegosDbContext _context;
        [TempData]
        public string MensajeExitoso { get; set; }

        public CreateModel(primerParcial.Models.VideojuegosDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Empresa Empresa { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          
            _context.Empresas.Add(Empresa);
            MensajeExitoso = "Se creo correctamente la Empresa" + " " + Empresa.Nombre;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
