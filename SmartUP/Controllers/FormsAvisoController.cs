using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsAvisoController : Controller
    {
        #region Aviso
        public ActionResult frmBuscaAviso()
        {
            AvisoDAO avisoDAO = new AvisoDAO();
            ViewBag.lstAviso = avisoDAO.busca();
            return View();
        }
        public ActionResult frmCadastraAviso(Bloco obj)
        {
            CondominioDAO dao = new CondominioDAO();
            ViewBag.lstCond = dao.busca();
            return View();
        }
        public ActionResult FrmAlteraAviso(Bloco obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        public ActionResult CadastrarAviso(Aviso obj)
        {
            AvisoDAO dao = new AvisoDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaAviso");
        }
        public ActionResult AlteraAviso(Aviso obj)
        {
            AvisoDAO dao = new AvisoDAO();
            dao.altera(obj);
            return RedirectToAction("frmBuscaAviso");
        }
        #endregion
    }
}