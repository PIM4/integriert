using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsCorrespondenciaController : Controller
    {
        // GET: FormsCorrespondencia
        public ActionResult FrmBuscarCorrespondencia()
        {
            CorrespondenciaDAO corresDAO = new CorrespondenciaDAO();
            ViewBag.lstCorres = corresDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarCorrespondencia()
        {
            return View();
        }
    }
}