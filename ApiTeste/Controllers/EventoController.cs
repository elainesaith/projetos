using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTeste.Data;
using ApiTeste.Models;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("v1/eventos")]
    public class EventoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Evento>>> Get([FromServices] DataContext context)
        {
            var eventos = await context.Eventos.ToListAsync();
            return eventos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Evento>> GetById([FromServices] DataContext context, int id)
        {
            var evento = await context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return evento;
        }

        [HttpPost]
        [Route("")]
        public async Task <ActionResult<Evento>> Post(
            [FromServices] DataContext context,
            [FromBody] Evento model)
        {
            if (ModelState.IsValid)
            {
                context.Eventos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Evento>> Put(
            [FromServices] DataContext context,
            [FromBody] Evento model)
        {
            if (ModelState.IsValid)
            {
                context.Eventos.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Evento>> Delete(
            [FromServices] DataContext context,
            [FromBody] Evento model)
        {
            if (ModelState.IsValid)
            {
                context.Eventos.Remove(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
