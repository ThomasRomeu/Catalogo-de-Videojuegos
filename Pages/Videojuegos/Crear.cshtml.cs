using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using primerParcial.Models;
using primerParcial.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace primerParcial.Pages.Videojuegos
{
    public class CrearModel : PageModel
    {
        [BindProperty]
        public Videojuego VideojuegoIng { get; set; }
        public List<SelectListItem> PlataformasLista { get; set; }
        public List<SelectListItem> EmpresasLista { get; set; }
        private IVideojuegoServicio _videojuegoSrv;
        private IPlataformaServicio _platSrv;
        private IEmpresaServicio _empSrv;
        
        [TempData]
        public string MensajeExitoso { get; set; }
        public CrearModel(IVideojuegoServicio videojuegoSrv, IPlataformaServicio platsrv, IEmpresaServicio empSrv)
        {
            _videojuegoSrv = videojuegoSrv;
            _platSrv = platsrv;
            _empSrv = empSrv;
            PlataformasLista = _platSrv.MostrarPlataformas().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
            EmpresasLista = _empSrv.MostrarEmpresas().Select(a => new SelectListItem{ Value = a.Id.ToString(), Text = a.Nombre}).ToList();           

        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _videojuegoSrv.Agregar(VideojuegoIng);
            MensajeExitoso = "Se creo correctamente el Videojuego" + " " + VideojuegoIng.Titulo;

            return RedirectToPage("Listado");

        }
    }
}
