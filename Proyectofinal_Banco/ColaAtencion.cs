using System;

namespace Proyecto_banco
{
    public class NodoCola
    {
        public Cliente Cliente { get; set; }
        public NodoCola Siguiente { get; set; }

        public NodoCola(Cliente cliente)
        {
            Cliente = cliente;
        }
    }

    public class ColaAtencion
    {
        private NodoCola frente;
        private NodoCola final;

        public void Encolar(Cliente cliente)
        {
            NodoCola nuevo = new NodoCola(cliente);

            if (final == null)
            {
                frente = nuevo;
                final = nuevo;
                return;
            }

            final.Siguiente = nuevo;
            final = nuevo;
        }

        public Cliente Desencolar()
        {
            if (frente == null)
            {
                return null;
            }

            Cliente cliente = frente.Cliente;
            frente = frente.Siguiente;

            if (frente == null)
            {
                final = null;
            }

            return cliente;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public bool ClienteEnCola(string numeroCuenta)
        {
            NodoCola actual = frente;

            while (actual != null)
            {
                if (actual.Cliente.NumeroCuenta == numeroCuenta)
                {
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public void MostrarCola()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay clientes en la cola.");
                return;
            }

            NodoCola actual = frente;
            int posicion = 1;

            while (actual != null)
            {
                Console.WriteLine($"{posicion}. {actual.Cliente.NombreCompleto} - Cuenta: {actual.Cliente.NumeroCuenta}");
                actual = actual.Siguiente;
                posicion++;
            }
        }
    }
}
