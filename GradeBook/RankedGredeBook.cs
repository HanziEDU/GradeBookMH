using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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

            if (percent < 20 && percent <39 )
            {
                return 'A';
            }
            else if (percent < 40 && percent < 59)
            {
                return 'B';
            }
            else if(percent < 60 && percent <79)
            {
                return 'C';
            }
            else if(percent < 80)
            {
                return 'D';
            }
            return 'F';
        }
    }

}
