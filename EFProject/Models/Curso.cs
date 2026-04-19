namespace EFProject.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
