using System;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string YoutubeUserId { get; set; }

        public GitHubAccount GitHubAccount { get; set; }
    }
}
