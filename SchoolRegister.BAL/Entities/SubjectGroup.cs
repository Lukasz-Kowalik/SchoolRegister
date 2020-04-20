﻿namespace SchoolRegister.BAL.Entities
{
    public class SubjectGroup
    {
        public virtual Group Group { get; set; }

        public int GroupId { get; set; }

        public virtual Subject Subject { get; set; }

        public int SubjectId { get; set; }
    }
}