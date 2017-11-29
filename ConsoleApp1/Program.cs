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
                id_cond = 1,
                nome = "Reserva Tropical",
                qtdBlocos = 4,
                proprietario = "Lello Imobiliaria",
                cnpj = "00001441445",
            };
            Area ar = new Area
            {
                nome = "Piscina",
                descricao = "Banhar-se",
                capacMax = 30,
                seAluga = false,
                ativo = true
            };
            Aviso av = new Aviso
            {
                id_aviso = 1,
                titulo = "Portão da garagem",
                descricao = "O portão vai ficar destavidado nos dias 30/11 e 31/11",
                cond = cond,
            };
            Bloco bl = new Bloco
            {
                id_bloco = 1,
                nome = "Flamboyant",
                qtAndares = 8,
                qtApto = 64,
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

            AreaDAO areaDAO = new AreaDAO();

            List<Area> listaArea = new List<Area>();

            /*CRIA*/
            //areaDAO.cadastra(ar);

            /*ALTERA*/
            //areaDAO.altera(ar);

            /*BUSCA*/
            listaArea = areaDAO.busca();
            foreach (Area area in listaArea)
            {
                Console.WriteLine(area.id_area + " " + area.nome + " " + area.capacMax.ToString() + " " + area.descricao + " " + area.seAluga.ToString());
            }

            Console.WriteLine(
                //leTeste+"\n"
                //"Condominio: "+cond.nome+"\n"+
                //"Bloco: "+bl.nome+"\n"+
                //"Unidade: "+uni.identificacao+"\n"
                );
            Console.ReadKey();
        }
    }
}
