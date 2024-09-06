namespace TP_01.models;
class Cadeteria
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; private set; }

    public Cadeteria(string nombre, string telefono, List<Cadete> listaCadetes)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = listaCadetes ?? new List<Cadete>();
    }
    public Cadeteria() {
        ListaCadetes =  new List<Cadete>();
    }
    public Cadeteria(string nombre, string telefono)
    : this(nombre, telefono, new List<Cadete>()) { }

    public void AgregarCadete(Cadete nuevoCadete) 
    {
        if (nuevoCadete != null) ListaCadetes.Add(nuevoCadete);;
    }
}

