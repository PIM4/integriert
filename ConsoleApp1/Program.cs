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

            
            Fornecedor forn = new Fornecedor
            {
                id_fornecedor = 1
            };
            Condominio cond = new Condominio
            {
                id_cond = 1,
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
            
            CondominioDAO objDAO = new CondominioDAO();
            Pessoa ps = new Pessoa
            {
                id_pessoa = 2,
                nome = "Leila Almeida",
                cpf = "00613465865",
                rg = "075586241",
                data_nasc = Convert.ToDateTime("1959-09-22")
            };
            
            Unidade uni = new Unidade
            { identificacao = "84", bloco = bl, ativo = true, vagas = 3, proprietario = ps, id_unidade = 1};
            ContaReceber cr = new ContaReceber
            {
                id_cr = 1,
                valor = 450,
                unidade = uni,
                condominio = cond,
            };
            Morador morador = new Morador()
            {
                nome = "Carlos",
                rg = "55555",
                cpf = "11111111111",
                ativo = true,
                data_nasc = DateTime.Now,
                unidade = uni
            };

            Terceiro tcr = new Terceiro
            {
                id_terceiro = 2,
                servico = "Limpeza",
                ativo = true,
                id_pessoa = 1,
                nome = "Paulo Silva",
                cpf = "22887730819",
                rg = "381605851",
                id_servico = 1,
                fornecedor = forn
            };

            Obra ob = new Obra
            {
                id_obra = 2,
                descricao_obra = "Reforma da piscina",
                dt_inicio = Convert.ToString(DateTime.Now),
                dt_previsao_termino = "2017-12-13",
                finalizada = true,
                area = ar,
                desc_tipo = "Conserto",
                ativo = true,
                id_tipo_obra = 1,
                cond = cond,
                dt_termino = Convert.ToDateTime("2017-12-15")
            };

            /*CRIA*/
            ObraDAO dao = new ObraDAO();
            //dao.cadastraObra(ob);

            /*ALTERA*/
            dao.altera((ob.dt_termino).ToString(), ob.finalizada, ob.id_obra);

            List<Obra> lstObj = dao.busca();
            
            //lstArea = objDAO.buscaT();
            

            /*BUSCA especifico*/
            
            foreach (Obra obj in lstObj)
            {
                Console.WriteLine(obj.id_obra.ToString() + " "
                    + obj.descricao_obra + " "
                    + obj.dt_inicio.ToString() + " "
                    + obj.dt_previsao_termino.ToString() + " "
                    + obj.finalizada.ToString() + " "
                    + obj.dt_termino.ToString()
                    );
                //Console.WriteLine(obj.id_pessoa.ToString() + " " + obj.nome + " " + obj.cpf + " " 
                //                    + obj.rg + " " + obj.data_nasc + " " + obj.fornecedor.id_fornecedor.ToString() 
                //                    + " " + obj.fornecedor.nomeEmpresa + " " + obj.id_servico.ToString()
                //                    + " " + obj.servico);
            }
            Console.ReadKey();
         }
    }
}
