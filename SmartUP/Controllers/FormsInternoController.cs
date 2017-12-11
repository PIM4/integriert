using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsInternoController : Controller
    {
        // GET: FormsInterno
        public ActionResult FrmBuscarInterno()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            ViewBag.lstFuncionario = funcionarioDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarInterno()
        {
            return View();
        }
    }
}