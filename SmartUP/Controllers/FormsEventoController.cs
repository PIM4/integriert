using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsEventoController : Controller
    {
        public ActionResult FrmBuscarEvento()
        {
            EventoDAO eventoDAO = new EventoDAO();
            ViewBag.lstEvento = eventoDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarEvento()
        {
            return View();
        }
    }
}