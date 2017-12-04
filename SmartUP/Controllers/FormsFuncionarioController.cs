using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsFuncionarioController : Controller
    {
        // GET: Forms_funcionario
        public ActionResult FrmBuscarInterno()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            ViewBag.lstFuncionario = funcionarioDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarTerceiro()
        {
            TerceiroDAO terceiroDAO = new TerceiroDAO();
            ViewBag.lstTerceiro = terceiroDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarInterno()
        {
            return View();
        }

        public ActionResult FrmCadastrarTerceiro()
        {
            return View();
        }
    }
}