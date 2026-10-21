namespace EstudioCSharp.Temas.Clase01;

public class Cuenta {
  private string _titular;
  private decimal _saldo;

  public Cuenta(string titular, decimal saldoInicial) {
    _titular = titular;
    _saldo = saldoInicial;
  }

  public void Depositar(decimal monto) {
    if (monto <= 0) return;
    _saldo += monto;
  }

  public string Describir() => $"{_titular}: ${_saldo}";
}

public static class DemoCuenta {
  public static void Ejecutar() {
    var c1 = new Cuenta("Ana", 1000m);
    c1.Depositar(250m);
    Console.WriteLine(c1.Describir());
  }
}