using System.Collections.Generic;

namespace SchoolRegister.ViewModels.Vms
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GroupId { get; set; }

        public int? ParentId { get; set; }

        public double AverageGrade;
        public IList<GradeVm> Grades { get; set; }
        public GroupVm Group { get; set; }
        public ParentVm Parent { get; set; }

        public IDictionary<string, double> AverageGraderPerSubject;

        public IDictionary<string, List<GradeScaleVm>> GradesPerSubject;
    }
}