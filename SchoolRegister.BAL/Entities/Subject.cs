using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Subject
    {
        public string Description { get; set; }
        public IList<Group> Groups { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public Subject(string description, IList<Group> groups, int id, string name, Teacher teacher)
        {
            Description = description;
            Groups = groups;
            Id = id;
            Name = name;
            Teacher = teacher;
        }

        public Subject()
        {
        }
    }
}