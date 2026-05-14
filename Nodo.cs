namespace  Proyecto_banco
{
    public class Nodo
    {
        public Cliente Cliente { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(Cliente cliente)
        {
            this.Cliente = cliente;
            this.Siguiente = null;
        }
    }
}