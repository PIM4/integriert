using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class VeiculoDAO
	{
        List<Veiculo> lstVeiculo = new List<Veiculo>();

        public bool cadastra(Veiculo veic)
		{
            return true;
        }

		//public Veiculo buscaPlaca(string placa)
		//{
  //          return lstVeiculo;

  //      }

		public List<Veiculo> busca()
		{
            return this.lstVeiculo;

        }

        public bool remove(int id)
        {
            return true;
        }

        public bool altera(Veiculo veic)
        {
            return true;
        }

    }

}

