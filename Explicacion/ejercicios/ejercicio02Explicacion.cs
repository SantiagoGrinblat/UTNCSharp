namespace EstudioCSharp.Explicacion.ejercicios;


/*

  0. Visión general: dos zonas

  El archivo tiene dos zonas con funciones distintas:

  Zona / Líneas /	Qué es
  Uso (arriba) / Las 2 primeras líneas / Instrucciones que se ejecutan
  Definición (abajo) / public class Vehiculo { ... } / Un plano que no se ejecuta, solo describe

  El orden en que pasan las cosas:
  El compilador lee todo el archivo y registra que existe la clase Vehiculo.
  Arranca el programa y ejecuta la línea 1.
  Ejecuta la línea 2.
  Termina.

  La clase está escrita abajo, pero ya existe cuando se ejecuta la línea 1. Esto es lo que da la sensación de "mezclado", y lo vimos antes: escribir una clase no ejecuta nada.

*/

/*
  2. La zona de uso
  2.1 Vehiculo vehiculo = new Vehiculo("Ferrari", "Enzo", "AA000AA");

  Se puede partir en dos mitades alrededor del =.

  Mitad izquierda: Vehiculo vehiculo
  El primer Vehiculo es el tipo de la variable.
  vehiculo (minúscula) es el nombre de la variable. C# distingue mayúsculas, por eso pueden coexistir sin problema.
  Es equivalente a: var vehiculo = ..., donde el compilador deduce el tipo.

  Mitad derecha: new Vehiculo("Ferrari", "Enzo", "AA000AA")
  new: "construí un objeto nuevo".
  Vehiculo(...): "usando el plano Vehiculo, y llamando a su constructor".
  "Ferrari", "Enzo", "AA000AA": los argumentos, los valores reales que viajan a los parámetros en el mismo orden (el primero a marca, el segundo a modelo, el tercero a patente).

  El = guarda el resultado en la variable. 
  Ojo: lo que guarda vehiculo no es el objeto entero, sino una referencia (algo así como la dirección donde está el objeto en memoria).
  La variable "apunta" al objeto.

  2.2 vehiculo.Info();
  El punto significa "dentro de este objeto, ejecutá...".
  Info() recibe como "este objeto" al que apunta vehiculo, así que lee sus campos.
*/
// Vehiculo vehiculo = new Vehiculo("Ferrari", "Enzo", "AA000AA");
// vehiculo.Info();

/*
  1. La zona de definición (la clase)
  1.1 public class Vehiculo {}
  public: cualquiera puede usar esta clase.
  class: "estoy declarando una clase".
  Vehiculo: el nombre de la clase. Por convención empieza con mayúscula.
  { ... }: todo lo que está entre las llaves pertenece a la clase.

  Esta línea solo dice: "existe un tipo de cosa llamado Vehiculo". Todavía no existe ningún vehículo concreto.
*/
public class Vehiculo {

/*
  1.2 Los campos (lo que el vehículo guarda)
  public string marca;
  public string modelo;
  private string _patente;
  
  Cada línea sigue este orden: visibilidad tipo nombre;

  string: el tipo (texto).
  public: se puede leer y modificar desde afuera (vehiculo.marca = "Fiat" funciona).
  private: solo se toca desde adentro de la clase. Desde afuera, vehiculo._patente da error de compilación (CS0122).
  DATO IMPORTANTE: Los campos PRIVATE se nombran con _ (guion bajo) adelante y en camelCase (_saldo, _patente). 
  Es una convención, no una obligación del compilador.

  Estos campos son la memoria de cada objeto. 
  Al principio están vacíos (un string sin valor vale null). Alguien tiene que llenarlos, y ese es el trabajo del constructor.
  Cada vehículo que crees va a tener su propia copia de estos tres campos.
*/
  public string marca;
  public string modelo;
  private string _patente;

/*
  1.3 El constructor (el que llena los campos)
  public Vehiculo(string marca, string modelo, string patente) {
    this.marca = marca;
    this.modelo = modelo;
    this._patente = patente;
  }

  La firma (la primera línea):
  public: se puede llamar desde afuera (si fuera private, nadie podría hacer new Vehiculo(...)).
  Vehiculo: SIEMPRE EL CONSTRUCTOR TIENE QUE LLEVAR EXACTAMENTE EL MISMO NOMBRE QUE LA CLASE. Así C# sabe que es un constructor.
  No lleva tipo de retorno (ni void ni nada). Eso también lo distingue de un método.
  (string marca, string modelo, string patente): los parámetros. 
  Son los datos que necesita para poder construir el objeto, con el formato tipo nombre separados por comas.

  El cuerpo: tres asignaciones. En cada una, la derecha (parametro) se guarda en la izquierda (campos):

  this._patente = patente;
      ↑ campo | ↑ parámetro
  Para poder distinguir esto necesitás conocer this.

  1.4 this: la palabra que resuelve el conflicto de nombres

  Dentro del constructor hay dos cosas llamadas marca:
  El parámetro marca: una variable temporal que solo existe mientras corre el constructor.
  El campo marca: pertenece al objeto y vive mientras el objeto exista.

  Cuando escribís marca a secas, C# elige el más cercano: el parámetro. Por eso existe this:
  this significa "este objeto", el que se está construyendo ahora mismo.
  Entonces this.marca es "el campo marca de este objeto". Se lee: "el campo marca de este objeto recibe el valor del parámetro marca".

  ¿Qué pasa si te olvidás del this?
  marca = marca; // parámetro = parámetro
  Se asigna el parámetro a sí mismo, el campo queda en null y el compilador solo te avisa con una advertencia (CS1717). Es un error clásico.

  Con _patente no necesitás this, porque el parámetro se llama patente (sin guion bajo) y no hay conflicto. 
  Por eso _patente = patente; funcionaría igual. 
  Poner this._patente no está mal, solo es redundante. Ese es justamente el motivo de la convención _: te evita usar this en todos lados.

  Un dato importante: si no definís ningún constructor, C# te da uno vacío (new Vehiculo()). 
  Cuando definís uno con parámetros, ese vacío desaparece. Con tu clase, new Vehiculo() da error: hay que pasarle los tres datos sí o sí. 
  Eso te asegura que ningún vehículo exista "a medias".
*/
  // public Vehiculo(string marca, string modelo, string patente) {
  //   this.marca = marca;
  //   this.modelo = modelo;
  //   this._patente = patente;
  // }

/*
  1.5 El método Info()
  public void Info() {
    Console.WriteLine($"Marca: {marca} | Modelo: {modelo} | Patente: {_patente}");
  }
  public: se puede llamar desde afuera.
  void: no devuelve nada, solo hace algo.
  Info(): nombre del método; los paréntesis vacíos significan que no recibe datos.
  $"...": interpolación. Lo que está entre { } se reemplaza por el valor.
  {marca}: acá no hay conflicto de nombres (no hay ningún parámetro marca), así que C# encuentra el campo. 
  Es lo mismo que escribir {this.marca}.

  El método puede leer _patente aunque sea privado, porque está dentro de la clase. 
  Es la única forma que tiene el mundo exterior de "ver" la patente.
*/
  // public void Info() {
  //   Console.WriteLine($"Marca: {marca} | Modelo: {modelo} | Patente: {_patente}");
  // }
}