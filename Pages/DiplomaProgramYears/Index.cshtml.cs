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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_matchacode.Data.NsccCourseMapDbContext _context;

        public IndexModel(nscccoursemap_matchacode.Data.NsccCourseMapDbContext context)
        {
            _context = context;
        }

        public IList<DiplomaProgramYear> DiplomaProgramYear { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaProgramYear = 
            await _context.DiplomaProgramYears
                .Include(dpy => dpy.DiplomaProgram)
                .OrderBy(dpy => dpy.DiplomaProgram.Title)
                //.OrderBy(dpy => dpy.Title)
                    .ThenBy(dpy => dpy.Title)
                .ToListAsync();
        }
    }
}
