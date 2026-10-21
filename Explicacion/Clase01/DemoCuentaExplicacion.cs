namespace EstudioCSharp.Explicacion.Clase02;

/*
  1. namespace EstudioCSharp.Temas.Clase02;

  Un namespace es como el "apellido" de tus clases: sirve para agruparlas y evitar choques de nombres.
  Tu clase se llama Cuenta, pero su nombre completo es EstudioCSharp.Temas.Clase02.Cuenta. 
  Si mañana otra librería tuviera su propia clase Cuenta, el namespace las diferencia.
  El ( ; ) al final significa que todo el archivo pertenece a ese namespace.
*/


/*
  Visión general: el archivo tiene dos clases. 
  (Cuenta) = es el molde que modela una cuenta bancaria. (clase contenedora de datos)
  (DemoCuenta) = es una clase auxiliar cuyo único trabajo es probar Cuenta (usarla). (clase de funcion)
*/

/*

2. public class Cuenta

  Public = Es es modificador de acceso. Esta clase es VISIBLE desde cualquier parte del proyecto.
  class = Es la palabra reservada que indica que estamos definiendo una clase.
  Cuenta = Es el nombre de la clase. Por convención, los nombres de clases empiezan con Mayuscula.

  Importante: Cuenta NO es el nombre de un objeto, es el nombre de la clase. Esta diferencia es central en POO:
  Clase = el plano de una casa. Describe cómo son todas las casas de ese tipo, pero no podés vivir en un plano.
  Objeto (o instancia) = una casa real construida con ese plano. Podés construir muchas casas con el mismo plano.

*/
public class Cuenta {

/*
  3. Los atributos (campos)

  private string _titular;
  private decimal _saldo;

  Cada línea tiene la forma:

  [visibilidad] - [tipo] - [nombre];
  private: solo el código dentro de la clase (Cuenta) puede leer o modificar esto.
  string / decimal: el tipo de dato. string es texto; decimal es un número con decimales pensado para dinero (es exacto, a diferencia de double).
  _titular / _saldo: el nombre. El guion bajo ( _ ) al principio es una convención para reconocer a simple vista que es un campo privado. (El compilador no lo exige.)

  ¿Qué son private y public? Son niveles de visibilidad, es decir, quién puede "ver" y "usar" algo:

  private = privado. Solo se ve desde adentro de la propia clase.
  public = público. Se ve desde cualquier lugar.
  ¿Por qué el estado es privado? Para proteger los datos. 
  Si _saldo fuera público, cualquiera podría escribir cuenta1._saldo = -999999. 
  Al ser privado, el único camino para cambiarlo es pasar por los métodos que la clase ofrece (como Depositar), donde se pueden validar las reglas. 
  Eso es encapsulamiento: el objeto controla su propio estado.

  Estos campos guardan el estado del objeto. Cada instancia tiene su propia copia: la cuenta de Ana y la de Luis tendrán cada una su _titular y su _saldo.
*/
  private string _titular;
  private decimal _saldo;

/*
  4. El constructor
  public Cuenta(string titular, decimal saldoInicial) {
    _titular = titular;
    _saldo = saldoInicial;
  }
  ¿Es una función?. Es muy parecida a un método, pero es un constructor, un miembro especial con reglas propias:
  Tiene el mismo nombre que la clase (Cuenta).
  No lleva tipo de retorno: fijate que no dice void ni int ni nada entre public y Cuenta.
  Se ejecuta automáticamente una sola vez, en el momento de crear el objeto con new.
  Su misión es dejar al objeto en un estado inicial válido: acá, asignarle titular y saldo. nada mas.

  Comparación con Kotlin, que ya conocés: es el equivalente a 
  class Cuenta(titular: String, saldoInicial: Double) más el bloque init { }, pero en C# se escribe como un miembro aparte.

  ¿Por qué los parámetros se escriben así?
  (string titular, decimal saldoInicial)

  En C# la forma es tipo nombre, separados por comas. Al revés que Kotlin (nombre: Tipo).
  string titular: "recibo un texto y lo voy a llamar titular".
  decimal saldoInicial: "recibo un decimal y lo voy a llamar saldoInicial".

  Detalles:
  Los parámetros no llevan public ni private. 
  Son variables locales que solo existen mientras corre el constructor. 
  La visibilidad solo se aplica a miembros de la clase (campos, métodos, constructores).
  Los parámetros son datos de entrada: son la forma en que "desde afuera" le pasás información a la clase.

  ¿Por qué _titular = titular;?
  Hay dos cosas con nombres parecidos:

  titular (sin guion) es el parámetro, el dato que llega desde afuera.
  _titular (con guion) es el campo, la memoria del objeto. (que esta declarada arriba como private)
  La línea copia lo que llegó (titular = derecha) dentro del campo (_titular = izquierda). 
  El = en programación es asignación: "guardá el valor de la derecha en lo de la izquierda". Sin esta línea, el dato llegaría al constructor y se perdería al terminar.
  El guion bajo es justamente lo que evita confundirse entre parámetro y campo.
*/
  public Cuenta(string titular, decimal saldoInicial) {
    _titular = titular;
    _saldo = saldoInicial;
  }

/*
  5. El método Depositar
  public void Depositar(decimal monto){
    if (monto <= 0) return;
    _saldo += monto;
  }
  Sí, esto es una función, y en POO se llama método (una función que pertenece a una clase). 
  Se lee así:
  public: se puede llamar desde afuera.
  void: tipo de retorno. void significa "no devuelve nada", solo hace una acción.
  Depositar: el nombre del método (verbo, en PascalCase).
  (decimal monto): un parámetro de entrada.

  Adentro:
  if (monto <= 0) return;: si el monto es cero o negativo, return corta el método ahí mismo y no hace nada más. 
  Es una validación: la clase se protege sola.
  _saldo += monto;: es la forma abreviada de _saldo = _saldo + monto;. Suma el monto al saldo actual.

  Fijate que este método puede tocar _saldo aunque sea privado, porque está adentro de la misma clase (Cuenta).
*/
  public void Depositar(decimal monto) {
    if (monto <= 0) return;
    _saldo += monto;
  }

/*
  6. El método Describir
  public string Describir() => $"{_titular}: ${_saldo}";
  string: este método sí devuelve algo: un texto.
  Describir(): no recibe parámetros (paréntesis vacíos).
  =>: sintaxis corta para métodos de una sola expresión. Significa "devuelve esto". 

  Equivale a:
  public string Describir() {
    return $"{_titular}: ${_saldo}";
  }
  $"...": el $ antes de las comillas activa la interpolación: lo que esté entre { } se reemplaza por su valor. 
  Si _titular es "Ana" y _saldo es 1250, el resultado es Ana: $1250. 
  (El $ que está dentro de las comillas, antes de {_saldo}, es solo el símbolo de peso como texto.)
*/
  public string Describir() => $"{_titular}: ${_saldo}";
}

