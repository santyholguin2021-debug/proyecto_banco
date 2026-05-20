using System;

namespace Proyecto_banco
{
    public class Banco
    {
        private ListaEnlazadaClientes clientes;
        private ColaAtencion cola;
        private PilaTransacciones historial;

        public Banco()
        {
            clientes = new ListaEnlazadaClientes();
            cola = new ColaAtencion();
            historial = new PilaTransacciones();
        }

        public bool RegistrarCliente(Cliente cliente)
        {
            if (clientes.ExisteCliente(cliente.Identificacion, cliente.NumeroCuenta))
            {
                return false;
            }

            clientes.Insertar(cliente);
            return true;
        }

        public Cliente BuscarCliente(string cuenta)
        {
            return clientes.BuscarPorCuenta(cuenta);
        }

        public Cliente BuscarClientePorIdentificacion(string identificacion)
        {
            return clientes.BuscarPorIdentificacion(identificacion);
        }

        public bool AgregarACola(string cuenta)
        {
            Cliente cliente = BuscarCliente(cuenta);

            if (cliente == null)
            {
                return false;
            }

            if (cola.ClienteEnCola(cuenta))
            {
                return false;
            }

            cola.Encolar(cliente);
            return true;
        }

        public Cliente AtenderCliente()
        {
            return cola.Desencolar();
        }

        public bool Depositar(string cuenta, decimal monto)
        {
            Cliente cliente = BuscarCliente(cuenta);

            if (cliente == null)
            {
                return false;
            }

            cliente.Saldo += monto;
            historial.Apilar(new Transaccion("Depósito", monto, cuenta));
            return true;
        }

        public bool Retirar(string cuenta, decimal monto)
        {
            Cliente cliente = BuscarCliente(cuenta);

            if (cliente == null || monto > cliente.Saldo)
            {
                return false;
            }

            cliente.Saldo -= monto;
            historial.Apilar(new Transaccion("Retiro", monto, cuenta));
            return true;
        }

        public bool DeshacerUltimaTransaccion()
        {
            if (historial.EstaVacia())
            {
                return false;
            }

            Transaccion transaccion = historial.Desapilar();
            Cliente cliente = BuscarCliente(transaccion.NumeroCuenta);

            if (cliente == null)
            {
                return false;
            }

            if (transaccion.Tipo == "Depósito")
            {
                cliente.Saldo -= transaccion.Monto;
            }
            else if (transaccion.Tipo == "Retiro")
            {
                cliente.Saldo += transaccion.Monto;
            }

            return true;
        }

        public void MostrarClientes()
        {
            clientes.MostrarClientes();
        }

        public void MostrarCola()
        {
            cola.MostrarCola();
        }

        public void MostrarHistorial()
        {
            historial.MostrarHistorial();
        }

        public int TotalClientes()
        {
            return clientes.ContarClientes();
        }

        public decimal TotalDineroBanco()
        {
            return clientes.TotalDinero();
        }
    }
}
