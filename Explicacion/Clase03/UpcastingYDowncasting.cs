namespace EstudioCSharp.Temas.Clase03;

//? ===== Upcasting: implícito =====

// Persona p = new Empleado("Mariano", "Kaimakamian", 4521, 3, "Sistemas");

/*
  Persona p = new Empleado(...);

  A la derecha del = se crea un Empleado, tal cual siempre. Pero a la izquierda, la variable
  NO se declara como Empleado — se declara como Persona. Esto es upcasting IMPLÍCITO: C# te
  deja hacerlo sin pedir ningún casteo explícito, porque sabe con certeza que todo Empleado
  ES un Persona (por la relación : Persona). Ir "hacia arriba" en la jerarquía (de la clase
  hija hacia la clase padre) siempre es seguro, así que no hace falta pedirlo con sintaxis
  especial.

  Punto clave del PDF, que se presta a confusión: esto NO crea un objeto nuevo ni distinto.
  En la memoria (RAM) sigue existiendo UN SOLO objeto Empleado completo, con todos sus campos
  (_name, _lastName, _legajo, _antiguedad, _departamento). Lo único que cambió es el TIPO DE
  LA VARIABLE p — la "ventana" a través de la cual estás mirando ese objeto. p es una
  referencia que apunta al mismo Empleado de siempre, pero declarada como si fuera un Persona.
*/

// Console.WriteLine(p.GetName());              // OK → "Mariano" (heredado de Persona)
// Console.WriteLine(p.ObtenerFichaEmpleado());  // ❌ ERROR DE COMPILACIÓN

/*
  p.GetName() compila sin problema: GetName() es un método de Persona, y p está declarada
  como Persona.

  p.ObtenerFichaEmpleado() NO compila, aunque el objeto real EN MEMORIA sea un Empleado y
  aunque ObtenerFichaEmpleado() exista de verdad. El motivo: el compilador decide qué métodos
  podés llamar mirando el TIPO DE LA VARIABLE (Persona), no el tipo real del objeto (Empleado).
  Como Persona no tiene ObtenerFichaEmpleado(), el compilador ni te deja escribir esa línea.
  Esto es lo que el PDF llama "se pierde el acceso a los miembros propios de la subclase" —
  los sigue teniendo el objeto, pero vos no podés llamarlos a través de esta variable.
*/

//? ===== Upcasting: explícito =====

// Empleado emp = new Empleado("Al", "Goritmo", 100, 1, "Ventas");
// Persona p2 = (Persona)emp;

/*
  Empleado emp = new Empleado(...);
  Acá emp SÍ está declarada como Empleado — tiene acceso completo, incluido
  ObtenerFichaEmpleado().

  Persona p2 = (Persona)emp;
  El (Persona) adelante de emp es un CASTEO EXPLÍCITO: le estás diciendo al compilador "tratá
  esta variable como si fuera del tipo Persona". Es el mismo resultado que el upcasting
  implícito de arriba (p2 termina siendo una referencia al mismo objeto Empleado, vista como
  Persona) — la diferencia es solo de ESTILO: acá lo escribiste vos explícitamente en vez de
  dejar que C# lo infiera solo. En upcasting, el explícito nunca es obligatorio (a diferencia
  del downcasting, que sí lo exige, como vamos a ver abajo) — pero es válido escribirlo para
  dejar la intención bien clara en el código.
*/

//? ===== Downcasting =====

// Persona ep = new Empleado("Ana", "Gómez", 200, 5, "RRHH");  // upcasting (implícito)
// Empleado e = (Empleado)ep;                                   // downcasting

/*
  Persona ep = new Empleado(...);
  Mismo patrón de upcasting que ya vimos: ep queda declarada como Persona, aunque el objeto
  real sea un Empleado. En este punto, ep.ObtenerFichaEmpleado() NO compilaría, igual que
  antes.

  Empleado e = (Empleado)ep;
  Acá está la novedad: (Empleado) adelante de ep es un casteo hacia ABAJO en la jerarquía —
  downcasting. A diferencia del upcasting, el downcasting SIEMPRE necesita casteo explícito;
  C# nunca lo hace solo, porque ir "hacia abajo" no siempre es seguro (enseguida vemos por
  qué). El paréntesis (Empleado) le pide al compilador: "confiá en que el objeto al que
  apunta ep es realmente un Empleado, y dame de vuelta una variable con ese tipo completo".

  Por qué esto SÍ funciona: cuando el objeto se creó originalmente con new Empleado(...), C#
  reservó en memoria espacio para TODOS los miembros de Empleado (los propios y los heredados
  de Persona). El upcasting de las líneas anteriores nunca borró nada de esa memoria — solo
  cambió el tipo con el que mirabas al objeto. Entonces el downcasting no "recupera" nada que
  se haya perdido; simplemente vuelve a mirar el mismo objeto completo con el tipo correcto.
  Por eso e.ObtenerFichaEmpleado() ahora SÍ compila:
*/

// Console.WriteLine(e.ObtenerFichaEmpleado());  // OK → "Ana Gómez - Legajo 200, 5 años en RRHH"

//? ===== El caso que rompe en tiempo de ejecución =====

// Persona soloPersona = new Persona("Juan", "Pérez");   // esta vez, NO es un Empleado
// Empleado eFallido = (Empleado)soloPersona;             // compila, pero...

/*
  Esta parte es la más importante para el parcial, porque el PDF no la menciona
  explícitamente pero se deduce de "solo se puede castear al mismo tipo de la instancia
  original".

  Acá soloPersona apunta a un objeto que NUNCA fue un Empleado — se creó directamente con
  new Persona(...), sin ningún legajo, antigüedad ni departamento reservado en memoria.

  La línea (Empleado)soloPersona SÍ COMPILA sin error, porque el compilador solo verifica que
  Empleado y Persona estén relacionadas por herencia (lo están). Pero en tiempo de EJECUCIÓN,
  cuando el programa efectivamente corre esa línea, revienta con una excepción:
  System.InvalidCastException: "Unable to cast object of type 'Persona' to type 'Empleado'."

  La diferencia clave con el ejemplo anterior: ahí el downcasting funcionaba porque el objeto
  real EN MEMORIA era un Empleado (aunque la variable lo mirara como Persona). Acá el objeto
  real es un Persona pura, así que no hay legajo/antigüedad/departamento para "recuperar" —
  el casteo pide algo que ese objeto nunca tuvo, y el programa falla al ejecutarse.

  Moraleja: el compilador (en tiempo de compilación) solo chequea que el casteo sea posible
  EN TEORÍA por la jerarquía de herencia. Si es válido EN LA PRÁCTICA para ese objeto puntual,
  recién se sabe en tiempo de ejecución.
*/

// Resumen de las tres ideas que se combinan acá:

// Upcasting (hija → padre) |	?Downcasting (padre → hija)
// Casteo =	Implícito (o explícito, opcional) |	Siempre explícito, obligatorio
// ¿Siempre es seguro? =	Sí, siempre funciona |	Solo si el objeto real es del tipo al que casteás
// ¿Qué pasa si falla? =	Nunca falla |	InvalidCastException en tiempo de ejecución
// ¿Se pierde algo del objeto en memoria? =	No — sigue completo, solo cambia la "ventana" |	No — se recupera el acceso a lo que ya estaba