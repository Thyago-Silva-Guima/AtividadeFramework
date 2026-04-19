using System.Collections.Generic;

namespace EFProject.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
