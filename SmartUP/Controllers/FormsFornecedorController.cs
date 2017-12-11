using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsFornecedorController : Controller
    {
        // GET: FormsFornecedor
        public ActionResult FrmBuscarFornecedor()
        {
            FornecedorDAO fornecedorDAO = new FornecedorDAO();
            ViewBag.lstFornecedor = fornecedorDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarFornecedor()
        {
            return View();
        }
    }
}