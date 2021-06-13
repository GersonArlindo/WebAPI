using Application.Feauters.Cuentas.Commands.CreateCuentaCommand;
using Application.Feauters.Cuentas.Commands.DeleteCuentaCommand;
using Application.Feauters.Cuentas.Commands.UpdateCuentaCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CuentasController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateCuentaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        //Put api/<controller>/5
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCuentaCommand command)
        {
            if (id != command.Id)

                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //Delete api/<controller>/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCuentaCommand { Id = id }));
        }
    }
}