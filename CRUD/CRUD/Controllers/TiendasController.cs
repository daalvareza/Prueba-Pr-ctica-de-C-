using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Controllers
{
    public class TiendasController : Controller
    {
        // GET: Tiendas
        public ActionResult Index()
        {
            List<ListTiendasViewModel> lst;
            using (TredaEntities db = new TredaEntities())
            {
                lst = (from d in db.Tiendas
                          select new ListTiendasViewModel
                          {
                              ID = d.ID,
                              Nombre = d.Nombre,
                              Fecha_de_Apertura = d.Fecha_de_Apertura
                         }).ToList();
            }
                return View(lst);
        }

        public ActionResult NuevaT()
        {
            return View();

        }

        [HttpPost]
        public ActionResult NuevaT(TiendasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TredaEntities db = new TredaEntities())
                    {
                        var oTabla = new Tiendas();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Fecha_de_Apertura = model.Fecha_de_Apertura;

                        db.Tiendas.Add(oTabla);
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
        public ActionResult EditarT(int ID)
        {
            TiendasViewModel model = new TiendasViewModel();
            using (TredaEntities db = new TredaEntities())
            {
                var oTienda = db.Tiendas.Find(ID);
                model.Nombre = oTienda.Nombre;
                model.Fecha_de_Apertura = oTienda.Fecha_de_Apertura;
                model.ID = oTienda.ID;
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult EditarT(TiendasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TredaEntities db = new TredaEntities())
                    {
                        var oTabla = db.Tiendas.Find(model.ID);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Fecha_de_Apertura = model.Fecha_de_Apertura;

                        db.Entry(oTabla).State= System.Data.Entity.EntityState.Modified;
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
        public ActionResult EliminarT(int ID)
        {
            TiendasViewModel model = new TiendasViewModel();
            using (TredaEntities db = new TredaEntities())
            {
                var oTienda = db.Tiendas.Find(ID);
                db.Tiendas.Remove(oTienda);
                db.SaveChanges();
            }
            return Redirect("~/Tiendas/");

        }
    }
}

