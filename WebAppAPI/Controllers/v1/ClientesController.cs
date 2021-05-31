using Application.Feauters.Clientes.Commands.CreateClienteCommand;
using Application.Feauters.Clientes.Commands.DeleteClienteCommand;
using Application.Feauters.Clientes.Commands.UpdateClienteCommand;
using Application.Feauters.Clientes.Queries.GetAllClientes;
using Application.Feauters.Clientes.Queries.GetClienteById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseApiController
    {

        //GET: api/<controller>
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllClientesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllClientesQuery
            {
                PageNumber = filter.PageNumber, 
                PageSize = filter.PageSize, 
                Nombre = filter.Nombre, 
                Apellido = filter.Apellido }));
        }


        //GET: api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClienteByIdQuery { Id = id}));
        }


        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Put api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.Id)

                return BadRequest();
            
            return Ok(await Mediator.Send(command));
        }

        //Delete api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClienteCommand { Id = id}));
        }
    }
}
