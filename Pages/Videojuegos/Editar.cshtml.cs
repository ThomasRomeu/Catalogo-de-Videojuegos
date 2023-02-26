using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using primerParcial.Models;
using primerParcial.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace primerParcial.Pages.Videojuegos
{
    public class EditarModel : PageModel
    {
        [BindProperty]
        public Videojuego VideojuegoEdit { get; set; }
        public List<SelectListItem> PlataformasLista { get; set; }
        public List<SelectListItem> EmpresasLista { get; set; }
        private IVideojuegoServicio _videojuegoSrv;
        private IPlataformaServicio _platSrv;
        private IEmpresaServicio _empSrv;

        [TempData]
        public string MensajeEditado { get; set; }
        public EditarModel(IVideojuegoServicio videojuegoSrv, IPlataformaServicio platsrv, IEmpresaServicio empSrv)
        {
            _videojuegoSrv = videojuegoSrv;
            _platSrv = platsrv;
            _empSrv = empSrv;
        }
        public void OnGet(int id)
        {
            var lista = _videojuegoSrv.MostrarTodos();
            VideojuegoEdit = lista.Where(x => x.Id == id).First();
            PlataformasLista = _platSrv.MostrarPlataformas().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
            EmpresasLista = _empSrv.MostrarEmpresas().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();

        }
        public IActionResult OnPost()
        {

            _videojuegoSrv.Modificar(VideojuegoEdit);
            MensajeEditado = "Se edito correctamente el Videojuego" + " " + VideojuegoEdit.Titulo;
            return RedirectToPage("Listado");

        }
    }
}
