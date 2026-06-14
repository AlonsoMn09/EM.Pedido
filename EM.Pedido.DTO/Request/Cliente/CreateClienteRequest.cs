using EM.Pedido.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EM.Pedido.DTO.Request.Cliente
{
    public class CreateClienteRequest
    {
        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; } = null!;

        [DeniedValues(0, ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        [Display(Name = "Tipo de Documento")]
        public int IdTipoDocumentoCat { get; set; }

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Representante { get; set; } = null!;

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Celular { get; set; } = null!;

        [DeniedValues(0, ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        [Display(Name = "Rubro")]
        public int IdRubroCat { get; set; }
    }
}
