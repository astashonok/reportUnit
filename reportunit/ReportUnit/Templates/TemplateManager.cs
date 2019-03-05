using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReportUnit.Templates
{
    public class TemplateManager
    {
        public static string GetSummaryTemplate()
        {
            return GetEncodedResource(new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Directory.FullName + "/Summary.cshtml");
        }

        public static string GetFileTemplate()
        {
            
            return GetEncodedResource(new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Directory.FullName + "/File.cshtml");
        }

        private static string GetEncodedResource(string path)
        {
            return Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(path));
        }
    }
}
