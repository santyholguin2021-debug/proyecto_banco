using System;

namespace Proyecto_banco
{
    public class Transaccion
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }

        public Transaccion(string tipo, decimal monto, string numeroCuenta)
        {
            Tipo = tipo;
            Monto = monto;
            NumeroCuenta = numeroCuenta;
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Fecha:dd/MM/yyyy HH:mm} | {Tipo} | Cuenta: {NumeroCuenta} | ${Monto:N2}";
        }
    }
}
