using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.CouseOfferings
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public IndexModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; }

        public async Task OnGetAsync()
        {
            CourseOffering = await _context.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.DiplomaProgramYearSection)
                .ThenInclude(c => c.DiplomaProgramYear)
                .ThenInclude(c => c.DiplomaProgram)
                .Include(c => c.Instructor)
        
                .Include(c => c.Semester)
                .OrderByDescending(c => c.Semester)
                .ThenBy(c => c.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
                .ThenBy(c => c.DiplomaProgramYearSection.DiplomaProgramYear.Title)
                .ThenBy(c => c.Course.CourseCode)
                .ToListAsync();
        }
    }
}
