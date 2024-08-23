namespace TP_01.models;
public enum EstadoPedido
{
    NoEntregado,
    Entregado
}
class Pedido
{
    public uint Nro { get; set; }
    public string Observaciones { get; set; }
    public Cliente ClientePropietario { get; set; }
    public EstadoPedido Estado { get; private set; }

    public Pedido(uint nro, Cliente clientePropietario, string observaciones = "")
    {
        Nro = nro;
        Observaciones = observaciones;
        ClientePropietario = clientePropietario;
        Estado = EstadoPedido.NoEntregado;
    }
}

