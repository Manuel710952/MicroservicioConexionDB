﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Nuevo.Ejecuta data){
            try
            {
                await _mediator.Send(data);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibro>>> GetAutores() {
            return await _mediator.Send(new Consulta.ListaAutor());
        }
    }
}
