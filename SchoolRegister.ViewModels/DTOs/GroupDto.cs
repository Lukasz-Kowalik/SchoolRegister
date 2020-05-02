using System.Collections.Generic;

namespace SchoolRegister.ViewModels.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<StudentDto> Students { get; set; }
        public IList<SubjectGroupDto> SubjectGroups { get; set; }
    }
}