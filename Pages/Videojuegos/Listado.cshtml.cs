using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using primerParcial.Models;
using primerParcial.Servicios;

namespace primerParcial.Pages.Videojuegos
{
    public class ListadoModel : PageModel
    {
        [BindProperty]
        public List<Videojuego> ListaVideojuegos { get; set; }
        private IVideojuegoServicio _videojuegoServicio;
        public string TituloOrden;
        public string PrecioOrden;
        [TempData]
        public string MensajeExitoso { get; set; }
        [TempData]
        public string MensajeBorrado { get; set; }
        [TempData]
        public string MensajeEditado { get; set; }
        public ListadoModel(IVideojuegoServicio videojuegoSrv)
        {
            _videojuegoServicio = videojuegoSrv;
        }
        public void OnGet(string FiltroTitulo, string FiltroGenero, string CampoOrden, string FiltroEmpresa, string LimpiarFiltros)
        {
            ListaVideojuegos = _videojuegoServicio.MostrarTodos();

            TituloOrden = (CampoOrden == "Titulo_Asc") ? "Titulo_Desc" : "Titulo_Asc";

            if (LimpiarFiltros != null && LimpiarFiltros.Length > 0)
            {
                ListaVideojuegos = _videojuegoServicio.MostrarTodos();
            }

            if (FiltroTitulo != null && FiltroTitulo.Length > 0)
            {
                ListaVideojuegos = ListaVideojuegos.Where(x => x.Titulo.ToUpper().Contains(FiltroTitulo.ToUpper())).ToList();
            }

            if (FiltroGenero != null && FiltroGenero.Length > 0)
            {
                ListaVideojuegos = ListaVideojuegos.Where(x => x.Genero.ToUpper().Contains(FiltroGenero.ToUpper())).ToList();
            }
            if (FiltroEmpresa != null && FiltroEmpresa.Length > 0)
            {
                ListaVideojuegos = ListaVideojuegos.Where(x => x.Empresa.Nombre.ToUpper().Contains(FiltroEmpresa.ToUpper())).ToList();
            }



            switch (CampoOrden)
            {
                case "Titulo_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.Titulo).ToList();
                    break;
                case "Titulo_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.Titulo).ToList();
                    break;
                case "Precio_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.Precio).ToList();
                    break;
                case "Precio_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.Precio).ToList();
                    break;
                case "Fecha_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.FechaLanzamiento).ToList();
                    break;
                case "Fecha_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.FechaLanzamiento).ToList();
                    break;
                case "Meta_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.PuntajeMetacritic).ToList();
                    break;
                case "Meta_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.PuntajeMetacritic).ToList();
                    break;
                case "Emp_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.Empresa.Nombre).ToList();
                    break;
                case "Emp_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.Empresa.Nombre).ToList();
                    break;
                case "Gen_Asc":
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.Genero).ToList();
                    break;
                case "Gen_Desc":
                    ListaVideojuegos = ListaVideojuegos.OrderByDescending(x => x.Genero).ToList();
                    break;
                default:
                    ListaVideojuegos = ListaVideojuegos.OrderBy(x => x.Id).ToList();
                    break;
            }
        }


    }
}
