using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsEventoController : Controller
    {
        public ActionResult frmBuscaEvento()
        {
            EventoDAO eventoDAO = new EventoDAO();
            ViewBag.lstEvento = eventoDAO.busca();
            return View();
        }

        public ActionResult frmCadastraEvento()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Evento obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraEvento(Evento obj)
        {
            EventoDAO dao = new EventoDAO();
            dao.cadastraEvento(obj);
            return RedirectToAction("frmBuscaEvento");
        }
        public ActionResult AlteraEvento(Evento obj)
        {
            EventoDAO dao = new EventoDAO();
            dao.altera(obj);
            return RedirectToAction("frmBuscaEvento");
        }
    }
}