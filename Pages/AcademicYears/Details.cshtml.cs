using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.AcademicYears
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DetailsModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public AcademicYear AcademicYear { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           AcademicYear = await _context.AcademicYears
            .Include(ay => ay.Semesters)
            .Include(ay => ay.DiplomaProgramYearSections)
                .ThenInclude(ay => ay.AdvisingAssignments)
                    .ThenInclude(ay => ay.Instructor)
            .Include(ay => ay.DiplomaProgramYearSections)
                .ThenInclude(ay => ay.DiplomaProgramYear)
                    .ThenInclude(ay => ay.DiplomaProgram)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (AcademicYear == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
