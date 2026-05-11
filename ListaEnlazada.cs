public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    public ListaEnlazada(Nodo<T> nodoInicial)
    {
        cabeza = nodoInicial;
    }

    public ListaEnlazada(Cola<T> cola)
    {
        cabeza = cola.ObtenerCabeza();
    }

    public ListaEnlazada(Pila<T> pila)
    {
        cabeza = pila.ObtenerPrimero();
    }

    public Nodo<T> ObtenerCabeza()
    {
        return cabeza;
    }

    // Insertar al final
    public void Insertar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);

        if (cabeza == null)
        {
            cabeza = nuevo;
            return;
        }

        Nodo<T> actual = cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }

        actual.Siguiente = nuevo;
    }

    // Recorrer lista (para mostrar o procesar)
    public void Recorrer(Action<T> accion)
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            accion(actual.Dato);
            actual = actual.Siguiente;
        }
    }

    // Buscar con condición
    public T Buscar(Func<T, bool> criterio)
    {
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            if (criterio(actual.Dato))
                return actual.Dato;

            actual = actual.Siguiente;
        }

        return default;
    }

    // Eliminar con condición
    public void Eliminar(Func<T, bool> criterio)
    {
        if (cabeza == null)
            return;

        if (criterio(cabeza.Dato))
        {
            cabeza = cabeza.Siguiente;
            return;
        }

        Nodo<T> actual = cabeza;
        while (actual.Siguiente != null)
        {
            if (criterio(actual.Siguiente.Dato))
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return;
            }
            actual = actual.Siguiente;
        }
    }

    // Contar nodos
    public int Contar()
    {
        int contador = 0;
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }
}