using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class ListProductosViewModel
    {
        public string Nombre { get; set; }
        public int SKU { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int Tienda { get; set; }
        public string Imagen { get; set; }
    }
}