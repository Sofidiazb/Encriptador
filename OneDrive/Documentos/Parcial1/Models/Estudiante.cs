using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class Estudiante
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string NombreAlumno { get; set; }

    [Display(Name = "Apellido")]
    public string ApellidoAlumno { get; set; }
    public int Dni { get; set; }

    [Display(Name = "Curso Elegido")]
    public string? CursoElegido { get; set; }
    public virtual List<Curso>? Cursos { get; set; }

}