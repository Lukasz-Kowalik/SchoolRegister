using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.DTOs
{
    public class GradeDto
    {
        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public GradeScaleDto GradeValue { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
   
    }
}