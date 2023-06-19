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
        [BindProperty]
        public IFormFile NuevaFoto { get; set; }
        public List<SelectListItem> PlataformasLista { get; set; }
        public List<SelectListItem> EmpresasLista { get; set; }
        private IVideojuegoServicio _videojuegoSrv;
        private IPlataformaServicio _platSrv;
        private IEmpresaServicio _empSrv;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [TempData]
        public string MensajeEditado { get; set; }
        public EditarModel(IVideojuegoServicio videojuegoSrv, IPlataformaServicio platsrv, IEmpresaServicio empSrv, IWebHostEnvironment webHostEnvironment)
        {
            _videojuegoSrv = videojuegoSrv;
            _platSrv = platsrv;
            _empSrv = empSrv;
            _hostingEnvironment = webHostEnvironment;
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
            if (NuevaFoto != null && NuevaFoto.Length > 0)
            {
                // Eliminar la foto anterior si existe
                if (!string.IsNullOrEmpty(VideojuegoEdit.RutaFoto))
                {
                    string rutaFotoAnterior = Path.Combine(_hostingEnvironment.WebRootPath, "img", VideojuegoEdit.RutaFoto);
                    if (System.IO.File.Exists(rutaFotoAnterior))
                    {
                        System.IO.File.Delete(rutaFotoAnterior);
                    }
                }

                // Guardar la nueva foto
                string carpetaFotos = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                string nombreArchivo = $"{Guid.NewGuid()}{Path.GetExtension(NuevaFoto.FileName)}";
                string rutaCompleta = Path.Combine(carpetaFotos, nombreArchivo);
                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    NuevaFoto.CopyTo(stream);
                }

                VideojuegoEdit.RutaFoto = nombreArchivo;
            }

            _videojuegoSrv.Modificar(VideojuegoEdit);

            MensajeEditado = "Se edito correctamente el Videojuego" + " " + VideojuegoEdit.Titulo;
            return RedirectToPage("Listado");

        }
    }
}
