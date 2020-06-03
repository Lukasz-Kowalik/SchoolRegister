using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.BAL.Entities
{
    public class Grade
    {
        [Key]
        [Display(Name = "Date Of Issue")]
        public DateTime DateOfIssue { get; set; }

        [Display(Name = "Grade Value")]
        public GradeScale GradeValue { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}