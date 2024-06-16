using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion1Grupo6.Modelos
{
    public class CuentaPremium:Cuenta
    {
        public CuentaPremium(string IdPropietario) :
                   base(IdPropietario, 1500)
        { }



    }
}
