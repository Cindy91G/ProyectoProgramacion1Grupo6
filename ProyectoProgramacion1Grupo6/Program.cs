using ProyectoProgramacion1Grupo6.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion1Grupo6
{

    public class Program
    {
        public static List<Usuario> usuarios = new List<Usuario>
        { new Usuario("admin", "admin123", "PREMIUM", "0801199012345", "98765432",
            "admin@banco.com", "01/01/1990", true),
          new Usuario("usuario", "password", "BASICA", "0801199087654", "12345678",
              "usuario@email.com", "15/06/1995",false)};


        public static List<Cuenta> cuentas = new List<Cuenta>();
        public static Usuario usuarioActual = null;

        public static void Main(string[] args)
        {
            MenuInicial();

        }


        static void MenuInicial()
        {
            Console.WriteLine("======Bienvenido al Cajero Automatico del Banco T1172======");

            int salir = 0;

            do
            {
                Console.Write("Ingrese el email de usuario: ");
                string correoElectronico = Convert.ToString(Console.ReadLine());
                Console.Write("Ingrese la contraseña: ");
                string contrasena = Convert.ToString(Console.ReadLine());

                Usuario usuario = null;
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuarios[i].CorreoElectronico == correoElectronico && usuarios[i].Contrasena == contrasena)
                    {
                        usuario = usuarios[i];
                        break;
                    }
                }


                if (usuarios != null)
                {
                    usuarioActual = usuario;
                    if (usuarioActual.EsAdmin)
                    {
                        Console.WriteLine("Inicio de sesion exitoso.");
                        Console.WriteLine("Hola Admin; Bienvenido al Cajero Automatico del Banco T1172");
                        MenuAdministrador();
                    }
                    else
                    {
                        Console.WriteLine("Inicio de sesion exitoso.");
                        Console.WriteLine("Hola; Bienvenido al Cajero Automatico del Banco T1172");
                        MenuCliente();
                    }

                }
                else
                {
                    Console.WriteLine("Email de usuario o contrasena incorrectos.");
                }


            }

            while (salir != 0);

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();


        }

        static int ObtenerOpcionValida()
        {
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                Console.Write("Opción invalida. Intente nuevamente: ");
            }
            return opcion;
        }



        //FUNCION PARA AGREGAR UNA CUENTA
        static void AgregarCuenta()
        {
            Console.Write("Ingrese el ID del propietario: ");
            string idPropietario = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese el tipo de cuenta (BASICA o PREMIUM): ");
            string tipoCuenta = Convert.ToString(Console.ReadLine().ToUpper());

            Cuenta nuevaCuenta;

            if (tipoCuenta == "BASICA")
            {
                nuevaCuenta = new CuentaBasica(idPropietario);
            }
            else if (tipoCuenta == "PREMIUM")
            {
                nuevaCuenta = new CuentaPremium(idPropietario);
            }
            else
            {
                Console.WriteLine("Tipo de Cuenta invalido. Se asignara una cuenta BASICA,");
                nuevaCuenta = new CuentaBasica(idPropietario);
            }

            cuentas.Add(nuevaCuenta);
            Console.WriteLine("Cuenta agregada correctamente.");
            MenuInicial();
        }

        //FUNCION PARA ELIMAR CUENTA
        public static void EliminarCuenta()
        {
            Console.Write("Ingrese el ID de la cuenta a eliminar: ");
            string idCuenta = Convert.ToString(Console.ReadLine());

            int index = -1;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].IdPropietario == idCuenta)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                cuentas.RemoveAt(index);
                Console.WriteLine("Cuenta eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
        }



        //FUNCION MENU DE OPERACIONES ADMINISTRADOR
        public static void MenuAdministrador()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n===== Operaciones Administrador =====");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Eliminar usuario");
                Console.WriteLine("3. Agregar cuenta");
                Console.WriteLine("4. Eliminar cuenta");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opcion: ");

                int opcion = ObtenerOpcionValida();

                switch (opcion)
                {
                    case 1:
                        RegistrarUsuario();
                        break;
                    case 2:
                        EliminarUsuario();
                        break;
                    case 3:
                        AgregarCuenta();
                        break;
                    case 4:
                        EliminarCuenta();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                
            }
        }

        // FUNCION PARA REGISTRAR USUARIO POR EL ADMINISTRADOR
        public static void RegistrarUsuario()
        {
            Console.Write("Ingrese el nombre de usuario: ");
            string nombre = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese la contrasena: ");
            string contrasena = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese el tipo de cuenta (BASICA o PREMIUM): ");
            string tipoCuenta = Convert.ToString(Console.ReadLine().ToUpper());

            if (tipoCuenta != "BASICA" && tipoCuenta != "PREMIUM")
            {
                Console.WriteLine("Tipo de cuenta invalido. Se asignara una cuenta BASICA.");
                tipoCuenta = "BASICA";
            }

            Console.Write("Ingrese su identidad: ");
            string identidad = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese su telefono movil: ");
            string telefonoMovil = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese su correo electronico: ");
            string correoElectronico = Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese su fecha de nacimiento (dd/mm/yyyy): ");
            string fechaNacimiento = Convert.ToString(Console.ReadLine());



            Usuario nuevoUsuario = new Usuario(nombre, contrasena, tipoCuenta,
                identidad, telefonoMovil, correoElectronico, fechaNacimiento, false);
            usuarios.Add(nuevoUsuario);
            Console.WriteLine("Usuario registrado correctamente.");
            MenuInicial();
        }

        //FUNCION PARA ELIMINAR USUARIO POR EL ADMINISTRADOR
        public static void EliminarUsuario()
        {
            Console.Write("Ingrese el Email de usuario a eliminar: ");
            string correoEliminar = Convert.ToString(Console.ReadLine());

            int index = -1;
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].CorreoElectronico == correoEliminar)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                usuarios.RemoveAt(index);
                Console.WriteLine("Usuario eliminado correctamente.");
                MenuInicial();
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }





        //FUNCION PARA MENU DE OPERACIONES BANCARIAS USUARIO CLIENTE
        public static void MenuCliente()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n===== Operaciones Bancarias Cliente =====");
                Console.WriteLine("1. Agregar cuenta");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Verificar saldo");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opcion: ");

                int opcion = ObtenerOpcionValida();

                switch (opcion)
                {

                    case 1:
                        AgregarCuenta();
                        break;
                    case 2:
                        RetirarDinero();
                        break;
                    case 3:
                        DepositarDinero();
                        break;
                    case 4:
                        VerificarSaldo();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción invalida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();

            }
        }

        //FUNCION PARA HACER DEPOSITO DE DINERO A LA CUENTA
        public static void DepositarDinero()
        {
            Console.Write("Ingrese el ID de la cuenta: ");
            string idCuenta = Convert.ToString(Console.ReadLine());

            Cuenta cuenta = null;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].IdPropietario == idCuenta)
                {
                    cuenta = cuentas[i];
                    break;
                }
            }

            if (cuenta != null && cuenta.IdPropietario == usuarioActual.Identidad)
            {
                Console.Write("Ingrese el monto a depositar: ");
                double monto = Convert.ToDouble(Console.ReadLine());

                cuenta.Saldo += monto;
                Console.WriteLine("Depósito exitoso. Saldo actual: " + cuenta.Saldo);
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada o no es el propietario.");
            }
        }

        //FUNCION PARA HACER RETIRO DE DINERO
        public static void RetirarDinero()
        {
            Console.Write("Ingrese el ID de la cuenta: ");
            string idCuenta = Convert.ToString(Console.ReadLine());

            Cuenta cuenta = null;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].IdPropietario == idCuenta)
                {
                    cuenta = cuentas[i];
                    break;
                }
            }

            if (cuenta != null && cuenta.IdPropietario == usuarioActual.Identidad)
            {
                Console.Write("Ingrese el monto a retirar: ");
                double monto = Convert.ToDouble(Console.ReadLine());

                if (cuenta.Saldo >= monto)
                {
                    cuenta.Saldo -= monto;
                    Console.WriteLine("Retiro exitoso. Saldo actual: " + cuenta.Saldo);
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada o no es el propietario.");
            }
        }

        //FUNCION PARA REVISAR SALDO DE LA CUENTA
        public static void VerificarSaldo()
        {
            Console.Write("Ingrese el ID de la cuenta: ");
            string idCuenta = Convert.ToString(Console.ReadLine());

            Cuenta cuenta = null;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].IdPropietario == idCuenta)
                {
                    cuenta = cuentas[i];
                    break;
                }
            }

            if (cuenta != null && cuenta.IdPropietario == usuarioActual.Identidad)
            {
                Console.WriteLine("Saldo actual: " + cuenta.Saldo);
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada o no es el propietario.");
            }
        }

    }
}