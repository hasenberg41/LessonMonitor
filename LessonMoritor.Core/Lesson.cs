﻿using System;

namespace LessonMonitor.Core
{
    public class Lesson
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string YouTubeBroadcastId { get; set; }
    }
}