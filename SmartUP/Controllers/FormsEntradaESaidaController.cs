using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsEntradaESaidaController : Controller
    {
        // GET: Forms_visita
        public ActionResult FrmBuscarVisita()
        {
            VisitaDAO visitaDAO = new VisitaDAO();
            ViewBag.lstVisita = visitaDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarVisitante()
        {
            VisitanteDAO visitanteDAO = new VisitanteDAO();
            ViewBag.lstVisitante = visitanteDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarVisita()
        {
            return View();
        }

        public ActionResult FrmCadastrarVisitante()
        {
            return View();
        }
    }
}