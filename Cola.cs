public class Cola<T>
{
    private Nodo<T> frente;
    private Nodo<T> final;

    public Cola()
    {
        frente = null;
        final = null;
    }

    // Encolar (agregar al final)
    public void Encolar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);

        if (EstaVacia())
        {
            frente = nuevo;
            final = nuevo;
        }
        else
        {
            final.Siguiente = nuevo;
            final = nuevo;
        }
    }

    // Desencolar (quitar del frente)
    public T Desencolar()
    {
        if (EstaVacia())
            return default;

        T dato = frente.Dato;
        frente = frente.Siguiente;

        if (frente == null)
        {
            final = null;
        }

        return dato;
    }

    // Ver el primero sin quitarlo
    public T VerFrente()
    {
        if (EstaVacia())
            return default;

        return frente.Dato;
    }

    // Verificar si la cola está vacía
    public bool EstaVacia()
    {
        return frente == null;
    }

    // Recorrer la cola (mostrar clientes en espera)
    public void Recorrer(Action<T> accion)
    {
        Nodo<T> actual = frente;

        while (actual != null)
        {
            accion(actual.Dato);
            actual = actual.Siguiente;
        }
    }

    private Nodo<T> ObtenerUltimo(Nodo<T> nodo)
    {
        if (nodo == null)
            return null;

        Nodo<T> actual = nodo;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }

        return actual;
    }
}
