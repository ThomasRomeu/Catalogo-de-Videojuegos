using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primerParcial.Models
{
    public class Plataforma
    {
        public int Id {get;set;}
        public string Nombre {get;set;}

        public virtual List<Videojuego> Videojuegos {get;set;}
    }
}