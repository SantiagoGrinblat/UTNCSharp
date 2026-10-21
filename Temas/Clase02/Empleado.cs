namespace EstudioCSharp.Temas.Clase02;

public class Empleado: Persona {
  private int _legajo;
  private int _antiguedad;
  private string _departamento;

  public Empleado(string name, string lastName, int legajo, int antiguedad, string departamento): base(name, lastName) {
    _legajo = legajo;
    _antiguedad = antiguedad;
    _departamento = departamento;
  }
  public string ObtenerFichaEmpleado() {
    return $"{GetName()} {GetLastName()} - Legajo {_legajo}, {_antiguedad} años en {_departamento}";
  }
}