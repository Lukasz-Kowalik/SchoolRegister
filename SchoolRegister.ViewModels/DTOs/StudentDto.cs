using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.DTOs
{
    public class StudentDto
    {
        [Required]
        public int Id { get; set; }
        public IList<GradeDto> Grades { get; set; }
        public GroupDto Group { get; set; }
        public ParentDto Parent { get; set; }
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGraderPerSubject { get; set; }
        public IDictionary<string, List<GradeScaleDto>> GradesPerSubject { get; set; }
    }
}