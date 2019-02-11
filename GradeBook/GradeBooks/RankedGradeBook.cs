using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) 
        {
            char letter = 'F';
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            int count = 0;
            foreach (Student student in Students)
            {
                if (averageGrade >= student.AverageGrade)
                    count++;
            } 
            if (Students.Count < 5)
                throw new InvalidOperationException("Minimun 5 students");

            double average = (double)count / Students.Count;
            Console.WriteLine("average: "+average);
            //if (average <= 0.2)
            //    return 'A';
            //else if (average > 0.2 && average <= 0.4)
            //    return 'B';
            //else if (average > 0.4 && average <= 0.6)
            //    return 'C';
            //else if (average > 0.6 && average <= 0.8)
            //    return 'D';

            if (grades[(int)Math.Ceiling(Students.Count * 0.2) - 1] <= averageGrade)
                return 'A';
            else if (grades[(int)Math.Ceiling(Students.Count * 0.4) - 1] <= averageGrade)
                return 'B';
            else if (grades[(int)Math.Ceiling(Students.Count * 0.6) - 1] <= averageGrade)
                return 'C';
            else if (grades[(int)Math.Ceiling(Students.Count * 0.8) - 1] <= averageGrade)
                return 'D';

            return letter;
        }

        public override void CalculateStatistics()
        {
            var grades = Students.Select(e => e.Grades).ToList();
            if (grades.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
