using TP_01.models;
namespace TP_01.helpers;
class CsvCarga
{
    public static Cadeteria CargarCadeteriaDesdeCSV(string filePath, string separador)
    {
        string? line;
        Cadeteria cadeteria = new();

        using StreamReader srCadeteria = File.OpenText(filePath);
        while ((line = srCadeteria.ReadLine()) != null)
        {
            string[] datosCadeteria = line.Trim().Split(separador);
            cadeteria.Nombre = datosCadeteria[0];
            cadeteria.Telefono = datosCadeteria[1];
        }

        return cadeteria;
    }

    public static void CargarCadetesDesdeCSV(string filePath, string separador, Cadeteria cadeteria)
    {
        string? line;

        using StreamReader srCadete = File.OpenText(filePath);
        while ((line = srCadete.ReadLine()) != null)
        {
            string[] datosCadeteria = line.Trim().Split(separador);
            _ = uint.TryParse(datosCadeteria[0], out uint id);
            string nombre = datosCadeteria[1];
            string direccion = datosCadeteria[2];
            string telefono = datosCadeteria[3];

            Cadete nuevoCadete = new(id, nombre, direccion, telefono);
            cadeteria.AgregarCadete(nuevoCadete);
        }
    }
}