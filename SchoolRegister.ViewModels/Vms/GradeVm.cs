using System;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.ViewModels.Vms
{
    public class GradeVm
    {
        public DateTime DateOfIssue { get; set; }
        public GradeScaleVm GradeValue { get; set; }
        public SubjectVm Subject { get; set; }
        public StudentVm Student { get; set; }
    }
}