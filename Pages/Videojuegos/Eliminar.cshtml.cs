using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using primerParcial.Models;
using primerParcial.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace primerParcial.Pages.Videojuegos
{
    public class EliminarModel : PageModel
    {
        [BindProperty]
        public Videojuego VideojuegoElim { get; set; }
        public List<SelectListItem> PlataformasLista { get; set; }
        public List<SelectListItem> EmpresasLista { get; set; }
        private IVideojuegoServicio _videojuegoSrv;
        private IPlataformaServicio _platSrv;
        private IEmpresaServicio _empSrv;

        [TempData]
        public string MensajeBorrado { get; set; }
        public EliminarModel(IVideojuegoServicio videojuegoSrv, IPlataformaServicio platsrv, IEmpresaServicio empSrv)
        {
            _videojuegoSrv = videojuegoSrv;
            _platSrv = platsrv;
            _empSrv = empSrv;
        }
        public void OnGet(int id)
        {
            var lista = _videojuegoSrv.MostrarTodos();
            VideojuegoElim = lista.Where(x => x.Id == id).First();
            PlataformasLista = _platSrv.MostrarPlataformas().Select(a=>new SelectListItem{Value=a.Id.ToString(),Text=a.Nombre}).ToList();
            EmpresasLista = _empSrv.MostrarEmpresas().Select(a => new SelectListItem{ Value = a.Id.ToString(), Text = a.Nombre}).ToList();           

        }
        public IActionResult OnPost()
        {
            _videojuegoSrv.Eliminar(VideojuegoElim);
            MensajeBorrado = "Se elimino correctamente el Videojuego";
            return RedirectToPage("Listado");
            
        }
    }
}
