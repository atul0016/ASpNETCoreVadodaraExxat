using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApps.Models
{
    public class University
    {
        [Key] // primary identity key
        public int UniversityRowId { get; set; }
        [Required(ErrorMessage ="University Id is required")]
        public string UniversityId { get; set; }
        [Required(ErrorMessage = "University Name is required")]
        public string UniversityName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        // one-to-many relationship
        public ICollection<Student> Students { get; set; }

    }
}
