using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        void SendEmail(StudentDto student);
        void SendEmail(ParentDto parent);
    }
}