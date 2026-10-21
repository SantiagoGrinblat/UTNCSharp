namespace EstudioCSharp.Explicacion.Clase02.overloading;

/*
  Calculadora: clase dedicada solo a practicar sobrecarga, con los 3 criterios que la
  definen (cantidad, tipo, orden), separados uno por uno.
*/
// public class Calculadora {

/*
  Criterio 1: distinta CANTIDAD de parámetros
  public int Sumar(int a, int b) { return a + b; }
  public int Sumar(int a, int b, int c) { return a + b + c; }

  Mismo nombre (Sumar), mismo tipo (int) en todos los parámetros, pero difiere la cantidad
  (2 vs 3). Alcanza con esa sola diferencia para que sean dos miembros distintos.
*/
  // public int Sumar(int a, int b) {
  //   return a + b;
  // }

  // public int Sumar(int a, int b, int c) {
  //   return a + b + c;
  // }

/*
  Criterio 2: distinto TIPO en la misma posición
  public int Sumar(int a, int b) { ... }        ← ya la tenemos arriba
  public double Sumar(double a, double b) { return a + b; }

  Misma cantidad (2 parámetros), pero el tipo cambia de int a double. El compilador elige
  según el tipo de los argumentos que le pasás: Sumar(2, 3) → coincide con (int, int) →
  usa la versión de arriba. Sumar(2.5, 3.1) → coincide con (double, double) → usa esta.

  Ojo con un caso límite: Sumar(2, 3.5) — un int y un double. Acá no hay una versión con
  firma (int, double), así que C# hace una CONVERSIÓN IMPLÍCITA: sabe que un int siempre
  puede convertirse a double sin perder información (a diferencia de al revés), así que
  convierte el 2 a 2.0 y usa la versión (double, double). Esto se llama "conversión implícita
  numérica" y es distinto del casteo explícito que quizás viste en otro contexto.
*/
  // public double Sumar(double a, double b) {
  //   return a + b;
  // }

/*
  Criterio 3: mismo tipo y cantidad, distinto ORDEN
  public string Formatear(string texto, int cantidad) { ... }
  public string Formatear(int cantidad, string texto) { ... }

  Estas dos tienen: misma cantidad (2), mismos tipos involucrados (string e int), pero en
  ORDEN distinto. Eso también alcanza para ser firmas diferentes. El compilador mira
  posición por posición: Formatear("hola", 3) → primer argumento es string, segundo es int →
  matchea la primera. Formatear(3, "hola") → primer argumento es int, segundo es string →
  matchea la segunda.

  Este criterio (orden) es el que menos se usa en la práctica porque genera código confuso
  de leer, pero el PDF lo incluye como válido y puede aparecer en el parcial como pregunta
  de "¿esto compila o no?".
*/
  // public string Formatear(string texto, int cantidad) {
  //   return string.Concat(Enumerable.Repeat(texto, cantidad));
  // }

  // public string Formatear(int cantidad, string texto) {
  //   return $"[{cantidad}] {texto}";
  // }

/*
  El caso que NO compila, para que quede al lado de los que sí funcionan
  public int Restar(int a, int b) { return a - b; }
  public int Restar(int x, int y) { return x - y; }   ← ERROR, comentado a propósito

  Firma idéntica: (int, int) en ambos casos. Los nombres de los parámetros (a,b vs x,y)
  NO forman parte de la firma — el compilador ni los mira. Para él, esto es literalmente
  el mismo método declarado dos veces. Si descomentás la segunda, el proyecto deja de
  compilar con: "Type 'Calculadora' already defines a member called 'Restar' with the same
  parameter types".
*/
  // public int Restar(int a, int b) {
  //   return a - b;
  // }

  // public int Restar(int x, int y) {   // ❌ no descomentar: error de compilación
  //   return x - y;
  // }
// }