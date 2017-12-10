using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsCondominioController : Controller
    {
        #region Condominio
        public ActionResult FrmBuscarCondominio()
        {
            //EnderecoDAO enderecoDAO = new EnderecoDAO();
            //List<Endereco> lstEndereco = enderecoDAO.busca();

            //foreach(Endereco e in lstEndereco)
            //{
            //    if(e.id_endereco == 2)
            //    {
            //        ViewBag.end = e;
            //    }
            //}
            CondominioDAO condominioDAO = new CondominioDAO();
            ViewBag.lstCond = condominioDAO.busca();
            return View();
            }
        public ActionResult FrmCadastrarCondominio(Condominio obj)
        {
           
            return View();
        }
        public ActionResult CadastraCondominio(Condominio obj)
        {
            CondominioDAO dao = new CondominioDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmCondominio");
        }
    #endregion
    }
}