/*
  7. La clase DemoCuenta
  public static class DemoCuenta {
    public static void Ejecutar() {
      ...
    }
  }
  static class: una clase estática no se puede instanciar (no podés hacer new DemoCuenta()). 
  Sirve como un contenedor de utilidades. Sus miembros pertenecen a la clase, no a un objeto.
  public static void Ejecutar(): un método estático. Al ser static, se llama directamente por el nombre de la clase: DemoCuenta.Ejecutar(), sin crear un objeto. 
  Por eso Program.cs puede llamarlo así.
  La usamos para poder correr el código de prueba desde el menú.

  8. Adentro de Ejecutar(): 
  usar la clase
  var cuenta1 = new Cuenta("Ana", 1000m);
  cuenta1.Depositar(250m);
  Console.WriteLine(cuenta1.Describir());

  Línea 1: var cuenta1 = new Cuenta("Ana", 1000m);
  new Cuenta(...): le pide a .NET que construya un objeto a partir del plano Cuenta. Reserva memoria y llama al constructor.
  "Ana" y 1000m: son los argumentos, los valores concretos que se pasan. Van a parar a los parámetros titular y saldoInicial en ese mismo orden.
  1000m: la m indica que el número es decimal. Sin ella, C# lo toma como double y no compila.
  var cuenta1: declara la variable cuenta1 y deja que el compilador deduzca el tipo (Cuenta). Equivale a escribir Cuenta cuenta1 = ....
  cuenta1 guarda una referencia al objeto creado.

  Línea 2: cuenta1.Depositar(250m);
  El punto significa "dentro de cuenta1, ejecutá su método Depositar".
  250m es el argumento que llega al parámetro monto. El saldo pasa de 1000 a 1250.

  Línea 3: Console.WriteLine(cuenta1.Describir());
  Primero se ejecuta cuenta1.Describir(), que devuelve el texto "Ana: $1250".
  Después Console.WriteLine(...) lo imprime en la terminal para que lo puedas ver.
*/
public static class DemoCuenta {
  public static void Ejecutar() {
    var cuenta1 = new Cuenta("Ana", 1000m);
    cuenta1.Depositar(250m);
    Console.WriteLine(cuenta1.Describir());
  }
}