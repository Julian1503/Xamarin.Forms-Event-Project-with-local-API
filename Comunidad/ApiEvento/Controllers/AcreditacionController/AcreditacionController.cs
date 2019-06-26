using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEvento.AutoMapperModelos;
using ApiEvento.Models.AcreditacionModel;
using AutoMapper;
using Comunidad.Interfaces.Acreditacion.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvento.Controllers.AcreditacionController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcreditacionController : ControllerBase
    {
        private readonly IAcreditacionRepositorio _acreditacionRepositorio;

        private readonly IMapper _mapper;
         public AcreditacionController(IAcreditacionRepositorio acreditacionRepositorio)
        {

            _acreditacionRepositorio = acreditacionRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PerfilCreationDto>());

            _mapper = config.CreateMapper();

        }


        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> Acreditar(AcreditacionCreationDto dto)
        {
            try
            {
                var acreditacion = _mapper.Map<AcreditacionDto>(dto);

                await _acreditacionRepositorio.Insert(acreditacion);

                return Ok(acreditacion);
            }
             catch
            {
                return BadRequest();
            }


             
        }


    }
}