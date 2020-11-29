using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class CoursePrerequisite
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int PrerequisiteId { get; set; }

        //nav property

        public Course Course { get; set; }
        public Course Prerequisite { get; set; }

        
        

        
        
    }
}