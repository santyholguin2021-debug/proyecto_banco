using System;

namespace Proyecto_banco
{
    public class ListaEnlazadaClientes
    {
        private NodoCliente cabeza;

        public void Insertar(Cliente cliente)
        {
            NodoCliente nuevo = new NodoCliente(cliente);

            if (cabeza == null)
            {
                cabeza = nuevo;
                return;
            }

            NodoCliente actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        public Cliente BuscarPorCuenta(string cuenta)
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                if (actual.Cliente.NumeroCuenta == cuenta)
                {
                    return actual.Cliente;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        public Cliente BuscarPorIdentificacion(string identificacion)
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                if (actual.Cliente.Identificacion == identificacion)
                {
                    return actual.Cliente;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool ExisteCliente(string identificacion, string cuenta)
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                if (actual.Cliente.Identificacion == identificacion ||
                    actual.Cliente.NumeroCuenta == cuenta)
                {
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public void MostrarClientes()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            NodoCliente actual = cabeza;

            while (actual != null)
            {
                Console.WriteLine(actual.Cliente);
                actual = actual.Siguiente;
            }
        }

        public int ContarClientes()
        {
            int contador = 0;
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }

            return contador;
        }

        public decimal TotalDinero()
        {
            decimal total = 0;
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                total += actual.Cliente.Saldo;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}
