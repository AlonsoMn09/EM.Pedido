using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Request.Cliente
{
    public class UpdateClienteRequest
    {
        public string RazonSocial { get; set; } = null!;

        public int IdTipoDocumentoCat { get; set; }

        public string NumeroDocumento { get; set; } = null!;

        public string Representante { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Celular { get; set; } = null!;

        public int IdRubroCat { get; set; }
    }
}
