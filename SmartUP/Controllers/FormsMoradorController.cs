using Model.DAO.Especifico;
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

        public ActionResult FrmBuscarCorrespondencia()
        {
            CorrespondenciaDAO corresDAO = new CorrespondenciaDAO();
            ViewBag.lstCorres = corresDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarEnquete()
        {
            EnquetesDAO enqueteDAO = new EnquetesDAO();
            ViewBag.lstEnquete = enqueteDAO.buscaEnquete();
            return View();
        }

        public ActionResult FrmBuscarEvento()
        {
            EventoDAO eventoDAO = new EventoDAO();
            ViewBag.lstEvento = eventoDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarReclamacao()
        {
            ReclamSugestDAO reclamDAO = new ReclamSugestDAO();
            ViewBag.lstReclam = reclamDAO.busca();
            return View();
        }

        public ActionResult FrmBuscarSugestao()
        {
            ReclamSugestDAO sugestDAO = new ReclamSugestDAO();
            ViewBag.lstSugest = sugestDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarMorador()
        {
            return View();
        }

        public ActionResult FrmCadastrarCorrespondencia()
        {
            return View();
        }

        public ActionResult FrmCadastrarEnquete()
        {
            return View();
        }

        public ActionResult FrmCadastrarEvento()
        {
            return View();
        }

        public ActionResult FrmCadastrarReclamacao()
        {
            return View();
        }

        public ActionResult FrmCadastrarSugestao()
        {
            return View();
        }
    }
}