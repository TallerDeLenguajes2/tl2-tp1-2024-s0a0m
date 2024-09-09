using System.Runtime.InteropServices;

namespace TP_01.models;
public enum EstadoPedido
{
    NoEntregado,
    Entregado
}
class Pedido
{
    public string Nro { get; set; }
    public string Observaciones { get; set; }
    public string IdClientePropietario { get; set; }
    public EstadoPedido Estado { get; private set; }

    public Pedido(string nro, string idClientePropietario, string observaciones = "")
    {
        Nro = nro;
        Observaciones = observaciones;
        IdClientePropietario = idClientePropietario;
        Estado = EstadoPedido.NoEntregado;
    }
    public void CambiarEstado()
    {
        Estado = Estado == EstadoPedido.Entregado ? EstadoPedido.NoEntregado : EstadoPedido.Entregado;
    }

}

