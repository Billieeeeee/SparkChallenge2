
namespace Pagos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblCliente
    {
        [Display (Name = "#")]
        public int idCliente { get; set; }

        [Display(Name = "Nombre del cliente")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }

        [Display(Name = "Saldo del cliente")]
        public double saldo { get; set; }
    }
}
