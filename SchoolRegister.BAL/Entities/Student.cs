using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SchoolRegister.BAL.Entities
{
    public class Student : User
    {
        public IList<Grade> Grades { get; set; }

        public Group Group { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public Parent Parent { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        [NotMapped]
        public double AverageGrade => Math.Round(Grades.Average(grade => (int)grade.GradeValue), 1);

        [NotMapped]
        public IDictionary<string, double> AverageGraderPerSubject => Grades
            .GroupBy(g => g.Subject.Name)
            .Select(g => new
            {
                SubjectName = g.Key,
                AvgGrade = Math.Round(
                    g.Average(avg => (int)avg.GradeValue)
                    , 1)
            })
            .ToDictionary(avg => avg.SubjectName, avg => avg.AvgGrade);
    }
}