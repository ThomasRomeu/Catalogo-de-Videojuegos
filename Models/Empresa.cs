using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace primerParcial.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        [Display(Name ="Fundacion")]
        public DateTime FechaFundada { get; set; }
        public string SitioWeb { get; set; }

        public List<Videojuego> Videojuegos {get;set;}
    }
}