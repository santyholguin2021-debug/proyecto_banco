using ProyectoBanco.Entidades;
using ProyectoBanco.Logica;

namespace ProyectoBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== BANCO COLOMBIA =====");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Buscar cliente");
                Console.WriteLine("4. Agregar cliente a cola");
                Console.WriteLine("5. Atender cliente");
                Console.WriteLine("6. Depositar");
                Console.WriteLine("7. Retirar");
                Console.WriteLine("8. Consultar saldo");
                Console.WriteLine("9. Deshacer transaccion");
                Console.WriteLine("10. Mostrar cola");
                Console.WriteLine("11. Total clientes");
                Console.WriteLine("12. Total dinero banco");
                Console.WriteLine("13. Salir");

                Console.Write("Opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.Write("Identificacion: ");
                        string cedula = Console.ReadLine();

                        Console.Write("NombreCompleto: ");
                        string nombre = Console.ReadLine();

                        Console.Write("NumeroCuenta: ");
                        string cuenta = Console.ReadLine();

                        Console.Write("Saldo: ");
                        double saldo = double.Parse(Console.ReadLine());

                        Cliente nuevo = new Cliente(cedula, nombre, cuenta, saldo);

                        banco.Clientes.AgregarCliente(nuevo);

                        Console.WriteLine("Cliente registrado.");
                        break;

                    case 2:
                        banco.Clientes.MostrarClientes();
                        break;

                    case 3:

                        Console.Write("NumeroCuenta: ");
                        cuenta = Console.ReadLine();

                        Cliente cliente = banco.Clientes.BuscarCliente(cuenta);

                        if (cliente != null)
                        {
                            Console.WriteLine(cliente);
                        }
                        else
                        {
                            Console.WriteLine("No encontrado.");
                        }

                        break;

                    case 4:

                        Console.Write("Cuenta cliente: ");
                        cuenta = Console.ReadLine();

                        cliente = banco.Clientes.BuscarCliente(cuenta);

                        if (cliente != null)
                        {
                            banco.Cola.Encolar(cliente);
                            Console.WriteLine("Cliente agregado.");
                        }

                        break;

                    case 5:

                        cliente = banco.Cola.Desencolar();

                        if (cliente != null)
                        {
                            Console.WriteLine($"Atendiendo a {cliente.Nombre}");
                        }
                        else
                        {
                            Console.WriteLine("Cola vacia.");
                        }

                        break;

                    case 6:

                        Console.Write("NumeroCuenta: ");
                        cuenta = Console.ReadLine();

                        Console.Write("Monto: ");
                        double monto = double.Parse(Console.ReadLine());

                        banco.Depositar(cuenta, monto);

                        break;

                    case 7:

                        Console.Write("NumeroCuenta: ");
                        cuenta = Console.ReadLine();

                        Console.Write("Monto: ");
                        monto = double.Parse(Console.ReadLine());

                        banco.Retirar(cuenta, monto);

                        break;

                    case 8:

                        Console.Write("NumeroCuenta: ");
                        cuenta = Console.ReadLine();

                        cliente = banco.Clientes.BuscarCliente(cuenta);

                        if (cliente != null)
                        {
                            Console.WriteLine($"Saldo: ${cliente.Saldo}");
                        }

                        break;

                    case 9:
                        banco.Deshacer();
                        break;

                    case 10:
                        banco.Cola.MostrarCola();
                        break;

                    case 11:
                        Console.WriteLine($"Clientes: {banco.Clientes.ContarClientes()}");
                        break;

                    case 12:
                        Console.WriteLine($"Total banco: ${banco.Clientes.TotalDinero()}");
                        break;
                }

                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();

            } while (opcion != 13);
        }
    }
}