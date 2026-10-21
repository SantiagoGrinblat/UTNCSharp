namespace EstudioCSharp.Explicacion.Clase02.herencia;

/*
  La declaración de herencia
  public class Empleado : Persona {

  " : Persona " se lee "Empleado hereda de Persona" / "Empleado ES-UNA Persona".
  Fijate que este archivo NO tiene ningún using ni referencia especial hacia Persona.cs,
  y sin embargo la usa sin problema. Esto funciona porque:
  1. Persona.cs y Empleado.cs declaran el MISMO namespace (EstudioCSharp.Temas.Clase03).
  2. C# compila TODOS los archivos del proyecto como una sola unidad antes de ejecutar nada
    (esto ya lo vimos en la Clase 2: el orden de escritura no es el orden de ejecución).
    Para cuando el compilador llega a resolver "Empleado : Persona", ya conoce las tres
    clases de este namespace, sin importar en qué archivo .cs esté cada una.
  Si Persona estuviera en otro namespace (por ejemplo, si la moviéramos a
  EstudioCSharp.Modelos), Empleado.cs sí necesitaría un using EstudioCSharp.Modelos; al
  principio del archivo.
*/
// public class Empleado : Persona
// {
//   private int _legajo;
//   private int _antiguedad;
//   private string _departamento;

  /*
    El constructor, con base(...)
    public Empleado(string name, string lastName, int legajo, int antiguedad, string departamento)
      : base(name, lastName) {
      _legajo = legajo;
      _antiguedad = antiguedad;
      _departamento = departamento;
    }

    base(name, lastName): la palabra reservada base, en esta posición (después de los paréntesis
    del constructor, con : adelante), significa "ejecutá el constructor de la clase PADRE con
    estos argumentos". Es obligatorio hacerlo explícito acá porque Persona no tiene un
    constructor vacío disponible — es la única forma que tiene C# de inicializar _name/_lastName
    para este objeto.

    Orden real de ejecución de new Empleado(...):
    1. C# ve : base(name, lastName) en la firma del constructor.
    2. Ejecuta PRIMERO el constructor Persona(string, string) con esos valores → deja
      _name y _lastName asignados (campos heredados, que Empleado ya posee).
    3. Recién ahí entra al cuerpo { } de Empleado y asigna _legajo, _antiguedad, _departamento.
  */
  // public Empleado(string name, string lastName, int legajo, int antiguedad, string departamento) : base(name, lastName)
  // {
  //   _legajo = legajo;
  //   _antiguedad = antiguedad;
  //   _departamento = departamento;
  // }

  /*
    ObtenerFichaEmpleado(): mezcla heredado + propio
    public string ObtenerFichaEmpleado() {
      return $"{GetName()} {GetLastName()} - Legajo {_legajo}, {_antiguedad} años en {_departamento}";
    }

    GetName() y GetLastName() son heredados de Persona — Empleado nunca los escribió.
    _legajo, _antiguedad, _departamento son propios de Empleado.
    Para el código de este método no hay ninguna diferencia entre usar algo heredado o algo
    propio: se usan exactamente igual.
  */
  // public string ObtenerFichaEmpleado()
  // {
  //   return $"{GetName()} {GetLastName()} - Legajo {_legajo}, {_antiguedad} años en {_departamento}";
  // }

  /*
    NormalizarNombre(): acá SÍ se nota la diferencia de protected vs private
    public void NormalizarNombre() {
      _name = _name.Trim().ToUpper();
      _lastName = _lastName.Trim().ToUpper();
    }

    Este método toca _name y _lastName DIRECTAMENTE, sin pasar por GetName()/GetLastName().
    Esto SOLO compila porque _name y _lastName están declarados protected en Persona.cs.
    Si en Persona.cs cambiaras protected por private, este método daría error de compilación:
    "_name is inaccessible due to its protection level" — porque private bloquea el acceso
    incluso para las clases hijas, mientras que protected se lo permite.
    .Trim() saca espacios al principio/final, .ToUpper() pasa todo a mayúsculas — dos métodos
    de string encadenados uno después del otro.
  */
//   public void NormalizarNombre()
//   {
//     _name = _name.Trim().ToUpper();
//     _lastName = _lastName.Trim().ToUpper();
//   }
// }