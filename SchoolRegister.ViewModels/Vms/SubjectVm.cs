using System.Collections.Generic;

namespace SchoolRegister.ViewModels.Vms
{
    public class SubjectVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<GroupVm> Groups { get; set; }
        public IList<SubjectGroupVm> SubjectGroups { get; set; }
        public string TeacherName { get; set; }
    }
}