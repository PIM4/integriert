using Model.DAO.Especifico;
using Model.DAO.Generico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Unidade uni = new Unidade { identificacao = "84"};
            Fornecedor forn = new Fornecedor();
            Condominio cond = new Condominio
            {
                nome = "Reserva Tropical",
                dataInauguracao = DateTime.Now,
                proprietario = "Lello Imobiliaria",
                cnpj = "00001441445",
            };
            Area ar = new Area
            {
                id_area = 6,
                nome = "Piscina",
                descricao = "Piscina Infantil",
                capacMax = 10,
                seAluga = true,
                ativo = true
            };
            Aviso av = new Aviso
            {
                titulo = "Portão da garagem",
                descricao = "O portão vai ficar destavidado nos dias 30/11 e 31/11",
                cond = cond,
                
            };
            Bloco bl = new Bloco
            {
                id_bloco = 1,
                nome = "Flamboyant",
                cond = cond,
            };
            ContaPagar cp = new ContaPagar
            {
                id_cp = 1,
                valor = 300,
                id_tipo = 1,
                desc_conta = "Manutenção do portão",
                fornecedor = forn,
                condominio = cond,
            };
            ContaReceber cr = new ContaReceber
            {
                id_cr = 1,
                valor = 450,
                unidade = uni,
                condominio = cond,
            };

            CondominioDAO objDAO = new CondominioDAO();


            /*CRIA*/

            
            List<Condominio> cd = objDAO.busca();
            
            //lstArea = objDAO.busca();
            /*ALTERA*/
            //areaDAO.altera(ar);

            /*BUSCA especifico*/
            
            foreach (Condominio obj in cd)
            {
                Console.WriteLine(obj.id_cond + "\n" + obj.nome + "\n" + obj.qtdBlocos);
            }
            Console.ReadKey();
         }
    }
}
