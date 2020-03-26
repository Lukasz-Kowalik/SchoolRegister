using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SchoolRegister.BAL.Entities
{
    public class Student :User
    {
        public double AverageGrade { get; }

        public IDictionary<string,double> AverageGraderPerSubject { get; }

        public IList<Grade> Grades { get; set; }

        public Group Group { get; set; }

        public Student()
        {
        }

        public Student(string firstName, string lastName, DateTime registrationDate, double averageGrade, IDictionary<string, double> averageGraderPerSubject, IList<Grade> grades, Group group) : base(firstName, lastName, registrationDate)
        {
            AverageGrade = averageGrade;
            AverageGraderPerSubject = averageGraderPerSubject;
            Grades = grades;
            Group = group;
        }
    }
}
