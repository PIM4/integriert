using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsReclamacaoController : Controller
    {
        // GET: FormsReclamacao
        public ActionResult FrmBuscarReclamacao()
        {
            ReclamSugestDAO reclamDAO = new ReclamSugestDAO();
            ViewBag.lstReclam = reclamDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarReclamacao()
        {
            return View();
        }
    }
}