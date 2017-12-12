using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsTerceiroController : Controller
    {
        // GET: Forms_funcionario

        public ActionResult frmBuscaTerceiro()
        {
            TerceiroDAO terceiroDAO = new TerceiroDAO();
            ViewBag.lstTerceiro = terceiroDAO.busca();
            return View();
        }

        public ActionResult frmCadastraTerceiro()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Terceiro obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraCorrespondencia(Terceiro obj)
        {
            TerceiroDAO dao = new TerceiroDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaTerceiro");
        }
        public ActionResult CadastraContasAReceber(Terceiro obj)
        {
            TerceiroDAO dao = new TerceiroDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaTerceiro");
        }
    }
}