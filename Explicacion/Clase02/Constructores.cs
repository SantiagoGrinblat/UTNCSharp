namespace EstudioCSharp.Explicacion.Clase02;

/*
  6. El uso, paso a paso

  Libreria libreria1 = new Libreria("Biblioteca del Barrio", "Dorrego");
  new Libreria(...) con dos argumentos: C# elige el constructor Libreria(string, string).
  _nombre = "Biblioteca del Barrio", _lugar = "Dorrego".

  Libreria libreria2 = new Libreria();
  new Libreria() sin argumentos: C# elige el constructor Libreria().
  Ese constructor delega en this("Sin nombre", "Sin ubicación").
  _nombre = "Sin nombre", _lugar = "Sin ubicación".

  Esto es sobrecarga de constructores (overloading, el mismo concepto que vas a ver formalmente en la clase 3-4 de tu cronograma): dos miembros con el mismo nombre (Libreria), diferenciados por la cantidad de parámetros que reciben. C# decide cuál ejecutar mirando cuántos argumentos le pusiste en el new.

  Console.WriteLine(libreria1.GetNombre() + " - " + libreria1.GetLugar());
  Console.WriteLine(libreria2.GetNombre() + " - " + libreria2.GetLugar());
  El + entre strings los concatena (los pega uno después del otro).
  Cada objeto (libreria1, libreria2) tiene sus propios campos, así que cada GetNombre()/GetLugar() devuelve lo que le corresponde a ese objeto.
*/
// Libreria libreria1 = new Libreria("Biblioteca del Barrio", "Dorrego");
// Libreria libreria2 = new Libreria();

// Console.WriteLine(libreria1.GetNombre() + " - " + libreria1.GetLugar());
// Console.WriteLine(libreria2.GetNombre() + " - " + libreria2.GetLugar());
// Salida:
// Biblioteca del Barrio - Dorrego
// Sin nombre - Sin ubicación

// public class Libreria {
//   private string _nombre;
//   private string _lugar;

/*
  2. El primer constructor (con parámetros)

  public Libreria(string nombre, string lugar) {
    _nombre = nombre;
    _lugar = lugar;
  }
  Ya lo vimos: mismo nombre que la clase, sin tipo de retorno, y copia cada parámetro a su campo correspondiente.
  Es el que se ejecuta cuando le pasás dos argumentos.
*/
  // public Libreria(string nombre, string lugar) {
  //   _nombre = nombre;
  //   _lugar = lugar;
  // }

/*
  3. El segundo constructor (sin parámetros)
  public Libreria() : this("Sin nombre", "Sin ubicación") {
  }
  Esto es nuevo, vayamos parte por parte.

  public Libreria()
  Mismo nombre que la clase: Libreria. Sí, es un constructor, aunque no reciba nada.
  Paréntesis vacíos: no pide ningún dato para crear el objeto.
  Esto es lo que hace posible escribir new Libreria(); sin argumentos.
  : this("Sin nombre", "Sin ubicación")

  Esta es la parte clave, y se llama encadenamiento de constructores.

  this en este contexto especial (justo después de los paréntesis de un constructor, con : adelante) significa "llamá a otro constructor de esta misma clase".
  ("Sin nombre", "Sin ubicación") son los argumentos que le pasa a ese otro constructor.
  C# busca, dentro de la misma clase, un constructor que reciba (string, string). Encuentra el de arriba, y lo ejecuta primero, con esos dos valores fijos.
  { } (el cuerpo, vacío)

  El cuerpo del constructor sin parámetros queda vacío porque todo el trabajo ya lo hizo el otro constructor al que delegó. No hace falta repetir _nombre = ... acá.

  El orden real de ejecución

  Cuando hacés new Libreria():

  C# ve que este constructor dice : this(...).
  Antes de ejecutar el cuerpo { } (que está vacío), ejecuta el constructor Libreria(string, string) con "Sin nombre" y "Sin ubicación".
  Ese constructor asigna _nombre = "Sin nombre" y _lugar = "Sin ubicación".
  Vuelve al constructor vacío y ejecuta su cuerpo (que no tiene nada más que hacer).
*/
  // public Libreria() : this("Sin nombre", "Sin ubicación") {
  // }

/*
  4. Por qué esto evita repetir código
  Sin this(...), tendrías que escribir la asignación dos veces:
  Forma repetitiva, sin encadenar (funciona, pero está peor)
  public Libreria() {
    _nombre = "Sin nombre";
    _lugar = "Sin ubicación";
  }

  public Libreria(string nombre, string lugar) {
    _nombre = nombre;
    _lugar = lugar;
  }
  Con solo 2 campos no se nota tanto, pero si Libreria tuviera 10 campos, y mañana agregás un campo nuevo, tendrías que acordarte de sumarlo en los dos constructores. Con this(...), la lógica de asignación vive en un solo lugar (el constructor con parámetros), y el otro constructor solo le pasa valores por defecto.
*/

/*
  Uso 1: this dentro del cuerpo, para distinguir campo de parámetro
  Es el que vimos primero, con Vehiculo y Cuenta. 
  
  Se usa dentro de las llaves { } de un método o constructor, para decir "el campo de este objeto", cuando el parámetro se llama igual que el campo:
  public Libreria(string nombre, string lugar) {
    this.nombre = nombre;   // this.nombre = el campo | nombre = el parámetro
    this.lugar = lugar;
  }
  Esto hace falta solo si el campo y el parámetro tienen el mismo nombre.
  En tu código actual no lo necesitás, porque tus campos llevan _ (_nombre, _lugar) y no chocan con los parámetros (nombre, lugar).
*/
// public Libreria(string nombre, string lugar) {
//   this.nombre = nombre;   // this.nombre = el campo | nombre = el parámetro
//   this.lugar = lugar;
// }

/*
  5. GetNombre() y GetLugar()
  public string GetNombre() {
    return _nombre;
  }

  public string GetLugar() {
    return _lugar;
  }
  Sin cambios respecto a lo que ya tenías: son los getters, la única puerta de lectura de los campos privados.
*/
//   public string GetNombre() {
//     return _nombre;
//   }

//   public string GetLugar() {
//     return _lugar;
//   }

//   public string Nombre {
//     get { return _nombre; } // <- get leer nombre
//     set { _nombre = value; } // <- set modifica el nombre
//   }

//   public string Lugar {
//     get { return _lugar; }
//   }
// }

/*
7. Cómo se vería en el diagrama de clases
Cuando hay más de un constructor, el diagrama UML lista ambos, porque son miembros distintos:

┌──────────────────────────────────────┐
│              Libreria                │
├──────────────────────────────────────┤
│ - nombre: string                     │
│ - lugar: string                      │
├──────────────────────────────────────┤
│ + Libreria(nombre: string,           |
  lugar: string)                       │
│ + Libreria()                         │
│ + GetNombre(): string                │
│ + GetLugar(): string                 │
└──────────────────────────────────────┘

No hay una forma especial de marcar "este constructor delega en el otro" en el diagrama; eso es un detalle de implementación que se explica en la justificación, no en el dibujo.
*/