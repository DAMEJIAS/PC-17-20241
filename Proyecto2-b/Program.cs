/*

Proyecto 2
Diego Mejia - 1044424

*/

namespace Proyecto2_BANCOextended
{
    class Program
    {       
        static int contador = 0;
        static int cuenta1 = 0;
        private static string Nombre;
        private static int DPI;
        private static int NumeroTelefonico;
        private static string Direccion;
        private static decimal saldoin;
        private static string tip;
        private static List<Transaccion> transacciones = new List<Transaccion>();

        
        

        static void Main(string[] args)
        {
            int cuenta1 = 0;
            saldoin = 2500; //se declara el saldo inicial de la cuenta
            ingresodatos();
            decimal saldo = 100.0m;
            // Crear un hilo para el ciclo infinito
            Thread hiloInfinito = new Thread(CicloInfinito);
            hiloInfinito.Start();
            menu();

            if (contador > 30)
            {
                cuenta1 = 0;
            }
        }

        static void ingresodatos()
        {
            bool esValido;
            Console.WriteLine("DATOS DEL USUARIO\n");

            // INGRESO DE NOMBRE DE USUARIO
            do
            {
                Console.WriteLine("Ingrese su primer nombre y su primer apellido:");
                Nombre  = Console.ReadLine();
                esValido = verificar(Nombre);
                if (!esValido)
                {
                    Console.WriteLine("Nombre no valido");
                }
            } while (!esValido); // VERIFICACION DE NOMBRE
            Console.WriteLine("");

            // INGRESO DE DPI
            do
            {
                Console.WriteLine("Ingrese Su DPI (5 dígitos):");
                string inputDPI = Console.ReadLine();
                try
                {
                    DPI = int.Parse(inputDPI);
                    if (inputDPI.Length != 5)
                    {
                        Console.WriteLine("DPI debe contener 5 dígitos.");
                        esValido = false;
                    }
                    else
                    {
                        esValido = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un valor numérico válido para DPI.");
                    esValido = false;
                }
            } while (!esValido);
            Console.WriteLine("");

            // INGRESO DE TELEFONO
            do
            {
                Console.WriteLine("Ingrese Su Numero Telefonico (8 dígitos)");
                string inputNumero = Console.ReadLine();
                try
                {
                    NumeroTelefonico = int.Parse(inputNumero);
                    if (inputNumero.Length != 8)
                    {
                        Console.WriteLine("Número de Teléfono debe contener 8 dígitos.");
                        esValido = false;
                    }
                    else
                    {
                        esValido = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Ingrese un valor numérico válido para el número telefónico."
                    );
                    esValido = false;
                }
            } while (!esValido);
            Console.WriteLine("");

            // INGRESO DE LA DIRECCION
            Console.WriteLine("Ingrese Su Direccion");
            Direccion = Console.ReadLine();

            cuenta();
        }

        static void menu()
        {
            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                //INICIO DEL LOOP DEL MENU HASTA QUE SE SELECCIONE LA OPCION 11
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("MENU DE USUARIO");
                Console.WriteLine("1. VER INFORMACION DE LA CUENTA");
                Console.WriteLine("2. COMPRAR UN PRODUCTO FINANCIERO");
                Console.WriteLine("3. VENDER PRODUCTO FINANCIERO");
                Console.WriteLine("4. ABONAR A CUENTA");
                Console.WriteLine("5. INTERESES");
                Console.WriteLine("6. VER TRANSACCIONES");
                Console.WriteLine("7. HACER TRANSFERENCIAS");
                Console.WriteLine("8. MANTENIMIENTO DE CUENTAS");
                Console.WriteLine("9. PAGO DE SERVICIOS");
                Console.WriteLine("10.HISTORIAL DE LAS TRANSACCIONES");
                Console.WriteLine("11. SALIR DEL PROGRAMA");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("INGRESE LA OPCION QUE DESEA EFECTUAR");

                int numero;
                try
                {
                    numero = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

                switch (numero)
                {
                    case 1:
                        InfoCuenta();
                        break;
                    case 2:
                        Console.WriteLine("COMPRAR UN PRODUCTO FINANCIERO");
                        Comprar();
                        break;
                    case 3:
                        Vender();
                        break;
                    case 4:
                        Console.WriteLine("ABONAR A CUENTA");
                        Abonar();
                        break;
                    case 5:
                        Console.WriteLine("INTERESES");
                        Console.WriteLine("Los intereses de su cuenta son de: " + saldoin);
                        Console.ReadKey();
                        break;
                    case 6:
                        VerTransacciones();
                        break;
                    case 7:
                        Mantenimiento();
                        break;
                    case 8:
                        CuentasTerceros();
                        break;
                    case 9:
                        PagoServicios();
                        break;
                    case 10:
                        InformeTrans();
                        break;
                    case 11:
                        Console.WriteLine("GRACIAS POR SU PREFERENCIA!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        break;
                }
            }
        }

        public static void cuenta()
        {
            Console.WriteLine("Selecciona un tipo de cuenta:");
            Console.WriteLine("1. monetaria quetzales");
            Console.WriteLine("2. monetaria dolares");
            Console.WriteLine("3. ahorro quetzales");
            Console.WriteLine("4. ahorro dólares");

            int tipoCuenta;
            try
            {
                tipoCuenta = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingrese un número válido.");
                return;
            }

            switch (tipoCuenta)
            {
                case 1:
                    tip = "monetaria quetzales";
                    break;
                case 2:
                    tip = "monetaria dolares";
                    break;
                case 3:
                    tip = "ahorro quetzales";
                    break;
                case 4:
                    tip = "ahorro dólares";
                    break;
                default:
                    Console.WriteLine("Opción no válida. ");
                    break;
            }
        }

        public static void InfoCuenta() //METODO PARA SOLICITAR Y MOSTRAR DATOS DEL USUARIO
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("VER INFORMACION DE LA CUENTA");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"DPI: {DPI}");
            Console.WriteLine($"Numero Telefonico: {NumeroTelefonico}");
            Console.WriteLine($"Direccion: {Direccion}");
            Console.WriteLine($"Saldo Inicial: {saldoin}");
            Console.WriteLine($"Su cuenta es de tipo: {tip}");
            Console.WriteLine("-------------------------------------");

            Console.ReadKey();
        }

