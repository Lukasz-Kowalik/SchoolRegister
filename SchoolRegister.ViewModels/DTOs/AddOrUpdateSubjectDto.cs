namespace SchoolRegister.ViewModels.DTOs
{
    public class AddOrUpdateSubjectDto
    {
        public string Description { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }

        public int TeacherId { get; set; }
    }
}