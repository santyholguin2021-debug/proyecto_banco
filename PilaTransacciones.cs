using System;

namespace Proyecto_banco
{
    public class NodoPila
    {
        public Transaccion Transaccion { get; set; }
        public NodoPila Siguiente { get; set; }

        public NodoPila(Transaccion transaccion)
        {
            Transaccion = transaccion;
        }
    }

    public class PilaTransacciones
    {
        private NodoPila cima;

        public void Apilar(Transaccion transaccion)
        {
            NodoPila nuevo = new NodoPila(transaccion);
            nuevo.Siguiente = cima;
            cima = nuevo;
        }

        public Transaccion Desapilar()
        {
            if (cima == null)
            {
                return null;
            }

            Transaccion transaccion = cima.Transaccion;
            cima = cima.Siguiente;
            return transaccion;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void MostrarHistorial()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay transacciones registradas.");
                return;
            }

            NodoPila actual = cima;

            while (actual != null)
            {
                Console.WriteLine(actual.Transaccion);
                actual = actual.Siguiente;
            }
        }
    }
}
