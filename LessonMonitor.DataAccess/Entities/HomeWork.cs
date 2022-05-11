using System;

namespace LessonMonitor.DataAccess.Entityes
{
    public class HomeWork : BaseEntity
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public Objective[] Objectives { get; set; }
    }
}
