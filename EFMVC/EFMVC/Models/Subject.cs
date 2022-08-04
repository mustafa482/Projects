using System.ComponentModel.DataAnnotations;

namespace EFMVC.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string SubjectTerm { get; set; }
        public int SubjectCredets { get; set; }

        public List<Teacher> SubjectTeahers { get; set; } = new List<Teacher>();
    }
}
