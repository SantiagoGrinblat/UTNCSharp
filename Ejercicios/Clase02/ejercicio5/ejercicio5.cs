namespace EstudioCSharp.Ejercicios.Clase02;

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

public class Cine {
  private string _pelicula = "";
  private string _horarios = "";

  public string Pelicula {
    get { return _pelicula; }
    set { _pelicula = value; }
  }
  public string Horarios {
    get { return _horarios; }
    set { _horarios = value; }
  }
  public string ObtenerCartelera() {
    return $"{Pelicula} - {Horarios}";
  }
  
}