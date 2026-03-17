using System.ComponentModel.DataAnnotations;

namespace ptpmql.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, ErrorMessage = "Mã SV tối đa 10 ký tự")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Họ tên tối đa 50 ký tự")]
        public string FullName { get; set; }
         public int Age { get; set; }
        public string Email { get; set; }
    }
}