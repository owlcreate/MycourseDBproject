using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class CourseOffering
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }
        
        [Required]
        public int InstructorId { get; set; }

        [Required]
        public int DiplomaProgramYearSectionId { get; set; }

        [Required]
        public int SemesterId { get; set; }

        [Required]
        public Boolean IsDirectedElective { get; set; }

        
        //nav property

        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }

        public Semester Semester { get; set; }

        public Course Course{ get; set; }

        public Instructor Instructor { get; set; }





        
    }
}