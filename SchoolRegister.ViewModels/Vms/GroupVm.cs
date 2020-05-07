using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.Vms
{
    public class GroupVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<StudentVm> Students { get; set; }
        public virtual IList<SubjectGroupVm> SubjectGroups { get; set; }
    }
}