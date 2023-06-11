using Parcial1.Models;

namespace Parcial1.Services;

public interface IEstudianteServices
{
    void Create (Estudiante obj);
    List<Estudiante?> GetAll();
    void Update (Estudiante obj);
    void Delete (Estudiante obj);
    Estudiante? GetById(int id);
}