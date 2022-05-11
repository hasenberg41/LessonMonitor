using System;

namespace LessonMonitor.Core
{
    public class HomeWork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public Objective[] Objectives { get; set; }
        public int MemberId { get; set; }
    }
}
