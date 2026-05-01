namespace Proyecto_banco
{
    public class Cliente
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }

        private static int contadorCuentas = 1;

        public Cliente(string identificacion, string nombreCompleto)
        {
            Identificacion = identificacion;
            NombreCompleto = nombreCompleto;
            NumeroCuenta = GenerarNumeroCuenta();
            Saldo = 0;
        }

        private string GenerarNumeroCuenta()
        {
            string numeroConsecutivo = contadorCuentas.ToString().PadLeft(8, '0');
            string numeroCuenta = $"0001{numeroConsecutivo}";
            contadorCuentas++;
            return numeroCuenta;
        }

        public override string ToString()
        {
            string cuentaFormateada = $"{NumeroCuenta.Substring(0, 4)}-{NumeroCuenta.Substring(4, 8)}";
            return $"ID: {Identificacion} | Nombre: {NombreCompleto} | Cuenta: {cuentaFormateada} | Saldo: ${Saldo:N2}";
        }
    }
}