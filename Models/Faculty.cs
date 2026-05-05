using System.Collections.Generic;

namespace ptpmql.Models
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}