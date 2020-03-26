namespace SchoolRegister.BAL.Entities
{
    public class Group
    {
        public Group()
        {
        }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}