using TP_01.models;
using TP_01.helpers;

class GestionPedidos
{
    static void Main()
    {
        int numeroPedido = 1;
        bool salir = false;

        Cadeteria cadeteria = InicializarCadeteria();

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("===== Gestión de Pedidos =====");
            Console.WriteLine("1. Dar de alta un pedido");
            Console.WriteLine("2. Asignar cadete a pedido");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar cadete de pedido");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");


            switch (Console.ReadLine())
            {
                case "1":
                    DarDeAltaPedido(cadeteria, numeroPedido);
                    numeroPedido++;
                    break;
                case "2":
                    AsignarCadeteAPedido(cadeteria);
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
                Console.ReadKey();
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

        Cliente cliente = CrearClienteDesdeInterfaz();

        Console.Write("Ingrese observaciones del pedido (opcional): ");
        string? observaciones = Console.ReadLine();

        Pedido nuevoPedido = new Pedido(numeroPedido.ToString(), cliente, observaciones);
        cadeteria.AgregarPedido(nuevoPedido);
        Console.WriteLine($"Pedido creado con éxito. ID: {nuevoPedido.Nro}, Estado: {nuevoPedido.Estado}");
    }

    static void AsignarCadeteAPedido(Cadeteria cadeteria)
    {

        System.Console.WriteLine(cadeteria.InformacionDePedidos());
        Console.Write("Ingrese Nro del pedido: ");

        string? idPedido = Console.ReadLine();
        Pedido? pedidoBuscado = idPedido == null ? null : BuscarPedidoPorNro(cadeteria, idPedido);

        if (pedidoBuscado != null)
        {
            System.Console.WriteLine(cadeteria.InformacionDeCadetes());
            Console.Write("Ingrese ID del cadete: ");
            string? idCadete = Console.ReadLine();

            Cadete? cadeteAsignado = cadeteria.ListaCadetes.Find(cadete => cadete.Id == idCadete);
            if (cadeteAsignado != null)
            {
                cadeteria.AsignarCadeteAPedido(cadeteAsignado.Id, pedidoBuscado.Nro);
                Console.WriteLine($"Pedido asignado a {cadeteAsignado.Nombre}");
            }
            else
            {
                System.Console.WriteLine("No se encontro el cadete.");
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
        System.Console.WriteLine(cadeteria.InformacionDePedidos());
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
        var informe = "";

        foreach (var cadete in cadeteria.ListaCadetes)
        {
            decimal jornal = cadeteria.JornalACobrar(cadete.Id);
            informe += $"\nCadete: {cadete.Nombre}, Jornal a cobrar: {jornal:C}";
        }

        System.Console.WriteLine(informe);
    }


    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Reasignar Pedido ====");
        System.Console.WriteLine(cadeteria.InformacionDePedidos());

        Console.Write("Ingrese Nro del pedido: ");

        string? idPedido = Console.ReadLine();

        if (idPedido != null)
        {
            Pedido? pedidoBuscado = BuscarPedidoPorNro(cadeteria, idPedido);
            if (pedidoBuscado != null && pedidoBuscado.CadeteAsignado != null)
            {
                System.Console.WriteLine(cadeteria.InformacionDeCadetes());

                Console.Write("Ingrese ID del cadete: ");

                string? idCadete = Console.ReadLine();
                Cadete? cadeteAsignado = cadeteria.ListaCadetes.Find(cadete => cadete.Id == idCadete);

                if (cadeteAsignado != null)
                {
                    pedidoBuscado.AsignarCadete(cadeteAsignado);
                    Console.WriteLine($"Pedido asignado a {cadeteAsignado.Nombre}");
                }
                else
                {
                    System.Console.WriteLine("No se encontro el cadete.");
                }
            }
            else
            {
                System.Console.WriteLine("No se encontro el cadete.");
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
        return cadeteria.ListaPedidos
            .FirstOrDefault(pedido => pedido.Nro == nro)?.CadeteAsignado;
    }

    static Cliente CrearClienteDesdeInterfaz()
    {
        Console.WriteLine("==== Crear Nuevo Cliente ====");

        Console.Write("Ingrese el nombre del cliente: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese la dirección del cliente: ");
        string? direccion = Console.ReadLine();

        Console.Write("Ingrese el teléfono del cliente: ");
        string? telefono = Console.ReadLine();

        Console.Write("Ingrese datos de referencia de la dirección (opcional): ");
        string? datosReferenciaDireccion = Console.ReadLine();

        Cliente cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        return cliente;
    }
}
