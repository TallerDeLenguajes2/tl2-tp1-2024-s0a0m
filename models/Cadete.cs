using System.Text;

namespace TP_01.models;
class Cadete
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListaPedidos { get; private set; }

    public Cadete(string id, string nombre, string direccion, string telefono, List<Pedido> listaPedidos)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListaPedidos = listaPedidos ?? new List<Pedido>();
    }
    public Cadete(string id, string nombre, string direccion, string telefono)
    : this(id, nombre, direccion, telefono, new List<Pedido>()) { }

    public void AsignarPedido(string Nro, string ClientePropietario, string Observaciones = "")
    {
        var nuevoPedido = new Pedido(Nro, ClientePropietario, Observaciones);
        ListaPedidos.Add(nuevoPedido);
    }
    public void AsignarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public void EliminarPedido(string nro)
    {
        Pedido? pedido = ListaPedidos.Find(pedido => pedido.Nro == nro);
        if (pedido != null) ListaPedidos.Remove(pedido);
    }

    public decimal CalcularJornal()
    {
        return ListaPedidos.Count * 500;
    }
}
