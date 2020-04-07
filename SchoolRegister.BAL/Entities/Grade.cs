using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.BAL.Entities
{
    public class Grade
    {
        [Key]
        public DateTime DateOfIssue { get; set; }

        public GradeScale GradeValue { get; set; }

        public Subject Subject { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}