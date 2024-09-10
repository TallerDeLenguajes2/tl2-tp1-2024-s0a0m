using TP_01.models;
using System.Text.Json;

namespace TP_01.helpers
{
    public class AccesoJSON : AccesoADatos
    {
        public override Cadeteria CargarCadeteria(string filePath, string separador)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Cadeteria>(json) ?? new Cadeteria();
        }

        public override void CargarCadetes(string filePath, string separador, Cadeteria cadeteria)
        {
            string json = File.ReadAllText(filePath);
            List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(json) ?? new List<Cadete>();
            foreach (var cadete in cadetes)
            {
                cadeteria.AgregarCadete(cadete.Id, cadete.Nombre, cadete.Direccion, cadete.Telefono);
            }
        }
    }
}
