using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.Semesters
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DetailsModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _context.Semesters
                .Include(s => s.AcademicYear)
                .Include(s => s.CourseOfferings)
                    .ThenInclude(s => s.DiplomaProgramYearSection)
                        .ThenInclude(s => s.DiplomaProgramYear)
                            .ThenInclude(s => s.DiplomaProgram)
                .Include(s => s.CourseOfferings)
                    .ThenInclude(s => s.Course)
                .Include(s => s.CourseOfferings)
                    .ThenInclude(s => s.Instructor)                
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Semester == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
