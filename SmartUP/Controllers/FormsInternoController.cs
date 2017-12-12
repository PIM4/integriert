using Model.DAO.Especifico;
using Model.Entity;
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
        public ActionResult frmBuscaInterno()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            ViewBag.lstFuncionario = funcionarioDAO.busca();
            return View();
        }

        public ActionResult frmCadastraInterno()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Funcionario obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraCorrespondencia(Funcionario obj)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaFuncionario");
        }
        public ActionResult CadastraContasAReceber(Funcionario obj)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaFuncionario");
        }
    }
}