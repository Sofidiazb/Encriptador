using Parcial1.Models;

namespace Parcial1.Services;

public interface ICursoServices
{
    void Create(Curso obj);
    List<Curso> GetAll(string filter);
    List<Curso> GetAll();
    void Update(Curso obj);
    void Delete(int id);
    Curso? GetById(int id);

}