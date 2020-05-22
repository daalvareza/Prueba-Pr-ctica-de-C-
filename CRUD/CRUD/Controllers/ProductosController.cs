using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Tiendas
        public ActionResult IndexP()
        {
            List<ListProductosViewModel> lst;
            using (TredaEntities db = new TredaEntities())
            {
                lst = (from d in db.Productos
                       select new ListProductosViewModel
                       {
                           SKU = d.SKU,
                           Nombre = d.Nombre,
                           Descripcion = d.Descripcion,
                           Valor = d.Valor,
                           Tienda = d.Tienda,
                           Imagen = d.Imagen

                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult NuevoP()
        {
            return View();

        }

        [HttpPost]
        public ActionResult NuevoP(ProductosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TredaEntities db = new TredaEntities())
                    {
                        var oTabla = new Productos();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Descripcion = model.Descripcion;
                        oTabla.Valor = model.Valor;
                        oTabla.Tienda = model.Tienda;
                        oTabla.Imagen = model.Imagen;

                        db.Productos.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Productos/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult EditarP(int ID)
        {
            ProductosViewModel model = new ProductosViewModel();
            using (TredaEntities db = new TredaEntities())
            {
                var oProducto = db.Productos.Find(ID);
                model.Nombre = oProducto.Nombre;
                model.Descripcion = oProducto.Descripcion;
                model.Valor = oProducto.Valor;
                model.Tienda = oProducto.Tienda;
                model.Imagen = oProducto.Imagen;
                model.SKU = oProducto.SKU;
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult EditarP(ProductosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TredaEntities db = new TredaEntities())
                    {
                        var oTabla = db.Productos.Find(model.SKU);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Descripcion = model.Descripcion;
                        oTabla.Valor = model.Valor;
                        oTabla.Tienda = model.Tienda;
                        oTabla.Imagen = model.Imagen;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tiendas/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarP(int ID)
        {
            ProductosViewModel model = new ProductosViewModel();
            using (TredaEntities db = new TredaEntities())
            {
                var oProducto = db.Productos.Find(ID);
                db.Productos.Remove(oProducto);
                db.SaveChanges();
            }
            return Redirect("~/Productos/");

        }
    }
}
