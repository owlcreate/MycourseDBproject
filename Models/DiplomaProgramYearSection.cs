using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class DiplomaProgramYearSection
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^section\s\b[1-9]\b$")]
        public string Title { get; set; }

        [Required]
        public int AcademicYearId { get; set; }

        [Required]
        public int DiplomaProgramYearId { get; set; }
        
        //nav property
        public DiplomaProgramYear DiplomaProgramYear { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public ICollection<CourseOffering> CourseOfferings { get; set; }
        public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; }




        
        
    }
}