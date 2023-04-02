using System;
using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int IleLepiej = 0;
            foreach (var Student in Students)
                if (averageGrade < Student.AverageGrade) IleLepiej++;

            int percent = (100 * IleLepiej) / Students.Count;

            if (percent < 20 && percent <40 )
            {
                return 'A';
            }
            else if (percent < 40 && percent < 60)
            {
                return 'B';
            }
            else if(percent < 60 && percent <80)
            {
                return 'C';
            }
            else if(percent < 80)
            {
                return 'D';
            }
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }

}
