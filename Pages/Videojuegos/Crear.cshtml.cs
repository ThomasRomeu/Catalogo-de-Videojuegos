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
        private readonly IWebHostEnvironment _hostingEnvironment;
        
        [TempData]
        public string MensajeExitoso { get; set; }
        public CrearModel(IVideojuegoServicio videojuegoSrv, IPlataformaServicio platsrv, IEmpresaServicio empSrv, IWebHostEnvironment webHostEnvironment)
        {
            _videojuegoSrv = videojuegoSrv;
            _platSrv = platsrv;
            _empSrv = empSrv;
            _hostingEnvironment = webHostEnvironment;
            PlataformasLista = _platSrv.MostrarPlataformas().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
            EmpresasLista = _empSrv.MostrarEmpresas().Select(a => new SelectListItem{ Value = a.Id.ToString(), Text = a.Nombre}).ToList();           
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (VideojuegoIng.Foto != null)
            {
                VideojuegoIng.RutaFoto = VideojuegoIng.Foto.FileName;
                string carpetaFotos = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                string rutaCompleta = Path.Combine(carpetaFotos, VideojuegoIng.Foto.FileName);
                VideojuegoIng.Foto.CopyTo(new FileStream(rutaCompleta, FileMode.Create));
            }
            else
            {
                VideojuegoIng.RutaFoto = "noDisponible.jpg";
            }
                       
            _videojuegoSrv.Agregar(VideojuegoIng);
            MensajeExitoso = "Se creo correctamente el Videojuego" + " " + VideojuegoIng.Titulo;

            return RedirectToPage("Listado");

        }
    }
}
