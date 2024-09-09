namespace TP_01.models;
class Cadeteria
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; private set; }
    public List<Pedido> ListaPedidos { get; private set; }

    public Cadeteria(string nombre, string telefono, List<Cadete> listaCadetes)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = listaCadetes ?? new List<Cadete>();
        ListaPedidos = new List<Pedido>();
    }
    public Cadeteria()
    {
        ListaCadetes = new List<Cadete>();
        ListaPedidos = new List<Pedido>();
    }
    public Cadeteria(string nombre, string telefono)
    : this(nombre, telefono, new List<Cadete>()) { }

    public void AgregarCadete(string id, string nombre, string direccion, string telefono)
    {
        var nuevoCadete = new Cadete(id, nombre, direccion, telefono);
        ListaCadetes.Add(nuevoCadete);
    }

    public void AsignarPedido(string idCadeteInicial, Pedido pedido)
    {
        var cadeteInicial = ListaCadetes.Find(cadete => cadete.Id == idCadeteInicial);
        if (cadeteInicial != null)
        {
            cadeteInicial.AsignarPedido(pedido.Nro, pedido.IdClientePropietario, pedido.Observaciones);
        }
    }
    public string GenerarInforme()
    {
        return string.Join("\n", ListaCadetes.Select(cadete => $"Nombre: {cadete.Nombre}, Jornal: {cadete.CalcularJornal()} por {cadete.ListaPedidos.Select(p => p.Estado == EstadoPedido.Entregado).Count()} envios completados"));
    }

    public void AgregarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public string verPedidos()
    {
        return string.Join("\n", ListaPedidos.Select(pedido => $"{pedido.Nro}"));
    }
}

