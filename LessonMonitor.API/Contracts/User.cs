using System;

namespace LessonMonitor.API.Contracts
{
    [Description("Test")]
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(12, 54)]
        public int Age { get; set; }

        [Description("Test method")]
        public void Test([Description("First parameter")] string value)
        {

        }
    }

    public class RangeAttribute : Attribute
    {
        public RangeAttribute(int minVAlue, int maxValue)
        {
            MinValue = minVAlue;
            MaxValue = maxValue;
        }
        public int MinValue { get; }
        public int MaxValue { get; }
    }

    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; }
    }

    public class RequiredAttribute : Attribute
    {
        
    }
}
