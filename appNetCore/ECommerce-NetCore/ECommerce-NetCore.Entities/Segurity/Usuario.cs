using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Entities.Segurity
{


    [Keyless]
    public class Usuario
    {
        [Required]
        [StringLength(30)]
        public string? Correo {  get; set; }


        [Required]
        [StringLength(30)]
        public string? Clave {  get; set; }

    }
}
