using Parcial1.Models;

namespace Parcial1.ViewModels;

public class CursoViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Duracion { get; set; }
    public double Precio { get; set; }
    public List<Curso> Cursos { get; set; } = new List<Curso>();
    public string? NameFilter { get; set; }
}