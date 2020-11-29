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
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DeleteModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                .Include(a => a.Instructor).FirstOrDefaultAsync(m => m.Id == id);

            if (AdvisingAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdvisingAssignment = await _context.AdvisingAssignments.FindAsync(id);

            if (AdvisingAssignment != null)
            {
                _context.AdvisingAssignments.Remove(AdvisingAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
