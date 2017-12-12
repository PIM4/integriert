using Model.DAO.Especifico;
using Model.Entity;
using SmartUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dash(Login user)
        {
            //if(Session["ADMLogado"] != null)
            //{
            //    ViewBag.type = "Administrador";
            //}
            //if (Session["PorteiroLogado"] != null)
            //{
            //    ViewBag.type = "Porteiro";
            //}
            //if (Session["MoradorLogado"] != null)
            //{
            //    ViewBag.type = "Morador";
            //}
            Session["ADMLogado"] = "Carlos";
            ViewBag.nome = user.login;
            return View();
        }

        public ActionResult Autenticacao(string email, string senha)
        {
            LoginDAO dao = new LoginDAO();
            Login user = dao.busca(email, senha);
            if (user.login == "")
            {
                if (user.permissao == 1)
                {
                    Session["ADMLogado"] = user.login;
                    
                }
                if (user.permissao == 2)
                {
                    Session["PorteiroLogado"] = user.login;
                }
                if (user.permissao == 3)
                {
                    Session["MoradorLogado"] = user.login;
                }
                ViewBag.Nome = user.login;
                return RedirectToAction("Dash", "Home", user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}