﻿namespace Domein.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
