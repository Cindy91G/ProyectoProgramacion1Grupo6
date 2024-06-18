using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion1Grupo6.Modelos
{
    //Clase derivada de la clase padre/base cuenta
    public class CuentaPremium:Cuenta
    {
        //Invocando  contructor de la clase base
        public CuentaPremium(string IdPropietario) :
                   base(IdPropietario, 1500)
        { }



    }
}
