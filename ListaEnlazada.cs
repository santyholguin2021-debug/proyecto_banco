namespace Proyecto_banco.ListaEnlazada
{
    public class ListaEnlazada
    {
         private Nodo? cabeza;

        public ListaEnlazada()
        {
            this.cabeza = null;
        }

        public bool Insertar(Cliente cliente)
        {
            if (this.BuscarPorIdentificacion(cliente.Identificacion) != null)
            {
                Console.WriteLine("Error: Ya existe un cliente con esa identificacion.");
                return false;
            }

            if (this.BuscarPorNumeroCuenta(cliente.NumeroCuenta) != null)
            {
                Console.WriteLine("Error: Ya existe un cliente con ese numero de cuenta.");
                return false;
            }

            Nodo nuevoNodo = new Nodo(cliente);

            if (this.cabeza == null)
            {
                this.cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = this.cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            return true;
        }

        public Cliente? BuscarPorIdentificacion(string identificacion)
        {
            Nodo? actual = this.cabeza;
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

        public Cliente? BuscarPorNumeroCuenta(string numeroCuenta)
        {
            string numeroLimpio = numeroCuenta.Replace("-", "");
            
            Nodo? actual = this.cabeza;
            while (actual != null)
            {
                if (actual.Cliente.NumeroCuenta == numeroLimpio)
                {
                    return actual.Cliente;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public void ListarTodos()
        {
            if (this.cabeza == null)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE CLIENTES ===");
            Nodo? actual = this.cabeza;
            int contador = 1;
            while (actual != null)
            {
                Console.WriteLine($"{contador}. {actual.Cliente}");
                actual = actual.Siguiente;
                contador++;
            }
            Console.WriteLine($"\nTotal: {contador - 1} clientes registrados.");
        }

        public int Contar()
        {
            int contador = 0;
            Nodo? actual = this.cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public decimal TotalDineroBanco()
        {
            decimal total = 0;
            Nodo? actual = this.cabeza;
            while (actual != null)
            {
                total += actual.Cliente.Saldo;
                actual = actual.Siguiente;
            }
            return total;
        }

        public bool EstaVacia()
        {
            return this.cabeza == null;
        }
    }
}