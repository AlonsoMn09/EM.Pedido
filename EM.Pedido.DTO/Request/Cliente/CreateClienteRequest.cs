using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EM.Pedido.DTO.Request.Cliente
{
    public class CreateClienteRequest
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; } = null!;

        [DeniedValues(0, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Tipo de Documento")]
        public int IdTipoDocumentoCat { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Representante { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Celular { get; set; } = null!;

        [DeniedValues(0, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Rubro")]
        public int IdRubroCat { get; set; }
    }
}
