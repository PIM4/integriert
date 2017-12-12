using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsCondominioController : Controller
    {
        #region Condominio
        public ActionResult frmBuscaCondominio()
        {
            CondominioDAO condominioDAO = new CondominioDAO();
            ViewBag.lstCond = condominioDAO.busca();
            return View();
            }
        public ActionResult frmCadastraCondominio(Condominio obj)
        {
            PessoaDAO dao = new PessoaDAO();
            ViewBag.lstPessoa = dao.busca();
            return View();
        }
        public ActionResult frmAlteraCondominio(Condominio obj)
        {
            PessoaDAO dao = new PessoaDAO();
            ViewBag.lstPessoa = dao.busca();
            return View();
        }
        public ActionResult CadastraCondominio(Condominio obj)
        {
            CondominioDAO dao = new CondominioDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaCondominio");
        }
        public ActionResult AlteraCondominio(Condominio obj)
        {
            CondominioDAO dao = new CondominioDAO();
            dao.altera(obj);
            return RedirectToAction("frmBuscaCondominio");
        }
        #endregion
    }
}