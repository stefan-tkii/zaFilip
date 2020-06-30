using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ispit_zadaca1.Models;
using ispit_zadaca1.ViewModels;

namespace ispit_zadaca1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCFacultyContext _context;

        public StudentsController(MVCFacultyContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }

        public async Task<IActionResult> Enroll_list(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            IQueryable<Student> all = _context.students.AsQueryable();
            Student toAdd = await all.Where(s => s.Id == id).FirstOrDefaultAsync();
            IQueryable<Labvezba> site = _context.vezbi.AsQueryable();
            ICollection<Labvezba> vezbitoAdd = await site.ToListAsync();
            EnrollViewModel modelce = new EnrollViewModel(toAdd, vezbitoAdd);
            return View(modelce);
        }

        public async Task<IActionResult> Enroll(int? studentId, int? labId)
        {
            if((studentId == null) || (labId == null))
            {
                return NotFound();
            }

            Student toInsert = await _context.students.AsQueryable().Where(s => s.Id == studentId).FirstOrDefaultAsync();
            Labvezba toPut = await _context.vezbi.AsQueryable().Where(s => s.Id == labId).FirstOrDefaultAsync();
            Studentlab nov_lab = new Studentlab { studentId = (int)studentId, student = toInsert, labvezbaId = (int)labId, vezba = toPut };
            _context.Add(nov_lab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> View_enrollments(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Student toInsert = await _context.students.AsQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();
            IQueryable<Studentlab> labs = _context.studentlabs.AsQueryable().Include(s=> s.student).Include(s=> s.vezba);
            ICollection<Studentlab> labicki = await labs.Where(s => s.studentId == id).ToListAsync();
            StudentskiVezbiViewModel modelce = new StudentskiVezbiViewModel(toInsert, labicki);
            return View(modelce);
            //planirav da gi prikazam site enrollments i potoa da imav check box i kopce pred sekoja junction tabela i koga ke kliknevme ke se pustese metod koj
            //ke go izbrisese soodvetniot zapis na junction tabelata slicno kako sto napravi i za vnes na zapis vo istata, no malku vreme imav
            // a dot net e izmisleno za golemi proekti ne za kratki aplikacii kako android
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fullName,indeks,signature")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fullName,indeks,signature")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.students.FindAsync(id);
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }
    }
}
