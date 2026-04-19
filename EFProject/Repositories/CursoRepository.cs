using System.Collections.Generic;
using System.Linq;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
    // Atividade 3
    public class CursoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Curso c)
        {
            _context.Cursos.Add(c);
            _context.SaveChanges();
        }

        public List<Curso> Listar()
        {
            return _context.Cursos.ToList();
        }

        public List<Curso> FiltrarPorCargaHoraria(int cargaMinima)
        {
            return _context.Cursos
                .Where(c => c.CargaHoraria >= cargaMinima)
                .ToList();
        }

        public List<Curso> ListarOrdenadoPorNome()
        {
            return _context.Cursos
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public void Remover(int id)
        {
            var curso = _context.Cursos.Find(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
            }
        }
    }
}
