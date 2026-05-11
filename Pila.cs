public class Pila<T>
{
    private Nodo<T> cima;

    public Pila()
    {
        cima = null;
    }

    public Pila(Nodo<T> nodoCima)
    {
        cima = nodoCima;
    }

    public Pila(ListaEnlazada<T> lista)
    {
        cima = lista.ObtenerCabeza();
    }

    public Pila(Cola<T> cola)
    {
        cima = cola.ObtenerPrimero();
    }

    public Nodo<T> ObtenerPrimero()
    {
        return cima;
    }

    // Apilar
    public void Push(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);
        nuevo.Siguiente = cima;
        cima = nuevo;
    }

    // Desapilar
    public T Pop()
    {
        if (EstaVacia())
            return default;

        T dato = cima.Dato;
        cima = cima.Siguiente;
        return dato;
    }

    // Ver cima sin sacar
    public T Peek()
    {
        if (EstaVacia())
            return default;

        return cima.Dato;
    }

    // Verificar si está vacía
    public bool EstaVacia()
    {
        return cima == null;
    }

    // Recorrer la pila
    public void Recorrer(Action<T> accion)
    {
        Nodo<T> actual = cima;

        while (actual != null)
        {
            accion(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}