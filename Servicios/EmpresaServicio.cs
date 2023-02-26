using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using primerParcial.Models;

namespace primerParcial.Servicios
{
    public interface IEmpresaServicio
    {
        List<Empresa> MostrarEmpresas();
    }
    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly VideojuegosDbContext _context;
        public EmpresaServicio(VideojuegosDbContext context)
        {
            _context = context;
        }

        public List<Empresa> MostrarEmpresas()
        {
            return _context.Empresas.ToList();
        }
    }
}