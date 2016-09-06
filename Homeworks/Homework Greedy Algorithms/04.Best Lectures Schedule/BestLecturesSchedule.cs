using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Best_Lectures_Schedule
{
    public class BestLecturesSchedule
    {
        private const string Pattern = @"(?<lecture>\w+): (?<start>\d+) - (?<end>\d+)";

        public static void Main()
        {
            int lecturesCount = int.Parse(Console.ReadLine().Substring(10));
            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), Pattern);
                string lectureName = match.Groups["lecture"].Value;
                int start = int.Parse(match.Groups["start"].Value);
                int end = int.Parse(match.Groups["end"].Value);

                Lecture lecture = new Lecture(lectureName, start, end);
                lectures.Add(lecture);
            }

            lectures = lectures.OrderBy(l => l.End).ToList();
            List<Lecture> result = new List<Lecture>();

            while (lectures.Count > 0)
            {
                Lecture last = lectures[0];
                result.Add(last);
                lectures = lectures.Where(l => l.Start >= last.End).ToList();
            }

            Console.WriteLine();
            Console.WriteLine($"Lectures ({result.Count}):");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
