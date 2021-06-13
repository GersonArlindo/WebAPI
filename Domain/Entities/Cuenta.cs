using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cuenta : AuditableBaseEntity
    {
        public Guid Codigo { get; set; }

        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public string Saldo { get; set; }

        public string TipoTransferencia { get; set; }
    }
}