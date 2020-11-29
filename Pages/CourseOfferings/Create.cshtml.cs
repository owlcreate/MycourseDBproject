using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_matchacode.Data;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Pages.CouseOfferings
{
    public class CreateModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public CreateModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
        ViewData["DiplomaProgramYearSectionId"] = new SelectList(_context.DiplomaProgramYearSections, "Id", "Id");
        ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "LastName");
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CourseOfferings.Add(CourseOffering);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
