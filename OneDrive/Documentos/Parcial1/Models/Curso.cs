namespace Parcial1.Models;
public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Duracion { get; set; }
    public double Precio { get; set; }
    public virtual List<Estudiante>? Estudiantes { get; set;}

}