namespace EstudioCSharp.Explicacion.Clase02;

//? ===== Ejemplo 1: estilo métodos (Get/Set) =====
/*
  El uso

  Producto producto = new Producto();
  producto.SetNombre("  Yerba  ");
  producto.SetPrecio(2500m);
  new Producto(): no definiste constructor, así que C# usa el vacío por defecto. El objeto nace con _nombre = "" y _precio = 0.
  p.SetNombre(" Yerba "): el argumento entra al parámetro value, se hace Trim() y se guarda "Yerba".
  2500m: la m marca el literal como decimal. Sin ella, C# lo toma como double y no compila.

  Console.WriteLine(producto.GetNombre()); // Yerba
  Console.WriteLine(producto.GetPrecio()); // 2500 
  Entra -100, la condición value < 0 es verdadera, se ejecuta return y el precio sigue valiendo 2500. 
  El error se ignora en silencio (más adelante, con excepciones, podrás avisar que hubo un problema).
*/
// Producto producto = new Producto();
// producto.SetNombre("  Yerba  ");
// producto.SetPrecio(2500m);

// Console.WriteLine(producto.GetNombre());   // Yerba
// Console.WriteLine(producto.GetPrecio());   // 2500

//producto.SetPrecio(-100m);                 // se ignora
//Console.WriteLine(producto.GetPrecio());   // 2500

//? ===== Ejemplo 2: estilo properties =====
/*
  El uso, paso a paso
  Alumno alumno = new Alumno();
  alumno.Nombre = "  Lucía  ";   // ejecuta set de Nombre → guarda "Lucía"
  alumno.Nota = 8;               // ejecuta set de Nota → 8 está en rango, se guarda
  Console.WriteLine(alumno.Nombre);    // ejecuta get → Lucía
  Console.WriteLine(alumno.Nota);      // ejecuta get → 8
  Console.WriteLine(alumno.Aprobado);  // 8 >= 6 → True

  alumno.Nota = 15;              // ejecuta set: 15 > 10 → return, no se guarda
  Console.WriteLine(alumno.Nota);  // sigue en 8

  Con alumno.Nota = 15, el set recibe value = 15, la condición value > 10 da verdadero, ejecuta return y _nota queda en 8.
*/
// Alumno alumno = new Alumno();
// alumno.Nombre = "  Lucía  ";
// alumno.Nota = 8;
// Console.WriteLine(alumno.Nombre);    // Lucía
// Console.WriteLine(alumno.Nota);      // 8
// Console.WriteLine(alumno.Aprobado);  // True

// alumno.Nota = 15;                    // se ignora
// Console.WriteLine(alumno.Nota);      // 8

// public class Producto {

//? ===== Ejemplo 1: estilo métodos (Get/Set) =====
/*
  Los campos
  private string _nombre = "";
  private decimal _precio;

  Los dos son private: solo la clase Producto los puede tocar directamente.
  _nombre = "" arranca con texto vacío. Sin ese valor inicial, valdría null.
  _precio no tiene valor inicial: los números arrancan en 0 solos.
  decimal es el tipo indicado para dinero, porque es exacto.
*/
  // private string _nombre = "";
  // private decimal _precio;

/*
  El getter GetNombre()
  public string GetNombre() {
    return _nombre;
  }
  public: se puede llamar desde afuera.
  string: tipo de retorno. Este método devuelve un texto.
  GetNombre(): nombre en PascalCase, sin parámetros porque no necesita datos para devolver algo.
  return _nombre;: devuelve el valor del campo y termina el método.

  Es la única puerta de lectura del campo privado. Desde afuera no se puede hacer p._nombre.
*/
  // public string GetNombre() {
  //   return _nombre;
  // }

/*
  El setter SetNombre(...)
  public void SetNombre(string value) {
    _nombre = value.Trim();
  }
  void: no devuelve nada, solo hace una acción (guardar).
  string value: parámetro de entrada. Acá value es un nombre que elegiste vos: podría llamarse nuevoNombre.
  value.Trim(): elimina los espacios al principio y al final. Con " Yerba " queda "Yerba".
  _nombre = ...: guarda el resultado en el campo.

  El setter es el lugar para limpiar y validar antes de guardar.
*/
  // public void SetNombre(string value) {
  //   _nombre = value.Trim();
  // }

/*
  El setter es el lugar para limpiar y validar antes de guardar.
  GetPrecio() y SetPrecio(...)

  public decimal GetPrecio() {
    return _precio;
  }

  public void SetPrecio(decimal value) {
    if (value < 0) return;
    _precio = value;
  }
  GetPrecio() es igual que GetNombre(), solo que devuelve un decimal, en lugar de un nombre.
  En SetPrecio, if (value < 0) return; es una validación: 
  un precio negativo no tiene sentido, así que return corta el método antes de guardar. 
  El precio anterior queda intacto.
*/
//   public decimal GetPrecio() {
//     return _precio;
//   }

//   public void SetPrecio(decimal value) {
//     if (value < 0) return;
//     _precio = value;
//   }
// }

//? ===== Ejemplo 2: estilo properties =====

// public class Alumno {

/*
  Ejemplo 2: Alumno (con properties)
  Cómo funciona una property?
  Una property se ve desde afuera como un campo (alumno.Nota = 8), pero por dentro ejecuta código:
  ? get: se ejecuta cuando leés (alumno.Nota) y debe devolver un valor.
  ? set: se ejecuta cuando asignás (alumno.Nota = 8). Adentro existe una variable especial, (value), que contiene lo que asignaste (el 8).

  La diferencia con el ejemplo 1: allá value era un parámetro que declarabas vos. 
  Acá value es una palabra reservada que aparece sola dentro de set.

  La clase
  Los campos
  private string _nombre = "";
  private int _nota;

  Igual que antes: privados, con _. Las properties van a ser la cara pública de estos campos.
*/
  // private string _nombre = "";
  // private int _nota;

/*
  La property Nombre
  public string Nombre {
    get { return _nombre; }
    set { _nombre = value.Trim(); }
  }
  public string Nombre: visibilidad, tipo y nombre. Va en PascalCase y sin paréntesis (eso la distingue de un método).
  get { return _nombre; }: al leer alumno.Nombre, devuelve el campo.
  set { _nombre = value.Trim(); }: al asignar alumno.Nombre = " Lucía ", value vale " Lucía ", se le hace Trim() y queda "Lucía".
*/
  // public string Nombre {
  //   get { return _nombre; }
  //   set { _nombre = value.Trim(); }
  // }

/*
  La property Nota
  public int Nota {
    get { return _nota; }
    set {
      if (value < 0 || value > 10) return;
      _nota = value;
    }
  }
  || significa "o": la condición es verdadera si value es menor que 0 o mayor que 10.
  Si la nota está fuera del rango 0 a 10, return sale del set sin guardar nada.
  Si está en rango, se guarda.
*/
  // public int Nota {
  //   get { return _nota; }
  //   set {
  //     if (value < 0 || value > 10) return;
  //     _nota = value;
  //   }
  // }

/*
  La property Aprobado (solo lectura)
  public bool Aprobado {
    get { return _nota >= 6; }
  }
  bool: tipo verdadero/falso.
  No tiene set, así que es de solo lectura: alumno.Aprobado = true; da error de compilación (CS0200).
  No tiene campo propio: se calcula cada vez que la leés a partir de _nota. Si la nota cambia, Aprobado cambia sola.
  >= compara "mayor o igual" y devuelve true o false.

  Con una sola línea, se puede abreviar: public bool Aprobado => _nota >= 6;.
*/
//   public bool Aprobado {
//     get { return _nota >= 6; }
//   }
// }