using System;
using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Grade
    {
        public DateTime DateOfIssue { get; set; }

        public GradeScale GradeValue{ get; set; }

        public Subject Subject{ get; set; }

        public Grade(DateTime dateOfIssue, GradeScale gradeValue, Subject subject)
        {
            GradeValue = gradeValue;
            DateOfIssue = dateOfIssue;
            Subject = subject;
        }

        public Grade()
        {
        }
    }
}