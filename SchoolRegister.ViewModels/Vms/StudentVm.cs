using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.Vms
{
    public class StudentVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int? GroupId { get; set; }
        public int? ParentId { get; set; }

        [Required]
        public string UserName { get; set; }

        public IList<GradeVm> Grades { get; set; }
        //public GroupVm Group { get; set; }
        //public ParentVm Parent { get; set; }

        public IDictionary<string, double> AverageGraderPerSubject;

        public IDictionary<string, List<GradeScaleVm>> GradesPerSubject;
    }
}