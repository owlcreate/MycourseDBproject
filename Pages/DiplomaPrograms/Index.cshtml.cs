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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public IndexModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IList<DiplomaProgram> DiplomaProgram { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaProgram = await _context.DiplomaPrograms
            .Include( d=> d.DiplomaProgramYears)
            .OrderBy(d => d.Title)
            .ToListAsync();
        }
    }
}
