using EstudioCSharp.Ejercicios.Clase02;
using EstudioCSharp.Temas.Clase02;
// using EstudioCSharp.Temas.Clase02.herencia;
// using EstudioCSharp.Temas.Clase02.overloading;

// var opcion = Console.ReadLine();   // lee lo que tipeás en la terminal

// switch (opcion)
// {
//   case "1": DemoCuenta.Ejecutar(); break;
//   case "2": Ejercicio01.Ejecutar(); break;
//   default: Console.WriteLine("Opción inválida"); break;
// }

// Articulo articulo = new Articulo();
// articulo.Marca = "Ferrari";
// articulo.Modelo = "Enzo";

// Console.WriteLine(articulo.Marca);
// Console.WriteLine(articulo.Modelo);

// Cine pelicula1 = new Cine();
// pelicula1.Pelicula = "Iron Man";
// pelicula1.Horarios = "20:00Hs";

// Cine pelicula2 = new Cine();
// pelicula2.Pelicula = "Capitan America";
// pelicula2.Horarios = "23:00Hs";

// Cine pelicula3 = new Cine();
// pelicula3.Pelicula = "Dragon ball";
// pelicula3.Horarios = "17:00Hs";

// Console.WriteLine(pelicula1.ObtenerCartelera());
// Console.WriteLine(pelicula2.ObtenerCartelera());
// Console.WriteLine(pelicula3.ObtenerCartelera());

// Libreria libreria = new Libreria("Biblioteca del Barrio", "Dorrego");
// Console.WriteLine(libreria.GetNombre());
// Console.WriteLine(libreria.GetLugar());

/*
  El using de arriba
  using EstudioCSharp.Temas.Clase03;

  Program.cs vive en la raíz del proyecto, en el namespace por defecto del proyecto
  (implícito, sin declarar). Persona/Empleado/Proveedor viven en el namespace
  EstudioCSharp.Temas.Clase03. Como son namespaces DISTINTOS, acá sí hace falta el using
  explícito al principio del archivo — a diferencia de Empleado.cs y Proveedor.cs, que
  comparten namespace con Persona.cs y no lo necesitan.

  Program.cs es el único archivo con código suelto (top-level statements): no está envuelto
  en una clase ni en un Main() explícito, C# lo permite solo en este archivo especial.
*/

// //? ===== Prueba de sobrecarga =====
// Persona persona = new Persona("Ana", "Gómez");

// Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez"));
// Console.WriteLine(persona.ConcatPersonInfo("Ana", "María", "Gómez"));
// Console.WriteLine(persona.ConcatPersonInfo("Ana", "Gómez", 30));
// Salida:
// Ana Gómez
// Ana María Gómez
// Ana Gómez, 30 años

// //? ===== Prueba de herencia =====
Empleado emp = new Empleado("Mariano", "Kaimakamian", 4521, 3, "Sistemas");
// Proveedor prov = new Proveedor("Al", "Goritmo", "AX-99", "TechCorp");

Console.WriteLine(emp.ObtenerFichaEmpleado());
// Console.WriteLine(prov.ObtenerFichaProveedor());
// Salida:
// Mariano Kaimakamian - Legajo 4521, 3 años en Sistemas
// Al Goritmo - Compañía TechCorp, acceso AX-99

// //? ===== Prueba de protected: NormalizarNombre =====
// Empleado emp2 = new Empleado("  juan  ", "  perez  ", 100, 1, "Ventas");

// emp2.NormalizarNombre();
// Console.WriteLine(emp2.ObtenerFichaEmpleado());
// _name pasó de "  juan  " a "JUAN" (Trim + ToUpper). Esto solo funciona porque
// Empleado pudo tocar _name directamente gracias a protected en Persona.
// Salida:
// JUAN PEREZ - Legajo 100, 1 años en Ventas

//? ===== Prueba de sobrecarga: Calculadora =====
// Calculadora calc = new Calculadora();

// Console.WriteLine(calc.Sumar(2, 3));         // int, int   → Sumar(int,int)      → 5
// Console.WriteLine(calc.Sumar(2, 3, 4));      // int,int,int → Sumar(int,int,int) → 9
// Console.WriteLine(calc.Sumar(2.5, 3.1));     // double,double → Sumar(double,double) → 5.6
// Console.WriteLine(calc.Sumar(2, 3.5));       // int, double → conversión implícita del 2 a 2.0 → 5.5

// Console.WriteLine(calc.Formatear("hola", 3));   // string, int → repite "hola" 3 veces → holaholahola
// Console.WriteLine(calc.Formatear(3, "hola"));   // int, string → formato distinto → [3] hola
// Salida:
// 5
// 9
// 5.6
// 5.5
// holaholahola
// [3] hola


// //? ===== Upcasting y downcasting con el proyecto real =====

// // 1. Upcasting implícito: una variable Persona apuntando a un Empleado real
// Persona p = new Empleado("Mariano", "Kaimakamian", 4521, 3, "Sistemas");
// Console.WriteLine(p.GetName());
// // "Mariano" — funciona porque GetName() es de Persona, y eso SÍ está disponible con este tipo

// // 2. Downcasting: recupero el tipo real para usar lo que es propio de Empleado
// Empleado empRecuperado = (Empleado)p;
// Console.WriteLine(empRecuperado.ObtenerFichaEmpleado());
// // "Mariano Kaimakamian - Legajo 4521, 3 años en Sistemas" — ahora SÍ compila, porque
// // empRecuperado está declarada como Empleado otra vez

// // 3. Un caso de uso real: una lista de Personas que en verdad son distintos tipos
// List<Persona> personas = new List<Persona> {
//   new Empleado("Ana", "Gómez", 200, 5, "RRHH"),
//   new Proveedor("Al", "Goritmo", "AX-99", "TechCorp"),
//   new Persona("Juan", "Pérez")   // esta es una Persona pura, sin ser Empleado ni Proveedor
// };

// /*
//   List<Persona> personas = ...
//   Esto es upcasting aplicado en la práctica: la lista solo puede tener UN tipo declarado
//   (Persona), pero cada elemento adentro es en realidad un objeto de un tipo distinto
//   (Empleado, Proveedor, o Persona pura). Esto es exactamente lo que el PDF llama "tratamiento
//   genérico" — poder agrupar objetos de distintas subclases bajo un mismo tipo común.
// */

// foreach (Persona persona in personas) {
//   Console.WriteLine($"--- {persona.GetName()} {persona.GetLastName()} ---");

//   // is chequea el tipo REAL del objeto en memoria antes de castear, evitando el crash
//   if (persona is Empleado empleado) {
//     Console.WriteLine(empleado.ObtenerFichaEmpleado());
//   } else if (persona is Proveedor proveedor) {
//     Console.WriteLine(proveedor.ObtenerFichaProveedor());
//   } else {
//     Console.WriteLine("Es una Persona sin rol específico.");
//   }
// }
// // Salida:
// // --- Ana Gómez ---
// // Ana Gómez - Legajo 200, 5 años en RRHH
// // --- Al Goritmo ---
// // Al Goritmo - Compañía TechCorp, acceso AX-99
// // --- Juan Pérez ---
// // Es una Persona sin rol específico.
