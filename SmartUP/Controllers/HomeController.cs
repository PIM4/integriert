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

        public ActionResult Dash()
        {
            return View();
        }

        public ActionResult Autenticacao(string email, string senha)
        {
            //LoginDAO dao = new LoginDAO();
            //Login user = dao.busca(email, senha);
            //if (user != null)
            //{
            //    Session["usuarioLogado"] = user.login;
            //    Session["Permission"] = user.permissao;
            //    return RedirectToAction("Dash", "Home");
            //}
            //else
            //{
             return RedirectToAction("Index", "Home");
            //}
        }
    }
}