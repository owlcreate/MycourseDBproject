using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.CousePrerequisites
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public IndexModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IList<CoursePrerequisite> CoursePrerequisite { get;set; }

        public async Task OnGetAsync()
        {
            CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite).ToListAsync();
        }
    }
}
