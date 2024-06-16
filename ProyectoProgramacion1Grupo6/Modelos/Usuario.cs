using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion1Grupo6.Modelos
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string TipoCuenta { get; set; }
        public string Identidad { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string FechaNacimiento { get; set; }

        public bool EsAdmin { get; set; }


        public Usuario(string nombre, string contrasena, string tipoCuenta, string identidad, string telefonoMovil,
            string correoElectronico, string fechaNacimiento, bool esAdmin)
        {
            Nombre = nombre;
            Contrasena = contrasena;
            TipoCuenta = tipoCuenta;
            Identidad = identidad;
            TelefonoMovil = telefonoMovil;
            CorreoElectronico = correoElectronico;
            FechaNacimiento = fechaNacimiento;
            EsAdmin = esAdmin;


        }
    }
}
