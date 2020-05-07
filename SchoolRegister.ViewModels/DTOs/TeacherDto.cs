using System.Collections.Generic;

namespace SchoolRegister.ViewModels.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  IList<AddOrUpdateSubjectDto> Subjects { get; set; }
        public string Title { get; set; }
    }
}