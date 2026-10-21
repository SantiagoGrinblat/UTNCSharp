namespace EstudioCSharp.Explicacion.Clase02.herencia;

/*
  Proveedor sigue el mismo patrón que Empleado: hereda de Persona, delega en base(...),
  y agrega sus propios campos. La aclaración importante: Empleado y Proveedor son clases
  "hermanas" — ninguna hereda de la otra, ambas heredan de Persona por separado. Esto refleja
  el diagrama del PDF, donde Persona es la única clase base y de ella cuelgan dos ramas
  independientes.
*/
// public class Proveedor : Persona
// {
//   private string _codigoAcceso;
//   private string _codigoCompania;

//   public Proveedor(string name, string lastName, string codigoAcceso, string codigoCompania): base(name, lastName)
//   {
//     _codigoAcceso = codigoAcceso;
//     _codigoCompania = codigoCompania;
//   }

//   public string ObtenerFichaProveedor()
//   {
//     return $"{GetName()} {GetLastName()} - Compañía {_codigoCompania}, acceso {_codigoAcceso}";
//   }
//}