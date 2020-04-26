using System;

namespace SchoolRegister.ViewModels.DTOs
{
    public class GradeDto
    {
        public DateTime DateOfIssue { get; set; }
        public GradeScaleDto GradeValue { get; set; }
        public AddOrUpdateSubjectDto Subject { get; set; }
        public StudentDto Student { get; set; }
    }
}