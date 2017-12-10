using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsUnidadeController : Controller
    {
        #region Unidade
        public ActionResult FrmBuscarUnidade()
        {
            UnidadeDAO unidadeDAO = new UnidadeDAO();
            BlocoDAO blocoDAO = new BlocoDAO();
            PessoaDAO pessoaDAO = new PessoaDAO();
            List<Pessoa> lstPessoa = pessoaDAO.busca();
            List<Bloco> lstBloco = blocoDAO.busca();
            List<Unidade> lstUnidade = unidadeDAO.busca();
            Pessoa pessoa = new Pessoa();
            Bloco bloco = new Bloco();
            foreach (Unidade u in lstUnidade)
            {
                foreach (Pessoa p in lstPessoa)
                {
                    foreach (Bloco b in lstBloco)
                    {
                        if (b.id_bloco == u.bloco.id_bloco && p.id_pessoa == u.proprietario.id_pessoa)
                        {
                            u.bloco = b;
                            u.proprietario = p;
                        }
                    }
                }
            }
            ViewBag.lstUnidade = lstUnidade;

            return View();
        }
        public ActionResult FrmCadastrarUnidade()
        {
            PessoaDAO daoP = new PessoaDAO();
            BlocoDAO daob = new BlocoDAO();
            ViewBag.lstBloco = daob.busca();
            ViewBag.lstPessoa = daoP.busca();
            return View();
        }
        public ActionResult CadastrarUnidade(Unidade obj)
        {
            UnidadeDAO dao = new UnidadeDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarUnidade");
        }
        #endregion
    }
}