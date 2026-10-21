namespace EstudioCSharp.Explicacion.Clase02.overloading;

/*
  6. El uso, paso a paso

  Persona persona = new Persona("Ana", "Gómez");

  Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez"));
  2 argumentos, ambos string. El compilador busca, entre las 3 versiones de ConcatPersonInfo,
  cuál tiene una firma que matchee "2 parámetros, ambos string" → elige la Versión 1.
  Resultado: "Ana Gómez"

  Console.WriteLine(persona.ConcatPersonInfo("Ana", "María", "Gómez"));
  3 argumentos, los tres string. Hay dos versiones con 3 parámetros (Versión 2 y Versión 3),
  pero solo la Versión 2 tiene los tres tipados como string → elige la Versión 2.
  Resultado: "Ana María Gómez"

  Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez", 30));
  3 argumentos: string, string, int. Compara contra la Versión 2 (string, string, string) → no matchea
  el tercer tipo. Compara contra la Versión 3 (string, string, int) → matchea los tres tipos en el mismo
  orden → elige la Versión 3.
  Resultado: "Ana Gómez, 30 años"

  Este proceso donde C# elige la versión correcta según los argumentos que le pasaste se llama
  resolución de sobrecarga (overload resolution), y pasa en tiempo de compilación: el compilador ya
  sabe, antes de correr el programa, cuál de las tres versiones se va a ejecutar en cada línea.
*/
// Persona persona = new Persona("Ana", "Gómez");
// Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez"));
// Console.WriteLine(persona.ConcatPersonInfo("Ana", "María", "Gómez"));
// Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez", 30));

// Salida:
// Ana Gómez
// Ana María Gómez
// Ana Gómez, 30 años

// public class Persona {

/*
  Los campos
  private string _name;
  private string _lastName;

  Igual que siempre: private, con _. Guardan el estado interno de cada objeto Persona.
  Acá no tienen valor inicial explícito (a diferencia de Producto con _nombre = ""), así que
  arrancan en null hasta que el constructor los asigne. No es un problema porque este constructor
  SIEMPRE los asigna — no hay forma de crear una Persona sin pasarle name y lastName.
*/
  // private string _name;
  // private string _lastName;

/*
  El constructor
  public Persona(string name, string lastName) {
    _name = name;
    _lastName = lastName;
  }

  Mismo nombre que la clase, sin tipo de retorno, como todo constructor.
  Acá NO hace falta this.campo = parametro porque los parámetros se llaman name/lastName
  (sin _) y los campos se llaman _name/_lastName — no hay choque de nombres, así que
  _name = name; es suficiente y sin ambigüedad.
  Esta clase solo tiene ESTE constructor. Eso significa que ya no existe un Persona() vacío por
  defecto (regla que viste en el PDF: al definir al menos un constructor, el implícito desaparece).
  Todo new Persona(...) obliga a pasar name y lastName.
*/
  // public Persona(string name, string lastName) {
  //   _name = name;
  //   _lastName = lastName;
  // }

  //? ===== Sobrecarga: 3 versiones de ConcatPersonInfo =====

/*
  Versión 1: nombre + apellido
  public string ConcatPersonInfo(string name, string lastName) {
    return $"{name} {lastName}";
  }

  Firma: (string, string) — 2 parámetros.
  Importante: estos "name" y "lastName" son PARÁMETROS del método, no son los campos _name/_lastName
  de la clase. El método no usa el estado interno del objeto en absoluto — recibe dos strings
  cualquiera y los concatena. Podrías llamarlo con datos que no tengan nada que ver con el objeto
  sobre el que lo invocás: persona.ConcatPersonInfo("Juan", "Pérez") funciona igual, aunque
  persona se llame "Ana Gómez" por dentro.
  $"{name} {lastName}" es interpolación de string: arma un texto reemplazando {name} y {lastName}
  por sus valores, con un espacio en el medio.
*/
  // public string ConcatPersonInfo(string name, string lastName) {
  //   return $"{name} {lastName}";
  // }

/*
  Versión 2: nombre + segundo nombre + apellido
  public string ConcatPersonInfo(string name, string middleName, string lastName) {
    return $"{name} {middleName} {lastName}";
  }

  Firma: (string, string, string) — 3 parámetros, los tres string.
  Mismo nombre de método que la Versión 1 (ConcatPersonInfo), pero el compilador la trata como un
  miembro totalmente distinto porque la CANTIDAD de parámetros cambió (2 vs 3). No importa que el
  tipo de todos los parámetros sea string en ambas: alcanza con que difiera la cantidad para que
  sean firmas distintas y coexistan sin error.
*/
  // public string ConcatPersonInfo(string name, string middleName, string lastName) {
  //   // return $"{name} {middleName} {lastName}";
  //   return ConcatPersonInfo(name, middleName) + lastName; //<- otra forma de hacerlo, menos comun
  // }

/*
  Versión 3: nombre + apellido + edad
  public string ConcatPersonInfo(string name, string lastName, int age) {
    return $"{name} {lastName}, {age} años";
  }

  Firma: (string, string, int) — 3 parámetros, misma cantidad que la Versión 2, pero el TIPO del
  tercer parámetro es distinto (int en vez de string). Eso alcanza para que el compilador la vea
  como una firma diferente. Acá se ve el detalle más fino de la sobrecarga: con la misma cantidad
  de parámetros, un solo tipo distinto en una sola posición ya define un miembro nuevo.
  Los NOMBRES de los parámetros (name, lastName, age) no influyen en nada para esta distinción —
  el compilador nunca los mira. Solo mira: cantidad, tipos, orden.
*/
//   public string ConcatPersonInfo(string name, string lastName, int age) {
//     return $"{name} {lastName}, {age} años";
//   }
// }

/*
  El punto que quiero que te quede bien grabado, porque es donde suelen confundir en el parcial: 
  las tres ConcatPersonInfo son métodos completamente independientes para el compilador 
  — es pura coincidencia de nombre para el programador (les puso el mismo nombre porque hacen "lo mismo" conceptualmente: 
  armar un texto con datos de persona). El compilador no sabe ni le importa que hagan algo parecido; 
  lo único que usa para decidir cuál ejecutar en cada llamada es la firma: cantidad + tipo + orden de los parámetros, nunca el tipo de retorno ni los nombres de los parámetros.
*/