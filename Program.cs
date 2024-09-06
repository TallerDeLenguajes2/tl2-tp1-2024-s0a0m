using TP_01.models;
using TP_01.helpers;

class GestionPedidos
{
    static void Main()
    {
        int numeroPedido = 1;
        bool salir = false;
        Cadeteria cadeteria = InicializarCadeteria();  // Función para cargar cadetería y cadetes

        while (!salir)
        {
            Console.Clear();
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
                    DarDeAltaPedido(cadeteria);
                    numeroPedido++;
                    break;
                case "2":
                    AsignarPedidoACadete(cadeteria);
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

    static void DarDeAltaPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Alta de Pedido ====");
        Console.Write("Ingrese la descripción del pedido: ");
        string descripcion = Console.ReadLine();
        Console.Write("Ingrese la dirección de entrega: ");
        string direccion = Console.ReadLine();

        // Crear un nuevo pedido
        Pedido nuevoPedido = new Pedido(descripcion, direccion);
        cadeteria.AgregarPedido(nuevoPedido);

        Console.WriteLine($"Pedido creado con éxito. ID: {nuevoPedido.Id}");
    }

    static void AsignarPedidoACadete(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Asignar Pedido a Cadete ====");
        // Mostrar lista de pedidos y cadetes, solicitar IDs, y realizar la asignación
        // Implementar lógica para asignar pedido a cadete.
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Cambiar Estado de Pedido ====");
        // Mostrar lista de pedidos, solicitar ID, y cambiar el estado del pedido.
        // Implementar lógica para cambiar el estado del pedido.
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==== Reasignar Pedido ====");
        // Mostrar lista de pedidos y cadetes, solicitar IDs, y reasignar el pedido.
        // Implementar lógica para reasignar el pedido.
    }
}
