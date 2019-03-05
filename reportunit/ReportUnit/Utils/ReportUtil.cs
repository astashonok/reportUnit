using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ReportUnit.Model;

namespace ReportUnit.Utils
{
    public class ReportUtil
    {
        // fixture level status codes
        public static Status GetFixtureStatus(IEnumerable<Test> tests)
        {
            return GetFixtureStatus(tests.Select(t => t.Status).ToList());
        }

        // fixture level status codes
        public static Status GetFixtureStatus(List<Status> statuses)
        {
            if (statuses.Any(x => x == Status.Failed))
            {
                return Status.Failed;
            }

            if (statuses.Any(x => x == Status.Error))
            {
                return Status.Error;
            }

            if (statuses.Any(x => x == Status.Inconclusive))
            {
                return Status.Inconclusive;
            }

            if (statuses.Any(x => x == Status.Passed))
            {
                return Status.Passed;
            }

            if (statuses.Any(x => x == Status.Skipped))
            {
                return Status.Skipped;
            }

            return Status.Skipped;
            //return Status.Unknown;
        }

        public static string GetStatus(string bugId)
        {
            var status = "";
            var client = new HttpClient();

            var request = (HttpWebRequest) WebRequest.Create($"https://jira.sks365.com/rest/api/2/issue/{bugId}?fields=status");

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("g.astashonok-gs" + ":" + "zL7Bem!cfN#"));
            request.Headers.Add("Authorization", "Basic " + encoded);
            try
            {
                using (var resp = request.GetResponse())
                {
                    try
                    {
                        var json = new StreamReader(resp.GetResponseStream() ?? throw new InvalidOperationException())
                            .ReadToEnd();
                        dynamic stuff = JsonConvert.DeserializeObject(json);
                        status = stuff.fields.status.name;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return status;
        }
    }
}
