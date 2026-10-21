namespace EstudioCSharp.Temas.Clase03;

//? ===== Upcasting: implícito =====

// Persona p = new Empleado("Mariano", "Kaimakamian", 4521, 3, "Sistemas");

// Console.WriteLine(p.GetName());              // OK → "Mariano" (heredado de Persona)
// Console.WriteLine(p.ObtenerFichaEmpleado());  // ❌ ERROR DE COMPILACIÓN

// Empleado emp = new Empleado("Al", "Goritmo", 100, 1, "Ventas");
// Persona p2 = (Persona)emp;

// Persona ep = new Empleado("Ana", "Gómez", 200, 5, "RRHH");  // upcasting (implícito)
// Empleado e = (Empleado)ep;                                   // downcasting

// Console.WriteLine(e.ObtenerFichaEmpleado());  // OK → "Ana Gómez - Legajo 200, 5 años en RRHH"


// Persona soloPersona = new Persona("Juan", "Pérez");   // esta vez, NO es un Empleado
// Empleado eFallido = (Empleado)soloPersona;             // compila, pero...

