using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Model.DAO.Especifico
{
    interface IFacede
    {
        bool cadastra(Area obj);
        bool altera();
        bool remove();
    }
}
