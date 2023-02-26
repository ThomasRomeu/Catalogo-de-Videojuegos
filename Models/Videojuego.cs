using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace primerParcial.Models
{
    public class Videojuego
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Titulo"),
        MaxLength(30, ErrorMessage = "El titulo no debe superar los 30 caracteres"),
        MinLength(2, ErrorMessage = "El titulo debe contener mas de 1 caracter")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Genero"),
        MaxLength(30, ErrorMessage = "El titulo no debe superar los 30 caracteres"),
        MinLength(2, ErrorMessage = "El titulo debe contener mas de 1 caracter")]
        public string Genero { get; set; }
      
        [Required(ErrorMessage = "Debe ingresar el Precio")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "Debe ingresar si el juego posee logros o no")]
        public bool TieneLogros { get; set; }

        [Required(ErrorMessage = "Debe ingresar un puntaje"),
        Range(1, 100, ErrorMessage = "El puntaje de Metacritic debe estar entre los valores 1 y 100")]
        public int PuntajeMetacritic { get; set; }

        public bool Multijugador { get; set; }

        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}