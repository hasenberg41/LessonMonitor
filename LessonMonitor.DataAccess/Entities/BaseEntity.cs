using System;

namespace LessonMonitor.DataAccess.Entityes
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
