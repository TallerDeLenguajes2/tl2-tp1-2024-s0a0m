using TP_01.models;

class Ejemplo {
    static void Main()
    {
        string cadeteFilePath = "./DB/cadete.csv";
        string cadeteriaFilePath = "./DB/cadete.csv";
        string separadorCsv = ";";

        Cadeteria nuevaCadeteria = new();

        string? line;

        using StreamReader srCadeteria = File.OpenText(cadeteriaFilePath);
        while ((line = srCadeteria.ReadLine()) != null)
        {
            string[] datosCadeteria = line.Trim().Split(separadorCsv);
            string nombre = datosCadeteria[0];
            string telefono = datosCadeteria[1];
            nuevaCadeteria.Nombre = nombre;
            nuevaCadeteria.Telefono = telefono;
        }

        using StreamReader srCadete = File.OpenText(cadeteFilePath);
        while ((line = srCadete.ReadLine()) != null)
        {
            string[] datosCadeteria = line.Trim().Split(separadorCsv);
            _ = uint.TryParse(datosCadeteria[0], out uint id);
            string nombre = datosCadeteria[1];
            string direccion = datosCadeteria[2];
            string telefono = datosCadeteria[3];
            Cadete nuevoCadete = new Cadete(id,nombre,direccion,telefono);
            nuevaCadeteria.AgregarCadete(nuevoCadete);
        }
    }
}