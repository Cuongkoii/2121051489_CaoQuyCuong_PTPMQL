using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using ptpmql.Data;
using ptpmql.Models;

namespace ptpmql.Controllers
{
    public class DocDuLieuController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DocDuLieuController(ApplicationDBContext context)
        {
            _context = context;
        }

        // 🔹 HIỂN THỊ GIAO DIỆN UPLOAD
        public IActionResult Upload()
        {
            return View();
        }

        // 🔹 ĐỌC FILE EXCEL + LƯU DATABASE
        [HttpPost]
        public IActionResult ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Vui lòng chọn file!";
                return View("Upload");
            }

            int count = 0;

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var workbook = new XLWorkbook(stream))
                {
                    var sheet = workbook.Worksheet(1);
                    var rowCount = sheet.LastRowUsed().RowNumber();

                    for (int i = 2; i <= rowCount; i++)
                    {
                        try
                        {
                            string code = sheet.Cell(i, 1).Value.ToString();
                            string name = sheet.Cell(i, 2).Value.ToString();
                            string ageStr = sheet.Cell(i, 3).Value.ToString();
                            string email = sheet.Cell(i, 4).Value.ToString();
                            string facultyStr = sheet.Cell(i, 5).Value.ToString();

                            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
                                continue;

                            int.TryParse(ageStr, out int age);
                            int.TryParse(facultyStr, out int facultyId);

                            var student = new Student
                            {
                                StudentCode = code,
                                FullName = name,
                                Age = age,
                                Email = email,
                                FacultyID = facultyId
                            };

                            _context.Students.Add(student);
                            count++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    try
                    {
                        _context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = $"Mã sinh viên đã tồn tại!";
                        return View("Upload");
                    }

                    
                }
            }

            ViewBag.Message = $"Import thành công {count} sinh viên!";
            return View("Upload");
        }
    }
}