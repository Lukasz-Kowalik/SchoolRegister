namespace SchoolRegister.ViewModels.DTOs
{
    public class EmailMessageDto
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
    }
}