        public static void Comprar() //COMPRA DE PRODUCTO FINANCIERO
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ha ingresado a la compra de producto financiero");
            Console.WriteLine("Desea realizar una compra?");
            Console.WriteLine("Ingresar 'y' para si o 'n' para no");
            Console.WriteLine("-------------------------------------");

            char opcion2 = Console.ReadLine().ToLower()[0];
            //VARIABLES EN DECIMAL PARA PODER OPERAR DECIMALES
            decimal multp = 0.1m;
            decimal resultado = 0.0m;
            decimal totaln = 0.0m;

            if (opcion2 == 'y')
            {
                //RESULTADO DE LA OPERACION
                resultado = saldoin * multp;
                totaln = saldoin - resultado;
                //SE GUARDA EL RESULTADO EN LA VARIABLE DE LA CUENTA INICIAL PARA PODER REEMPLAZAR VALORES
                saldoin = totaln;
                Pitagora(resultado, "Transaccion de débito");
                Console.WriteLine(saldoin);
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
            else if (opcion2 == 'n')
            {
                Console.ReadKey();
            }
        }

        public static void Vender()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ha ingresado a la venta de producto financiero");
            Console.WriteLine("Desea realizar una venta?");
            Console.WriteLine("Ingresar 's' para sí o 'n' para no");
            Console.WriteLine("-------------------------------------");

            char opcionv = Console.ReadLine().ToLower()[0];
            //VARIABLES DECLARADAS COMO DECIMALES
            decimal porc = 0.11m;
            decimal resultado = 0.0m;
            decimal totaln = 0.0m;

            if (opcionv == 's')
            {
                if (saldoin > 500)
                {
                    //SE OPERA LA VENTA DE PRODUCTO FINANCIERO
                    resultado = saldoin * porc;
                    totaln = saldoin + resultado;
                    //SE IGUALA A EL VALOR DE LA CUENTA INICIAL PARA REEMPLAZAR
                    saldoin = totaln;

                    Pitagora(resultado, "Transaccion de crédito");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Ha vendido un producto financiero.");
                    Console.WriteLine("Saldo total: " + saldoin);
                    Console.WriteLine("-------------------------------------");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("No cuenta con el saldo suficiente para esta operación.");
                    Console.WriteLine("Saldo mínimo para realizar esta operación es de Q500");
                    Console.WriteLine("-------------------------------------");
                    Console.ReadKey();
                }
            }
            else if (opcionv == 'n')
            {
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Opción no válida.");
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
        }

        public static void Abonar()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Abonar el doble a su cuenta?");
            Console.WriteLine("Solo puede realizar esta acción 1 vez cada 2 meses");
            Console.WriteLine("-------------------------------------");
            Console.ReadKey();

            //VARIABLE DONDE SE CUENTA LA CANTIDAD DE VECES QUE SE INGRESA A ESTA OPCION
            cuenta1++;

            //SE VERIFICA SI ES DENTRO DEL MES QUE SE REALIZA LA OPCION
            if (contador < 30 && contador > 0 && cuenta1 <= 1)
            {
                decimal abono = saldoin;
                saldoin = saldoin * 2;
               Pitagora(abono, "Trnsaccion de crédito");
                Console.WriteLine("Se ha abonado exitosamente, su nuevo saldo es:");
                Console.WriteLine(saldoin);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("No puede abonar a su cuenta");
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
        }

