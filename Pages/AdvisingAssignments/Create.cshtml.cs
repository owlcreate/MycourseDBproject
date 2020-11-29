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
namespace nscccoursemap_matchacode.Pages.AdvisingAssignments
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
        List<SectionDropdownItem> dropdownItems
                = new List<SectionDropdownItem>(); 
            // get all sections from the db
            List<DiplomaProgramYearSection> dpysList = 
                    _context
                    .DiplomaProgramYearSections
                    .Include(dpys => dpys.AcademicYear )
                    .Include(dpys => dpys.DiplomaProgramYear)
                    .ThenInclude(dpy => dpy.DiplomaProgram)
                    .OrderByDescending(dpys => dpys.AcademicYear.Title)
                    .ThenBy(dpys => dpys.DiplomaProgramYear.DiplomaProgram.Title)
                    .ThenBy(dpys => dpys.DiplomaProgramYear.Title)
                    .ThenBy(dpys => dpys.Title)
                    .ToList();
            // fill empty list with newily aquired data
            foreach (var section in dpysList)
            {
                // create a new dropdown item
                // add it to dropdown list 
                dropdownItems.Add(new SectionDropdownItem{
                    Id = section.Id,
                    DisplayName = $"{section.AcademicYear.Title} - {section.DiplomaProgramYear.DiplomaProgram.Title} - {section.DiplomaProgramYear.Title} - {section.Title}"
                });
            }
            ViewData["DiplomaProgramYearSectionId"] = new SelectList(dropdownItems, "Id", "DisplayName");
            ViewData["InstructorId"] 
                    = new SelectList(_context.Instructors
                        , "Id"  
                        , "FullName");
                return Page();
            }
            class SectionDropdownItem {
                public int Id {get; set;}
                public string DisplayName {get; set;}
            }
        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.AdvisingAssignments.Add(AdvisingAssignment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
