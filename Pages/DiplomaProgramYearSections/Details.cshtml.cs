using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.DiplomaProgramYearSections
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DetailsModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYearSection = await _context.DiplomaProgramYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaProgramYear).FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgramYearSection == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
