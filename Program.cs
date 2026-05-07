using ProyectoBanco.Entidades;
using ProyectoBanco.Logica;

namespace ProyectoBanco
{
    internal class Program
    {
        // Método para leer entrada numérica con validación
        static int LeerOpcionMenu()
        {
            while (true)
            {
                Console.Write("Opcion: ");
                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    if (opcion >= 1 && opcion <= 13)
                    {
                        return opcion;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Ingrese una opción entre 1 y 13.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Ingrese un número válido.");
                    Console.ResetColor();
                }
            }
        }

        // Método para leer cadena no vacía
        static string LeerCadenaValida(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El campo no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }
                return valor;
            }
        }

        // Método para leer número decimal con validación
        static double LeerNumeroPositivo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out double valor))
                {
                    if (valor > 0)
                    {
                        return valor;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Ingrese un valor mayor a cero.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Ingrese un número válido.");
                    Console.ResetColor();
                }
            }
        }

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

                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            string cedula = LeerCadenaValida("Identificacion: ");
                            string nombre = LeerCadenaValida("NombreCompleto: ");
                            string cuenta = LeerCadenaValida("NumeroCuenta: ");
                            double saldo = LeerNumeroPositivo("Saldo: ");

                            Cliente nuevo = new Cliente(cedula, nombre, cuenta, saldo);
                            banco.Clientes.AgregarCliente(nuevo);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cliente registrado exitosamente.");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al registrar cliente: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        try
                        {
                            banco.Clientes.MostrarClientes();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al listar clientes: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        try
                        {
                            string cuenta = LeerCadenaValida("NumeroCuenta: ");
                            Cliente cliente = banco.Clientes.BuscarCliente(cuenta);

                            if (cliente != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(cliente);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Cliente no encontrado.");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al buscar cliente: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 4:
                        try
                        {
                            string cuenta = LeerCadenaValida("Cuenta cliente: ");
                            Cliente cliente = banco.Clientes.BuscarCliente(cuenta);

                            if (cliente != null)
                            {
                                banco.Cola.Encolar(cliente);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Cliente agregado a la cola.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Cliente no existe. Verifique el número de cuenta.");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al agregar a cola: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 5:
                        try
                        {
                            Cliente cliente = banco.Cola.Desencolar();

                            if (cliente != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Atendiendo a {cliente.Nombre}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Cola vacía. No hay clientes para atender.");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al atender cliente: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 6:
                        try
                        {
                            string cuenta = LeerCadenaValida("NumeroCuenta: ");
                            double monto = LeerNumeroPositivo("Monto a depositar: ");

                            banco.Depositar(cuenta, monto);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Depósito realizado exitosamente.");
                            Console.ResetColor();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Advertencia: {ex.Message}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al depositar: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 7:
                        try
                        {
                            string cuenta = LeerCadenaValida("NumeroCuenta: ");
                            double monto = LeerNumeroPositivo("Monto a retirar: ");

                            banco.Retirar(cuenta, monto);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Retiro realizado exitosamente.");
                            Console.ResetColor();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Advertencia: {ex.Message}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al retirar: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 8:
                        try
                        {
                            string cuenta = LeerCadenaValida("NumeroCuenta: ");
                            Cliente cliente = banco.Clientes.BuscarCliente(cuenta);

                            if (cliente != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"Saldo de {cliente.Nombre}: ${cliente.Saldo:F2}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Cliente no encontrado.");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al consultar saldo: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 9:
                        try
                        {
                            banco.Deshacer();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Última transacción deshecha.");
                            Console.ResetColor();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Información: {ex.Message}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al deshacer transacción: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 10:
                        try
                        {
                            banco.Cola.MostrarCola();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al mostrar cola: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 11:
                        try
                        {
                            int totalClientes = banco.Clientes.ContarClientes();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Total de clientes: {totalClientes}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al contar clientes: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 12:
                        try
                        {
                            double totalDinero = banco.Clientes.TotalDinero();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Total dinero en banco: ${totalDinero:F2}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error al calcular total: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();

            } while (opcion != 13);
        }
    }
}