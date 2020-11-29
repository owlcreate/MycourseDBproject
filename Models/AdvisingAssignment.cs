using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class AdvisingAssignment
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public int InstructorId { get; set; }
        
        [Required]
        public int DiplomaProgramYearSectionId { get; set; }
       
        
        //nav property

        public Instructor Instructor { get; set; }
        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }

        
        
    }
}