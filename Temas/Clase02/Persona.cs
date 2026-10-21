namespace EstudioCSharp.Temas.Clase02;

public class Persona {
  protected string _name;
  protected string _lastName;

  public Persona(string name, string lastName) {
    _name = name;
    _lastName = lastName;
  }

  public string GetName() {
    return _name;
  }

  public string GetLastName() {
    return _lastName;
  }
  
}