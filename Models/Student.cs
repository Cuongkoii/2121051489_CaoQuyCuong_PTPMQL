using System.ComponentModel.DataAnnotations;

namespace ptpmql.Models
{
    public class Student
    {


        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, ErrorMessage = "Mã SV tối đa 10 ký tự")]
        [Key]
        public string StudentCode { get; set; } =default!;

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Họ tên tối đa 50 ký tự")]
        public string FullName { get; set; } = default!;
        public int Age { get; set; }
        public string? Email { get; set; }
        public int FacultyID { get; set; }   // khóa ngoại
        public Faculty? Faculty { get; set; } // navigation
    }
}