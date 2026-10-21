namespace EstudioCSharp.Explicacion.Clase02.herencia;

//? ===== Clase base de la jerarquía =====
// public class Persona
// {

  /*
    Los campos: protected en vez de private

    protected string _name;
    protected string _lastName;

    Hay tres niveles de visibilidad que ya conocés:
    private   → solo esta clase (Persona) puede tocarlo. Ni siquiera las hijas pueden.
    protected → esta clase Y cualquier clase que herede de ella (Empleado, Proveedor) pueden
                tocarlo directamente, como si fuera propio.
    public    → cualquier código, de cualquier clase, puede tocarlo.

    Elegimos protected acá PORQUE en Empleado.cs vamos a necesitar tocar _name y _lastName
    directamente (en el método NormalizarNombre()), sin pasar por GetName()/GetLastName().
    Si estos campos fueran private, ese método no compilaría.
  */
  // protected string _name;
  // protected string _lastName;

  /*
    El constructor
    public Persona(string name, string lastName) {
      _name = name;
      _lastName = lastName;
    }

    Al definir este constructor con 2 parámetros, el constructor vacío por defecto (Persona())
    deja de existir automáticamente. Esto es intencional: no tiene sentido que exista una
    Persona sin nombre ni apellido, así que forzamos a que todo new Persona(...) los reciba.
    Este es también el constructor que Empleado y Proveedor van a invocar mediante base(...).
  */
  // public Persona(string name, string lastName)
  // {
  //   _name = name;
  //   _lastName = lastName;
  // }

  /*
    Getters: la puerta pública de lectura
    public string GetName() { return _name; }
    public string GetLastName() { return _lastName; }

    Aunque _name/_lastName ya son accesibles para Empleado/Proveedor por ser protected, seguimos
    necesitando estos getters PÚBLICOS para que código externo a la jerarquía (por ejemplo,
    Program.cs) pueda leerlos. protected NO es lo mismo que public: Program.cs no hereda de
    Persona, así que si _name fuera protected sin más, Program.cs no podría leerlo ni siquiera
    a través de una instancia. Necesita esta puerta pública.
  */
  // public string GetName()
  // {
  //   return _name;
  // }

  // public string GetLastName()
  // {
  //   return _lastName;
  // }

  //? ===== Sobrecarga: 3 versiones de ConcatPersonInfo =====

  /*
    Las tres versiones de ConcatPersonInfo viven acá, en Persona, porque conceptualmente son
    parte del comportamiento de "una Persona" — Empleado y Proveedor las heredan igual que
    GetName()/GetLastName(), sin tener que redefinirlas.

    Versión 1: (string, string) — 2 parámetros
    Versión 2: (string, string, string) — 3 parámetros, todos string
    Versión 3: (string, string, int) — 3 parámetros, el tercero es int

    El compilador las distingue por firma (cantidad + tipos + orden), nunca por el nombre de
    los parámetros ni por el tipo de retorno. Repaso rápido de cuál se ejecuta según lo que
    le pases: 2 argumentos → Versión 1. 3 argumentos, los tres string → Versión 2. 3 argumentos
    con un int al final → Versión 3.
  */
//   public string ConcatPersonInfo(string name, string lastName)
//   {
//     return $"{name} {lastName}";
//   }

//   public string ConcatPersonInfo(string name, string middleName, string lastName)
//   {
//     return $"{name} {middleName} {lastName}";
//   }

//   public string ConcatPersonInfo(string name, string lastName, int age)
//   {
//     return $"{name} {lastName}, {age} años";
//     // return ConcatPersonInfo(name, lastName) + age.ToString;
//   }
// }