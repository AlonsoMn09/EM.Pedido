using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response.Cliente
{
    public class GetClienteResponse
    {
        public int Id { get; set; }
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
