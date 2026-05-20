namespace Proyecto_banco
{
    public class NodoCliente
    {
        public Cliente Cliente { get; set; }
        public NodoCliente Siguiente { get; set; }

        public NodoCliente(Cliente cliente)
        {
            Cliente = cliente;
            Siguiente = null;
        }
    }
}
