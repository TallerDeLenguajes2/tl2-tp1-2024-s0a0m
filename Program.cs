using TP_01.models;
using TP_01.helpers;

class GestionPedidos
{
    static void Main()
    {
        Cadeteria cadeteria = InicializarCadeteria();
    }

    static Cadeteria InicializarCadeteria()
    {

        Console.WriteLine("Seleccione el tipo de acceso a datos (CSV/JSON):");
        string? tipoAcceso = Console.ReadLine()?.ToUpper();

        AccesoADatos accesoADatos;
        string cadeteFilePath;
        string cadeteriaFilePath;

        if (tipoAcceso == "CSV")
        {
            accesoADatos = new AccesoCSV();
            cadeteFilePath = "./DB/cadete.csv";
            cadeteriaFilePath = "./DB/cadeteria.csv";
        }
        else if (tipoAcceso == "JSON")
        {
            accesoADatos = new AccesoJSON();
            cadeteFilePath = "./DB/cadete.json";
            cadeteriaFilePath = "./DB/cadeteria.json";

        }
        else
        {
            Console.WriteLine("Tipo de acceso no válido. Usando CSV por defecto.");
            accesoADatos = new AccesoCSV();
            cadeteFilePath = "./DB/cadete.csv";
            cadeteriaFilePath = "./DB/cadeteria.csv";
        }

        string separadorCsv = ";";

        Cadeteria cadeteria = accesoADatos.CargarCadeteria(cadeteriaFilePath, separadorCsv);
        accesoADatos.CargarCadetes(cadeteFilePath, separadorCsv, cadeteria);

        return cadeteria;
    }
}