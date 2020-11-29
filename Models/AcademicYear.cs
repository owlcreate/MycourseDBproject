using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class AcademicYear
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)] 
        public string Title { get; set; }

        //nav property
        //collections
        public ICollection<Semester> Semesters { get; set; }
        public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }

        
        
    }
}