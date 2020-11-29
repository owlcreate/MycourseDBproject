using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_matchacode.Models
{
    public class Instructor
    {
        //[Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }


        //computed property

        public string FullName {
            get {
                return $"{LastName}, {FirstName}";
            }
        }
        //nav property

        public ICollection<CourseOffering> CourseOfferings { get; set; }

        public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; }
        
    }
}