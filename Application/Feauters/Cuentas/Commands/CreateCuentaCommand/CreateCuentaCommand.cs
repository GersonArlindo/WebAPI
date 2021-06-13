using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feauters.Cuentas.Commands.CreateCuentaCommand
{
    public class CreateCuentaCommand : IRequest<Response<int>>
    {
        public Guid Codigo { get; set; }

        public int IdCliente { get; set; }

        public string Saldo { get; set; }

        public string TipoTransferencia { get; set; }
    }
    public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cuenta> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCuentaCommandHandler(IRepositoryAsync<Cuenta> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Cuenta>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}