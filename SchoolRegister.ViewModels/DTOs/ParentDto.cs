using System.Collections.Generic;

namespace SchoolRegister.ViewModels.DTOs
{
    public class ParentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  IList<StudentDto> Students { get; set; }
    }
}