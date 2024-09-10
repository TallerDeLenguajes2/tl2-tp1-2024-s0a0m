using TP_01.models;

namespace TP_01.helpers
{
    public class AccesoCSV : AccesoADatos
    {
        public override Cadeteria CargarCadeteria(string filePath, string separador)
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

        public override void CargarCadetes(string filePath, string separador, Cadeteria cadeteria)
        {
            string? line;

            using StreamReader srCadete = File.OpenText(filePath);
            while ((line = srCadete.ReadLine()) != null)
            {
                string[] datosCadete = line.Trim().Split(separador);
                string id = datosCadete[0];
                string nombre = datosCadete[1];
                string direccion = datosCadete[2];
                string telefono = datosCadete[3];
                cadeteria.AgregarCadete(id, nombre, direccion, telefono);
            }
        }
    }
}
