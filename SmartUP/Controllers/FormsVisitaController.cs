using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsVisitaController : Controller
    {
        #region Visita
        public ActionResult FrmBuscarVisita()
        {
            VisitaDAO visitaDAO = new VisitaDAO();
            ViewBag.lstVisita = visitaDAO.busca();
            return View();
        }
        public ActionResult FrmCadastrarVisita()
        {
            VisitanteDAO daoV = new VisitanteDAO();
            UnidadeDAO daoU = new UnidadeDAO();
            ViewBag.lstVisitante = daoV.busca();
            ViewBag.lstUnidade = daoU.busca();

            return View();
        }
        public ActionResult CadastraVisita(Visita obj)
        {
            VisitaDAO dao = new VisitaDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarVisita");
        }
        #endregion
    }
}