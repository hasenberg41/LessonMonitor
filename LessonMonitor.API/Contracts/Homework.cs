﻿using System;

namespace LessonMonitor.API.Contracts
{
    public class Homework
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
    }

    public class NewHomework
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
    }
}
