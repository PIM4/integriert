using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsFinancasController : Controller
    {
        // GET: Forms_financas
        public ActionResult FrmBuscarContasAPagar()
        {
            ContaPagarDAO contaPagarDAO = new ContaPagarDAO();
            ViewBag.lstContaPagar = contaPagarDAO.buscaTipo();
            return View();
        }

        public ActionResult FrmBuscarContasAReceber()
        {
            ContaReceberDAO contaReceberDAO = new ContaReceberDAO();
            ViewBag.lstContaReceber = contaReceberDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarFornecedor()
        {
            FornecedorDAO fornecedorDAO = new FornecedorDAO();
            ViewBag.lstFornecedor = fornecedorDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarObra()
        {
            ObraDAO ObraDAO = new ObraDAO();
            ViewBag.lstObra = ObraDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarContasAPagar()
        {
            return View();
        }

        public ActionResult FrmCadastrarContasAReceber()
        {
            return View();
        }

        public ActionResult FrmCadastrarFornecedor()
        {
            return View();
        }

        public ActionResult FrmCadastrarObra()
        {
            return View();
        }
    }
}