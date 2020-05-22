using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class ListTiendasViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_de_Apertura { get; set; }
    }
}