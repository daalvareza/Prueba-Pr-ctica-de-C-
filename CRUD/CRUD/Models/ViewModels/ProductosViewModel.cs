using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace CRUD.Models.ViewModels
{
    public class ProductosViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int SKU { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        [IntegerValidator]
        [Display(Name = "Valor")]
        public int Valor { get; set; }
        [Required]
        [IntegerValidator]
        [Display(Name = "Tienda ID")]
        public int Tienda { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

    }
}