using System;

namespace Proyecto_banco
{
    internal class Program
    {
        private static Banco banco = new Banco();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                MostrarMenu();
                opcion = LeerEntero("Seleccione una opción: ");

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        banco.MostrarClientes();
                        break;
                    case 3:
                        BuscarCliente();
                        break;
                    case 4:
                        AgregarClienteCola();
                        break;
                    case 5:
                        AtenderCliente();
                        break;
                    case 6:
                        RealizarDeposito();
                        break;
                    case 7:
                        RealizarRetiro();
                        break;
                    case 8:
                        ConsultarSaldo();
                        break;
                    
                    case 9:
                        EditarCliente();
                        break;

                    case 10:
                        DeshacerUltimaTransaccion();
                        break;

                    case 11:
                        banco.MostrarCola();
                        break;

                    case 12:
                        Console.WriteLine($"Total de clientes: {banco.TotalClientes()}");
                        break;

                    case 13:
                        Console.WriteLine($"Total de dinero en el banco: ${banco.TotalDineroBanco():N2}");
                        break;

                    case 14:
                        Console.WriteLine("===== PROGRAMA FINALIZADO =====");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 14)
                {
                    Pausa();
                }

            } while (opcion != 14);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("      BANCO COLOMBIANO            ");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Buscar cliente");
            Console.WriteLine("4. Agregar cliente a cola");
            Console.WriteLine("5. Atender siguiente cliente");
            Console.WriteLine("6. Realizar depósito");
            Console.WriteLine("7. Realizar retiro");
            Console.WriteLine("8. Consultar saldo");
            Console.WriteLine("9. Editar cliente");
            Console.WriteLine("10. Deshacer última transacción");
            Console.WriteLine("11. Mostrar cola de atención");
            Console.WriteLine("12. Mostrar total de clientes");
            Console.WriteLine("13. Mostrar total de dinero del banco");
            Console.WriteLine("14. Salir\n");
        }

        static void RegistrarCliente()
        {
            Console.WriteLine("===== REGISTRO DE CLIENTE =====");

            string identificacion = LeerTexto("Identificación: ");
            string nombre = LeerTexto("Nombre completo: ");
            string cuenta = LeerNumeroCuenta();
            decimal saldo = LeerDecimal("Saldo inicial: ");

            Cliente cliente = new Cliente(identificacion, nombre, cuenta, saldo);

            if (banco.RegistrarCliente(cliente))
            {
                Console.WriteLine("Cliente registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Ya existe un cliente con esa identificación o cuenta.");
            }
        }

        static void BuscarCliente()
        {
            string cuenta = LeerTexto("Ingrese el número de cuenta: ");
            Cliente cliente = banco.BuscarCliente(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine(cliente);
        }

        static void AgregarClienteCola()
        {
            string cuenta = LeerTexto("Número de cuenta: ");

            if (banco.AgregarACola(cuenta))
            {
                Console.WriteLine("Cliente agregado a la cola de atención.");
            }
            else
            {
                Cliente cliente = banco.BuscarCliente(cuenta);
                if (cliente == null)
                {
                    Console.WriteLine("Cuenta no encontrada.");
                }
                else
                {
                    Console.WriteLine("Este cliente ya está en la cola de atención.");
                }
            }
        }

        static void AtenderCliente()
        {
            Cliente cliente = banco.AtenderCliente();

            if (cliente == null)
            {
                Console.WriteLine("No hay clientes en la cola.");
                return;
            }

            Console.WriteLine($"Atendiendo a: {cliente.NombreCompleto}");
        }

        static void RealizarDeposito()
        {
            string cuenta = LeerTexto("Número de cuenta: ");
            decimal monto = LeerDecimal("Monto a depositar: ");

            if (banco.Depositar(cuenta, monto))
            {
                Console.WriteLine("Depósito realizado correctamente.");
            }
            else
            {
                Console.WriteLine("No fue posible realizar el depósito.");
            }
        }

        static void RealizarRetiro()
        {
            string cuenta = LeerTexto("Número de cuenta: ");
            decimal monto = LeerDecimal("Monto a retirar: ");

            if (banco.Retirar(cuenta, monto))
            {
                Console.WriteLine("Retiro realizado correctamente.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente o cuenta inexistente.");
            }
        }

        static void ConsultarSaldo()
        {
            string cuenta = LeerTexto("Número de cuenta: ");
            Cliente cliente = banco.BuscarCliente(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine($"Saldo actual: ${cliente.Saldo:N2}");
        }

        static void DeshacerUltimaTransaccion()
        {
            if (banco.DeshacerUltimaTransaccion())
            {
                Console.WriteLine("Última transacción revertida correctamente.");
            }
            else
            {
                Console.WriteLine("No existen transacciones para deshacer.");
            }
        }

        static int LeerEntero(string mensaje)
        {
            int numero;

            do
            {
                Console.Write(mensaje);

                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    break;
                }

                Console.WriteLine("Ingrese una opción válida.");

            } while (true);

            return numero;
        }

        static decimal LeerDecimal(string mensaje)
        {
            decimal numero;

            do
            {
                Console.Write(mensaje);

                if (decimal.TryParse(Console.ReadLine(), out numero) && numero >= 0)
                {
                    break;
                }

                Console.WriteLine("Ingrese un valor numérico válido mayor o igual a 0.");

            } while (true);

            return numero;
        }

        static string LeerTexto(string mensaje)
        {
            string texto;

            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("El campo no puede estar vacío.");
                }
            }
            while (string.IsNullOrWhiteSpace(texto));

            return texto.Trim();
        }

        static string LeerNumeroCuenta()
        {
            string cuenta;

            do
            {
                Console.Write("Número de cuenta (12 dígitos): ");
                cuenta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cuenta))
                {
                    Console.WriteLine("El número de cuenta es obligatorio.");
                    continue;
                }

                bool soloNumeros = true;

                for (int i = 0; i < cuenta.Length; i++)
                {
                    if (!char.IsDigit(cuenta[i]))
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (!soloNumeros || cuenta.Length != 12)
                {
                    Console.WriteLine("El número de cuenta debe contener exactamente 12 dígitos numéricos.");
                }

            }
            while (string.IsNullOrWhiteSpace(cuenta) || cuenta.Length != 12 || !EsNumero(cuenta));

            return cuenta;
        }

        static bool EsNumero(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                if (!char.IsDigit(texto[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static void EditarCliente()
        {
            Console.Write("Ingrese el número de cuenta del cliente a editar: ");
            string cuenta = Console.ReadLine();

            Cliente cliente = banco.BuscarCliente(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("Deje vacío si no desea cambiar un dato.");

            Console.Write($"Nuevo nombre ({cliente.NombreCompleto}): ");
            string nuevoNombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                cliente.NombreCompleto = nuevoNombre;
            }

            string nuevaCuenta;

            do
            {
                Console.Write($"Nuevo número de cuenta ({cliente.NumeroCuenta}): ");
                nuevaCuenta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nuevaCuenta))
                {
                    break;
                }

                if (nuevaCuenta.Length == 12 && long.TryParse(nuevaCuenta, out _))
                {
                    cliente.NumeroCuenta = nuevaCuenta;
                    break;
                }

                Console.WriteLine("El número de cuenta debe tener exactamente 12 dígitos.");

            } while (true);

            Console.Write($"Nuevo saldo (${cliente.Saldo:N2}): ");
            string nuevoSaldoStr = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevoSaldoStr))
            {
                if (decimal.TryParse(nuevoSaldoStr, out decimal nuevoSaldo) && nuevoSaldo >= 0)
                {
                    cliente.Saldo = nuevoSaldo;
                }
                else
                {
                    Console.WriteLine("Saldo inválido. No se realizó el cambio.");
                }
            }

            Console.WriteLine("Cliente actualizado correctamente.");
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
