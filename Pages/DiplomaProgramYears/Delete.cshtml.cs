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
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DeleteModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaProgramYear DiplomaProgramYear { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYear = await _context.DiplomaProgramYears
                .Include(d => d.DiplomaProgram).FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgramYear == null)
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

            DiplomaProgramYear = await _context.DiplomaProgramYears.FindAsync(id);

            if (DiplomaProgramYear != null)
            {
                _context.DiplomaProgramYears.Remove(DiplomaProgramYear);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
