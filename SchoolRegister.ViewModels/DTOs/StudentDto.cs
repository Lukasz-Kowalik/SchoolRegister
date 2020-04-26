using System.Collections.Generic;

namespace SchoolRegister.ViewModels.DTOs
{
    public class StudentDto
    {
        public IList<GradeDto> Grades { get; set; }

        public GroupDto Group { get; set; }
        public ParentDto Parent { get; set; }
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGraderPerSubject { get; set; }
        public IDictionary<string, List<GradeScaleDto>> GradesPerSubject { get; set; }
    }
}