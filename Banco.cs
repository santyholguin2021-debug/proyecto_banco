public class Banco
{
    private ListaEnlazada<Cliente> clientes;
    private Cola<Cliente> colaAtencion;
    private Pila<Transaccion> historialTransacciones;
}
