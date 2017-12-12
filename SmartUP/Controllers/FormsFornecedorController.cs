using Model.DAO.Especifico;
using Model.Entity;
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
        public ActionResult frmBuscaFornecedor()
        {
            FornecedorDAO fornecedorDAO = new FornecedorDAO();
            ViewBag.lstFornecedor = fornecedorDAO.busca();
            return View();
        }

        public ActionResult frmCadastraFornecedor()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Fornecedor obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraCorrespondencia(Fornecedor obj)
        {
            FornecedorDAO dao = new FornecedorDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaFornecedor");
        }
        public ActionResult CadastraContasAReceber(Fornecedor obj)
        {
            FornecedorDAO dao = new FornecedorDAO();
            dao.altera(obj);
            return RedirectToAction("frmBuscaFornecedor");
        }
    }
}