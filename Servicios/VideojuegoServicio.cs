using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using primerParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace primerParcial.Servicios
{
    public interface IPlataformaServicio
    {
        List<Plataforma> MostrarPlataformas();
    }
    public class PlataformaServicio : IPlataformaServicio
    {
        private readonly VideojuegosDbContext _context;
        public PlataformaServicio(VideojuegosDbContext context)
        {
            _context = context;
        }
        public List<Plataforma> MostrarPlataformas()
        {
            return _context.Plataformas.ToList();
        }
    }

    public interface IVideojuegoServicio
    {       
        List<Videojuego> MostrarTodos();
        void Agregar(Videojuego videojuegoNuevo);
        void Modificar(Videojuego videojuegoEditado);
        void Eliminar(Videojuego videojuegoBorrado);
    }
    public class VideojuegoServicio : IVideojuegoServicio
    {
        private readonly VideojuegosDbContext _context;
        public VideojuegoServicio(VideojuegosDbContext context)
        {
            _context = context;
        }
        
        public List<Videojuego> MostrarTodos()
        {
            return _context.Videojuegos.
                    Include(c => c.Empresa)
                    .ToList();
        }
        public void Agregar(Videojuego videojuegoNuevo)
        {
            _context.Videojuegos.Add(videojuegoNuevo);
            _context.SaveChanges();
        }
        public void Modificar(Videojuego videojuegoEditado)
        {
            _context.Videojuegos.Update(videojuegoEditado);
            _context.SaveChanges();
        }
        public void Eliminar(Videojuego videojuegoBorrado)
        {
            _context.Videojuegos.Remove(videojuegoBorrado);
            _context.SaveChanges();
        }
    }
}