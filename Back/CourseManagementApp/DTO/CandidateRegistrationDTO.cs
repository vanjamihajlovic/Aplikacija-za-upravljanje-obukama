﻿using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTO
{
    public class CandidateRegistrationDTO
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Surname is required")]
        public string? Surname { get; set; }
    }
}
