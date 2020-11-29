using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class Course
    {
        //[Key]
        public int Id { get; set; }
       

        [Required]
        [RegularExpression("[A-Z]{4}[]{1}[0-9]{4}", ErrorMessage = "Please enter four uppercase letters, one space, four digits")]
        public string CourseCode { get; set; }
        
        

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }


    
        
        //nav property
        public ICollection<CoursePrerequisite> Prerequisites { get; set; }
        public ICollection<CoursePrerequisite> IsPrerequisiteFor { get; set; }
        public ICollection<CourseOffering> CourseOfferings{ get; set; }

        
    }
}