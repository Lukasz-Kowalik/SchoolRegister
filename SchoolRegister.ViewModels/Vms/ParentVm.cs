using System.Collections.Generic;

namespace SchoolRegister.ViewModels.Vms
{
    public class ParentVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<StudentVm> Students { get; set; }
    }
}