using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio
{
    public class LugarRepositorio : ILugarRepositorio
    {
        private readonly ApplicationDbContext _Db;
        public LugarRepositorio(ApplicationDbContext db)
        {
            _Db = db;   
        }
        public async Task<Lugar> GetLugarAsync(int id)
        {

            // Find Async, no se puede usar con include
            return await _Db.Lugar.Include(p => p.Pais).Include(c => c.Categoria).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _Db.Lugar.Include(p => p.Pais).Include(c => c.Categoria).ToListAsync();
        }
    }
}