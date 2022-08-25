using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces
{
    public interface ILugarRepositorio
    {
        // Firmas de nuestros Metodos
        Task<Lugar> GetLugarAsync(int id);
        Task<IReadOnlyList<Lugar>> GetLugaresAsync();
    }
}