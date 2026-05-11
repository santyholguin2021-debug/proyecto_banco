namespace Proyecto_banco
{
    public class NodoPila
    {
        public Transaccion Transaccion { get; set; }
        public NodoPila? Siguiente { get; set; }

        public NodoPila(Transaccion transaccion)
        {
            this.Transaccion = transaccion;
            this.Siguiente = null;
        }
    }
}