namespace TP_01.models;
public class Cadeteria
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

    public void AsignarCadeteAPedido(string idCadete, string idPedido)
    {
        Cadete? cadete = ListaCadetes.Find(cadete => cadete.Id == idCadete);
        if (cadete != null)
        {
            Pedido? pedido = ListaPedidos.Find(pedido => pedido.Nro == idPedido);
            pedido?.AsignarCadete(cadete);
        }
    }

    public void AgregarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public string VerPedidos()
    {
        return string.Join("\n", ListaPedidos.Select(pedido => $"{pedido.Nro}"));
    }
    public decimal JornalACobrar(string idCadete)
    {
        return ListaPedidos.FindAll(pedido =>
            pedido.CadeteAsignado != null && pedido.CadeteAsignado.Id == idCadete).Count * 500;
    }

    public string InformacionDePedidos()
    {
        return string.Join("\n", ListaPedidos.Select(pedido =>
            $"Número: {pedido.Nro}, Cliente: {pedido.ClientePropietario.Nombre}, " +
            $"Estado: {pedido.Estado}, Cadete Asignado: {pedido.CadeteAsignado?.Nombre ?? "No asignado"}, " +
            $"Observaciones: {pedido.Observaciones}"));
    }
    public string InformacionDeCadetes()
    {
        return string.Join("\n", ListaCadetes.Select(cadete =>
            $"ID: {cadete.Id}, Nombre: {cadete.Nombre}, Dirección: {cadete.Direccion}, " +
            $"Teléfono: {cadete.Telefono}, Jornal a Cobrar: {JornalACobrar(cadete.Id):C}"));
    }


}

