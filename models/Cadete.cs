namespace TP_01.models;
class Cadete
{
    public uint Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListaPedidos { get; private set; }

    public Cadete(uint id, string nombre, string direccion, string telefono, List<Pedido> listaPedidos)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListaPedidos = listaPedidos ?? new List<Pedido>();
    }
    public Cadete(uint id, string nombre, string direccion, string telefono)
    : this(id, nombre, direccion, telefono, new List<Pedido>()) { }
}
