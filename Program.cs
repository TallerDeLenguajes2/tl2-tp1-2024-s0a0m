using TP_01.models;
using TP_01.helpers;
using System.ComponentModel.Design;

class GestionPedidos
{
    static void Main()
    {
        int numeroPedido = 1;
        bool salir = false;
        Cadeteria cadeteria = InicializarCadeteria();

        while (!salir)
        {
            // Console.Clear();
            Console.WriteLine("===== Gestión de Pedidos =====");
            Console.WriteLine("1. Dar de alta un pedido");
            Console.WriteLine("2. Asignar pedido a un cadete");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");


            switch (Console.ReadLine())
            {
                case "1":
                    DarDeAltaPedido(cadeteria, numeroPedido);
                    numeroPedido++;
                    break;
                case "2":
                    AsignarPedido(cadeteria);
                    break;
                case "3":
                    CambiarEstadoPedido(cadeteria);
                    break;
                case "4":
                    ReasignarPedido(cadeteria);
                    break;
                case "5":
                    salir = true;
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                // Console.ReadKey();
            }
        }
    }

    static Cadeteria InicializarCadeteria()
    {
        string cadeteFilePath = "./DB/cadete.csv";
        string cadeteriaFilePath = "./DB/cadeteria.csv";
        string separadorCsv = ";";

        Cadeteria cadeteria = CsvCarga.CargarCadeteriaDesdeCSV(cadeteriaFilePath, separadorCsv);
        CsvCarga.CargarCadetesDesdeCSV(cadeteFilePath, separadorCsv, cadeteria);

        return cadeteria;
    }

    static void DarDeAltaPedido(Cadeteria cadeteria, int numeroPedido)
    {
        Console.WriteLine("==== Alta de Pedido ====");

        Console.Write("Ingrese ID del propietario (cliente): ");
        string? idClientePropietario = Console.ReadLine();

        Console.Write("Ingrese observaciones del pedido (opcional): ");
        string? observaciones = Console.ReadLine();
        Pedido nuevoPedido = new Pedido(numeroPedido.ToString(), idClientePropietario, observaciones);
        cadeteria.AgregarPedido(nuevoPedido);
        Console.WriteLine($"Pedido creado con éxito. ID: {nuevoPedido.Nro}, Estado: {nuevoPedido.Estado}");
    }




    static void AsignarPedido(Cadeteria cadeteria)
    {

        cadeteria.ListaPedidos.ForEach(pedido => System.Console.WriteLine("#", pedido.Nro));
        Console.Write("Ingrese Nro del pedido: ");
        string? idPedido = Console.ReadLine();
        Pedido? pedidoBuscado = idPedido == null ? null : BuscarPedidoPorNro(cadeteria, idPedido);

        if (pedidoBuscado != null)
        {
            cadeteria.ListaCadetes.ForEach(cadete => System.Console.WriteLine("#", cadete.Id, cadete.Nombre));
            Console.Write("Ingrese ID del cadete: ");
            string? idCadete = Console.ReadLine();
            Cadete? cadeteAsignado = cadeteria.ListaCadetes.Find(cadete => cadete.Id == idCadete);
            if (cadeteAsignado != null)
            {
                cadeteria.AsignarPedido(cadeteAsignado.Id, pedidoBuscado);
                Console.WriteLine($"Pedido asignado a {cadeteAsignado.Nombre}");
            }
        }
        else
        {
            System.Console.WriteLine("No se encontro el pedido.");
        }
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Cambiar Estado de Pedido ====");
        Console.WriteLine("Ingrese Nro del pedido: ");
        var nroPedido = Console.ReadLine();

        if (!string.IsNullOrEmpty(nroPedido))
        {
            Pedido? pedido = BuscarPedidoPorNro(cadeteria, nroPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado();
                System.Console.WriteLine($"El estado del pedido ahora es {pedido.Estado}");
            }
        }
        else
        {
            System.Console.WriteLine("Pedido no encontrado.");
        }
    }

    static void GenerarInforme(Cadeteria cadeteria)
    {
        System.Console.WriteLine(cadeteria.GenerarInforme());
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Reasignar Pedido ====");
        Console.Write("Ingrese Nro del pedido: ");
        string? idPedido = Console.ReadLine();

        if (idPedido != null)
        {
            Pedido? pedidoBuscado = BuscarPedidoPorNro(cadeteria, idPedido);
            Cadete? cadetePedidoBuscado = BuscarCadetePorNroPedido(cadeteria, idPedido);
            if (pedidoBuscado != null && cadetePedidoBuscado != null)
            {
                cadeteria.ListaCadetes.ForEach(cadete =>
                {
                    System.Console.WriteLine("#", cadete.Id, cadete.Nombre);

                });

                Console.Write("Ingrese ID del cadete: ");
                string? idCadete = Console.ReadLine();
                Cadete? cadeteAsignado = cadeteria.ListaCadetes.Find(cadete => cadete.Id == idCadete);
                if (cadeteAsignado != null)
                {
                    cadetePedidoBuscado.EliminarPedido(pedidoBuscado.Nro);
                    cadeteAsignado.AsignarPedido(pedidoBuscado);
                    Console.WriteLine($"Pedido asignado a {cadeteAsignado.Nombre}");
                }
            }
        }
        else
        {
            System.Console.WriteLine("No se encontro el pedido.");
        }


    }

    static private Pedido? BuscarPedidoPorNro(Cadeteria cadeteria, string nroBuscado)
    {
        return cadeteria.ListaPedidos.FirstOrDefault(pedido => pedido.Nro == nroBuscado);
    }

    static private Cadete? BuscarCadetePorNroPedido(Cadeteria cadeteria, string nro)
    {
        return cadeteria.ListaCadetes
            .FirstOrDefault(cadete => cadete.ListaPedidos.Any(pedido => pedido.Nro == nro));
    }

}
