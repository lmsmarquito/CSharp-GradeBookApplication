using GradeBook.Enums;
using System;
using System.Collections.Generic;
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

            int average = (int)(Students.Count / count);
            if(average <= 0.2)
                return 'A';
            else if (average > 0.2 && average <= 0.4)
                return 'B';
            else if (average > 0.4 && average <= 0.6)
                return 'C';
            else if (average > 0.6 && average <= 0.8)
                return 'D';

            return letter;
        } 
    }
}
