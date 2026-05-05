using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ptpmql.Data;
using ptpmql.Models;
using ptpmql.ViewModels;
using ClosedXML.Excel;

namespace ptpmql.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StudentController(ApplicationDBContext context)
        {
            _context = context;
        }

        // 🔹 INDEX (HIỂN THỊ SV + KHOA)
        public IActionResult Index()
        {
            var data = _context.Students
                .Include(s => s.Faculty)
                .Select(s => new StudentFacultyVM
                {
                
                    StudentCode = s.StudentCode,
                    FullName = s.FullName,
                    FacultyName = s.Faculty.FacultyName
                })
                .ToList();

            return View(data);
        }

        // 🔹 CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(_context.Faculties, "FacultyID", "FacultyName");
            return View();
        }

        // 🔹 CREATE (POST)
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(_context.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            return View(student);
        }

        // 🔹 EDIT (GET)
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            ViewBag.FacultyID = new SelectList(_context.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            return View(student);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(_context.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            return View(student);
        }

        // 🔹 DELETE
        public IActionResult Delete(string id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
    
}