using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class Semester
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public int AcademicYearId { get; set; }


        
        //nav property
        public AcademicYear AcademicYear{ get; set; }
         public ICollection<CourseOffering> CourseOfferings{ get; set; }
        
        
    }
}