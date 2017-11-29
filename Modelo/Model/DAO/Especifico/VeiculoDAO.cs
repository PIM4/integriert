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

		//public Veiculo buscarVeiculoPorPlaca(string placa)
		//{
  //          return lstVeiculo;

  //      }

		public List<Veiculo> listarVeiculos()
		{
            return this.lstVeiculo;

        }

	}

}

