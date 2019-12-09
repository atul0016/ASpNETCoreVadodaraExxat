using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApps.Models
{
    public class Student
    {
        [Key]
        public int StudentRowId { get; set; }
        [Required(ErrorMessage ="Student Id is must")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is must")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Course Name is must")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "University Id is must")]
        public int UniversityRowId { get; set; } // foreign Key
        public University University { get; set; } // referential integrity
    }
}
