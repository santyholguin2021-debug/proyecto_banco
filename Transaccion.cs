namespace  Proyecto_banco
{
    public class Transaccion
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroCuenta { get; set; }

        public Transaccion(string tipo, decimal monto, string numeroCuenta)
        {
            this.Tipo = tipo;
            this.Monto = monto;
            this.Fecha = DateTime.Now;
            this.NumeroCuenta = numeroCuenta;
        }

        public override string ToString()
        {
            string cuentaFormateada = $"{this.NumeroCuenta.Substring(0, 4)}-{this.NumeroCuenta.Substring(4, 8)}";
            return $"{this.Fecha:dd/MM/yyyy HH:mm:ss} - {this.Tipo}: ${this.Monto:N2} - Cuenta: {cuentaFormateada}";
        }
    }
}