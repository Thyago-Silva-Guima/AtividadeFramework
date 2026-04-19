using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
    // Atividade 5 
    public class ProfessorRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        public List<Professor> ListarComCursos()
        {
            return _context.Professores
                .Include(p => p.Cursos)
                .ToList();
        }

        public Professor BuscarPorId(int id)
        {
            return _context.Professores
                .Include(p => p.Cursos)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Remover(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                _context.SaveChanges();
            }
        }
    }
}
