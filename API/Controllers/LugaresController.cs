using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Especificaciones;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly IRepositorio<Lugar> _lugarRepo;
        private readonly IRepositorio<Pais> _paisRepo;
        private readonly IRepositorio<Categoria> _categoriaRepo;
        private readonly IMapper _mapper;

        public LugaresController(IRepositorio<Lugar> lugarRepo,IRepositorio<Pais> paisRepo, 
                                 IRepositorio<Categoria> categoriaRepo, IMapper mapper)
        {
            this._lugarRepo = lugarRepo;
            this._paisRepo = paisRepo;
            this._categoriaRepo = categoriaRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <ActionResult<IReadOnlyList<LugarDTO>>> GetLugares(){

            var espec = new LugaresConPaisCategoriaEspecificacion(); 
            var lugares = await _lugarRepo.ObtenerTodosEspec(espec);

            return Ok(_mapper.Map<IReadOnlyList<Lugar>, IReadOnlyList<LugarDTO>>(lugares));
        }

        [HttpGet("{id}")]
        
        public async Task <ActionResult<LugarDTO>> GetLugar (int id){
           
           var espec = new LugaresConPaisCategoriaEspecificacion(id);
           var lugar = await _lugarRepo.ObtenerEspec(espec);

           return _mapper.Map<Lugar,LugarDTO>(lugar);
        }

        [HttpGet("paises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Pais>>> GetPaises(){

            return Ok(await _paisRepo.ObtenerTodosAsync());
        }

        [HttpGet("categorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Categoria>>> GetCategorias(){

            return Ok(await _categoriaRepo.ObtenerTodosAsync());
        }
    }
}