using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class GitHubAccount
    {
        public int MemberId { get; set; }
        public string NickName { get; set; }
        public Uri Link { get; set; }

        public Member Member { get; set; }
    }
}
