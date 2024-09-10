using TP_01.models;

namespace TP_01.helpers;

public abstract class AccesoADatos
{
    public abstract Cadeteria CargarCadeteria(string filePath, string separador);
    public abstract void CargarCadetes(string filePath, string separador, Cadeteria cadeteria);
}