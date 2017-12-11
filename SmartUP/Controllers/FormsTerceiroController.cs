using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsTerceiroController : Controller
    {
        // GET: Forms_funcionario

        public ActionResult FrmBuscarTerceiro()
        {
            TerceiroDAO terceiroDAO = new TerceiroDAO();
            ViewBag.lstTerceiro = terceiroDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarTerceiro()
        {
            return View();
        }
    }
}