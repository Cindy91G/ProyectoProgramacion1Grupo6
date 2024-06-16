using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion1Grupo6.Modelos
{
    public class Cuenta
    {
        public string IdPropietario { get;  set; }
        public double Saldo { get; set; }

        public Cuenta(string idPropietario,double saldoInicial)
        {           
            IdPropietario = idPropietario;
            Saldo = saldoInicial;
        }
        public void Depositar(double monto)
        { 
            Saldo += monto;
        }
        public bool Retirar(double monto) 
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
