using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class DiplomaProgramYear
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public int DiplomaProgramId { get; set; }
        
        [Required]
        [RegularExpression(@"^section\s\b[1-4]\b$")]
        public string Title { get; set; }
        
        
        //nav property
        public DiplomaProgram DiplomaProgram { get; set; }
        public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }


        
    }
}