        static void CicloInfinito()
        {
            while (true)
            {
                Thread.Sleep(1000); // Pausa de 1 segundo (ajustable)
                //UN SEGUNDO EQUIVALE A UN DIA
                contador++;
                decimal interes = 0;

                if (contador == 30)
                {
                    //CADA VEZ QUE SE LLEGUE A 30 DIAS SE REALIZA:
                    //SE REGRESA EL CONTADOR A 0
                    contador = 0;
                    cuenta1 = 0;
                    //SE OPERA LA TASA DE INTERES
                    interes = saldoin * 0.02m * 0.083m;
                    //SE SUMAN LOS INTERESES EN SEGUNDO PLANO
                    saldoin = interes + saldoin;
                   Pitagora(interes, "Trnsaccion de crédito");
                }
            }
        }
        static void InformeTrans()
        {
            VerTransacciones();
        }
        static bool verificar(string Nombre)
        {
            // Ajustado para comprobar si el nombre tiene entre 3 y 25 caracteres
            if (string.IsNullOrWhiteSpace(Nombre) || Nombre.Length < 3 || Nombre.Length > 30)
            {
                return false;
            }

            return true;
        }

        static void Pitagora(decimal monto, string tipo)
        {
            transacciones.Add(
                new Transaccion
                {
                    Fecha = DateTime.Now,
                    Monto = monto,
                    Tipo = tipo
                }
            );
        }

        static void VerTransacciones()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("LISTADO DE TRANSACCIONES");
            foreach (var transaccion in transacciones)
            {
                Console.WriteLine(
                    $"{transaccion.Fecha} - {transaccion.Monto} - {transaccion.Tipo}"
                );
            }
            Console.WriteLine("-------------------------------------");
            Console.ReadKey();
        }

         static void Mantenimiento()
        {
         
        Console.Write("Ingrese la cantidad de transferencias que desea hacer: ");
        int cantidadtrans = Convert.ToInt32(Console.ReadLine());

        // hice un arreglo para guardar las ransacciones 
        string[][] transacciones = new string[cantidadtrans][];
    
      
        for (int i = 0; i < cantidadtrans; i++)
        {
            Console.WriteLine($"\nTransacción {i + 1}:");
            Console.Write("Ingrese el nombre: ");
            string a = Console.ReadLine();

            Console.Write("Ingrese el número de cuenta: ");
            string b = Console.ReadLine();

            Console.Write("Ingrese el nombre de la cuenta: ");
            string c = Console.ReadLine();

            Console.Write("Ingrese el nombre del banco: ");
            string d = Console.ReadLine();

            Console.Write("Ingrese el monto a transferir: ");
            double e = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la moneda (Quetzales o Dólares): ");
            string f = Console.ReadLine();
             if (decimal.TryParse(f, out decimal monto) && monto >= 200.00m && monto <= 2000.00m)
        {
            Console.WriteLine("Monto válido. ¡Gracias!");
            return;
        }
        else
        {
            Console.WriteLine("El monto ingresado no está dentro del rango permitido.");
        }

            transacciones[i] = new string[] { a, b, c, d, e.ToString(), f };
            
        }
        
        Console.WriteLine("\nDatos de las transacciones:");
        for (int i = 0; i < cantidadtrans; i++)
        {
            Console.WriteLine($"Transacción {i + 1}:");
            Console.WriteLine($"Nombre: {transacciones[i][0]}");
            Console.WriteLine($"Número de cuenta: {transacciones[i][1]}");
            Console.WriteLine($"Nombre de la cuenta: {transacciones[i][2]}");
            Console.WriteLine($"Nombre del banco: {transacciones[i][3]}");
            Console.WriteLine($"Monto a transferir: {transacciones[i][4]} {transacciones[i][5]}");
            Console.ReadKey();
        }
         }
         static void CuentasTerceros()
         {
            Console.WriteLine("Esta funcion no esta disponible por el momento");
            Console.ReadKey();
         }
        static void PagoServicios()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("PAGO DE SERVICIOS");
            Console.WriteLine("1. Empresa de agua");
            Console.WriteLine("2. Empresa Eléctrica");
            Console.WriteLine("3. Empresa de Telefónica");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Seleccione el proveedor de servicios:");
            int OpciondeM = int.Parse(Console.ReadLine());

            if (OpciondeM < 1 || OpciondeM > 3)
            {
                Console.WriteLine("Selección no válida.");
                return;
            }

            Console.WriteLine("Ingrese el monto del pago en quetzales:");
            decimal pagogp = decimal.Parse(Console.ReadLine());

            if (saldoin >= pagogp)
            {
                saldoin -= pagogp;
                Pitagora (pagogp, "Trnsaccion de débito");
                Console.WriteLine($"El pago fue realizado a {OpciondeM}");
                Console.WriteLine($"El pago fue de  {pagogp}");
                Console.WriteLine($"Su nuevo saldo es de:  {saldoin}");
            }
            else
            {
                Console.WriteLine("Falta saldo, no se puede hacer.");
            }
            Console.ReadKey();
        }

    
    }

    public class Transaccion
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
    }

   
 }
