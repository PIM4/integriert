using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsMoradorController : Controller
    {
        // GET: Forms_morador
        public ActionResult FrmBuscarMorador()
        {
            MoradorDAO moradorDAO = new MoradorDAO();
            ViewBag.lstMorador = moradorDAO.busca();
            return View();
        }
        public ActionResult FrmCadastrarMorador()
        {
            UnidadeDAO dao = new UnidadeDAO();
            ViewBag.lstUnidade = dao.busca();
            return View();
        }
        public ActionResult CadastraMorador(Morador obj)
        {
            MoradorDAO dao = new MoradorDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarMorador");
        }

    }
}