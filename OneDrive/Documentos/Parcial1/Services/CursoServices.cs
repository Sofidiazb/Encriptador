using Parcial1.Data;
using Parcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class CursoServices : ICursoServices
{
     private readonly CursoContext _context;

    public CursoServices(CursoContext context)
    {
        _context = context;
    }
    public void Create(Curso obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
    public List<Curso> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }
    public List<Curso> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(filter.ToLower())
                || x.Duracion.ToLower().Contains(filter.ToLower()) 
                || x.Precio.ToString().Contains(filter));
        }

        return query.ToList();
    }

    public Curso? GetById(int id)
    {
        var menu = GetQuery()
                .Include(x=> x.Estudiantes)
                .FirstOrDefault(m => m.Id == id);

        return menu;
    }

    public void Update(Curso obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
    private IQueryable<Curso> GetQuery()
    {
        return from curso in _context.Curso select curso;
    }
}