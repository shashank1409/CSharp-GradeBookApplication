using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

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
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            Students.Sort();
            int count = 0;
            for (int i = 1; i <=Students.Count; i++)
            { 
                if(i%threshold==0)
                {
                    count++;
                }
                if(count==1)
                {
                    return 'D';
                }
                else if(count==2)
                {
                    return 'C';
                }
                else if (count == 3)
                {
                    return 'B';
                }
                else if (count == 4)
                {
                    return 'A';
                }
            }
            
            return 'F';
        }
    }
}
