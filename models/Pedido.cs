using System.Reflection;

namespace TP_01.models;
public enum EstadoPedido
{
    NoEntregado,
    Entregado
}
public class Pedido
{
    public string Nro { get; set; }
    public string Observaciones { get; set; }
    public Cliente ClientePropietario { get; set; }
    public EstadoPedido Estado { get; private set; }
    public Cadete? CadeteAsignado { get; private set; }

    public Pedido(string nro, Cliente clientePropietario, Cadete cadeteAsignado, string observaciones = "")
    {
        Nro = nro;
        Observaciones = observaciones;
        ClientePropietario = clientePropietario;
        CadeteAsignado = cadeteAsignado;
        Estado = EstadoPedido.NoEntregado;
    }
    public Pedido(string nro, Cliente clientePropietario, string observaciones = "")
    {
        Nro = nro;
        Observaciones = observaciones;
        ClientePropietario = clientePropietario;
        CadeteAsignado = null;
        Estado = EstadoPedido.NoEntregado;
    }
    public void CambiarEstado()
    {
        Estado = Estado == EstadoPedido.Entregado ? EstadoPedido.NoEntregado : EstadoPedido.Entregado;
    }

    public void AsignarCadete(Cadete cadete)
    {
        CadeteAsignado = cadete;
    }

}

