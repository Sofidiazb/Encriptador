using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Models;
using Parcial1.ViewModels;
using Parcial1.Services;

namespace Parcial1.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoServices _cursoServices;

        public CursoController(ICursoServices cursoService)
        {
            _cursoServices = cursoService;
        }


    public IActionResult Index(string nameFilter)
        {
            var model = new CursoViewModel();
            model.Cursos = _cursoServices.GetAll(nameFilter);
            return View(model);
        }

        // GET: Curso/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoServices.GetById(id.Value);
            if (curso == null)
            {
                return NotFound();
            }

            var viewModel = new CursoViewModel();
            viewModel.Nombre = curso.Nombre;
            viewModel.Duracion = curso.Duracion;
            viewModel.Precio = curso.Precio;

            return View(viewModel);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Categoria,Duracion,Precio")] Curso curso)
        {
        
            if (ModelState.IsValid)
            {
                _cursoServices.Create(curso);
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoServices.GetById(id.Value);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Categoria,Duracion,Precio")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cursoServices.Update(curso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Curso/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoServices.GetById(id.Value);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cursoServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
          return _cursoServices.GetById(id) != null;
        }
    }
}