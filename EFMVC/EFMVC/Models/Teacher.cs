using System.ComponentModel.DataAnnotations;

namespace EFMVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAdress { get; set; }
        public int TeacherAge { get; set; }

        public Subject Subject { get; set; }


    }
}
