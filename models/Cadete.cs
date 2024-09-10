using System.Text;

namespace TP_01.models;
public class Cadete
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    public Cadete()
    {

    }

    public Cadete(string id, string nombre, string direccion, string telefono, List<Pedido> listaPedidos)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
    public Cadete(string id, string nombre, string direccion, string telefono)
    : this(id, nombre, direccion, telefono, new List<Pedido>()) { }

}
