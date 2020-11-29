using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.DiplomaPrograms
{
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public DeleteModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaProgram DiplomaProgram { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgram = await _context.DiplomaPrograms.FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgram == null)
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

            DiplomaProgram = await _context.DiplomaPrograms.FindAsync(id);

            if (DiplomaProgram != null)
            {
                _context.DiplomaPrograms.Remove(DiplomaProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
