namespace EstudioCSharp.Ejercicios.Clase02;

// Articulo articulo = new Articulo();
// articulo.Marca = "Ferrari";
// articulo.Modelo = "Enzo";

// Console.WriteLine(articulo.Marca);
// Console.WriteLine(articulo.Modelo);

public class Articulo {
  private string _marca = "";
  private string _modelo = "";

  public string Marca {
    get { return _marca; }
    set { _marca = value; }
  }
  public string Modelo {
    get { return _modelo; }
    set { _modelo = value; }
  }
  
}