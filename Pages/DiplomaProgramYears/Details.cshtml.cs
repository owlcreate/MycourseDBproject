using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.DiplomaProgramYears
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DetailsModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public DiplomaProgramYear DiplomaProgramYear { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYear = await _context.DiplomaProgramYears
                .Include(s => s.DiplomaProgram)
                .Include(s => s.DiplomaProgramYearSections)
                    .ThenInclude(s => s.CourseOfferings)
                        .ThenInclude(s => s.Instructor)
                .Include(s => s.DiplomaProgramYearSections)
                    .ThenInclude(s => s.CourseOfferings)
                    .ThenInclude(s => s.Semester)
                .Include(s => s.DiplomaProgramYearSections)
                    .ThenInclude(s => s.CourseOfferings) 
                    .ThenInclude(s => s.Course)   
                    .Include(s => s.DiplomaProgramYearSections) 
                    .ThenInclude(s => s.CourseOfferings)   
                    .ThenInclude(s => s.DiplomaProgramYearSection)  
                    .ThenInclude(s => s.DiplomaProgramYear) 
                    .ThenInclude(s => s.DiplomaProgram)         
                .FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgramYear == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
