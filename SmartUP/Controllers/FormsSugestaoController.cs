using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsSugestaoController : Controller
    {
        // GET: FormsSugestao
        public ActionResult FrmBuscarSugestao()
        {
            ReclamSugestDAO sugestDAO = new ReclamSugestDAO();
            ViewBag.lstSugest = sugestDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarSugestao()
        {
            return View();
        }
    }
}