using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.AdvisingAssignments
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public IndexModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; }

        public async Task OnGetAsync()
        {
            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                    .ThenInclude(a => a.DiplomaProgramYear)
                    .ThenInclude(a => a.DiplomaProgram)
                .Include(a => a.Instructor)
                .ToListAsync();
        }
    }
}
