using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public LugaresController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task <ActionResult<List<Lugar>>> GetLugares(){

            var LugarLista = await _db.Lugar.ToListAsync();

            return Ok(LugarLista);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Lugar>> GetLugar (int id){
           
           var Lugar = await _db.Lugar.FindAsync(id);

           if(Lugar==null){
            return BadRequest();
           }

           return Ok(Lugar);
        }
    }
}