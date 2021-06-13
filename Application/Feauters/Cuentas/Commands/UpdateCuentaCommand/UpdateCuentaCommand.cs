using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feauters.Cuentas.Commands.UpdateCuentaCommand
{
    public class UpdateCuentaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public Guid Codigo { get; set; }
        public int IdCliente { get; set; }
        public string Saldo { get; set; }
        public string TipoTransferencia { get; set; }
    }
    public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cuenta> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCuentaCommandHandler(IRepositoryAsync<Cuenta> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _repositoryAsync.GetByIdAsync(request.IdCliente);

            if (cuenta == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.IdCliente}");
            }
            else
            {
                cuenta.Codigo = cuenta.Codigo;
                cuenta.IdCliente = cuenta.IdCliente;
                cuenta.Saldo = cuenta.Saldo;
                cuenta.TipoTransferencia = cuenta.TipoTransferencia;


                await _repositoryAsync.UpdateAsync(cuenta);

                return new Response<int>(cuenta.Id);
            }
        }
    }
}