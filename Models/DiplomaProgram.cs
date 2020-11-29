using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class DiplomaProgram
    {
        //[Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(10)]
        public string Title { get; set; }

        
        //nav property
         public ICollection<DiplomaProgramYear> DiplomaProgramYears { get; set; }

        
        
    }
}