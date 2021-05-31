using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Feauters.Clientes.Queries.GetAllClientes
{
    public class GetAllClientesParameters : RequestParameter
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
