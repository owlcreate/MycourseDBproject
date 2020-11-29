using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.DiplomaPrograms
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public EditModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DiplomaProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaProgramExists(DiplomaProgram.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiplomaProgramExists(int id)
        {
            return _context.DiplomaPrograms.Any(e => e.Id == id);
        }
    }
}
