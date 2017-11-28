using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.DAO.Generico;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cargo
    {
        public Cargo()
        {

        }

        public Cargo(string descricao)
        {

        }

        public int id_cargo { get; set; }

        public string descricao { get; set; }
    }
}
