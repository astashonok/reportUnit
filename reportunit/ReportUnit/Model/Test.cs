using System.Collections.Generic;

namespace ReportUnit.Model
{
    public class Test
    {
        /// <summary>
        ///     Categories & features associated with the test
        /// </summary>
        public List<string> CategoryList;

        public List<string> KnownIssues;
        public List<string> PossibleIssues;

        public Test()
        {
            CategoryList = new List<string>();
            KnownIssues = new List<string>();
            PossibleIssues = new List<string>();
            Status = Status.Unknown;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        ///     Status of the test run (eg Passed, Failed)
        /// </summary>
        public Status Status { get; set; }

        public string FailureMessage { get; set; }

        /// <summary>
        ///     Error or other status messages
        /// </summary>
        public string StatusMessage { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        /// <summary>
        ///     How long the test took to run (in milliseconds)
        /// </summary>
        public double Duration { get; set; }

        public string ScreenShotAttachment { get; set; }

        public string DebugAttachment { get; set; }

        public string InfoAttachment { get; set; }
        public string Output { get; set; }

        public string GetCategories()
        {
            if (CategoryList.Count == 0)
            {
                return "";
            }

            return string.Join(" ", CategoryList);
        }
    }
}
