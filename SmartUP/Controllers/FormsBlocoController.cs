using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsBlocoController : Controller
    {
        #region Bloco
        public ActionResult FrmBuscarBloco()
        {
            UnidadeDAO unidadeDAO = new UnidadeDAO();
            List<Unidade> totUni = unidadeDAO.busca();
            BlocoDAO blocoDAO = new BlocoDAO();
            List<Bloco> lstBloco = blocoDAO.busca();
            int tot = 0;
            foreach (Bloco b in lstBloco)
            {
                tot = 0;
                foreach (Unidade u in totUni)
                {
                    if (u.bloco.id_bloco == b.id_bloco)
                    {
                        tot += 1;
                    }
                }
                b.totUnidade = tot;
            }

            ViewBag.lstBloco = lstBloco;
            return View();
        }
        public ActionResult FrmCadastrarBloco()
        {
            CondominioDAO dao = new CondominioDAO();
            ViewBag.lstCond = dao.busca();
            return View();
        }
        public ActionResult FrmAlterarBloco(Bloco obj)
        {
            //if (obj != null)
            //{
            BlocoDAO daoBloco = new BlocoDAO();
            CondominioDAO condDAO = new CondominioDAO();
            List<Condominio> lstCond = condDAO.busca();
            List<Bloco> lstbloco = daoBloco.busca();
            foreach (Bloco bloco in lstbloco)
            {
                if (bloco.id_bloco == obj.id_bloco)
                {
                    foreach (Condominio cond in lstCond)
                    {
                        if (cond.id_cond == bloco.cond.id_cond)
                        {
                            bloco.cond = cond;
                            ViewBag.bloco = bloco;
                            return View();
                        }
                    }

                }
            }
            return View();

            //}
            //return RedirectToAction("frmBuscarBloco");
        }
        public ActionResult CadastrarBloco(Bloco obj)
        {
            BlocoDAO dao = new BlocoDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarBloco", "FormsCondominio");
        }
        
        #endregion
    }
}