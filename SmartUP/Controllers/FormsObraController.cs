using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsObraController : Controller
    {
        // GET: Forms_financas

        public ActionResult frmBuscaObra()
        {
            ObraDAO ObraDAO = new ObraDAO();
            ViewBag.lstObra = ObraDAO.busca();
            return View();
        }

        public ActionResult frmCadastraObra()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Obra obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraCorrespondencia(Obra obj)
        {
            ObraDAO dao = new ObraDAO();
            dao.cadastraObra(obj);
            return RedirectToAction("frmBuscaObra");
        }
        public ActionResult CadastraContasAReceber(Obra obj)
        {
            ObraDAO dao = new ObraDAO();
            dao.cadastraObra(obj);
            return RedirectToAction("frmBuscaObra");
        }
    }
}