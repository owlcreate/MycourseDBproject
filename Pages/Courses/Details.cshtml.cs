using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DetailsModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Add a section that lists the list of Pre-requisite 
            //courses and the list of courses for which the course is a prerequisite.
            Course = await _context
            .Courses
            .Include(c => c.Prerequisites)
                .ThenInclude(cpr => cpr.Prerequisite)
            .Include(c => c.IsPrerequisiteFor)
                .ThenInclude(cpr => cpr.Course)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
