using System;
using System.Collections.Generic;
using System.Text;

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
            // 1. One way to solve this is to figure out how many students make up 20%,
            List<double> listOfGrades = new List<double>();
            foreach (var student in Students)
            {
                listOfGrades.Add(student.AverageGrade);
            }
            int n = (Students.Count) / 5;  // 20% of students

            // 2. then loop through all the grades and check how many scored higher than the input average,
            int a = 0;
            foreach (var grade in listOfGrades)
            {
                if (grade > averageGrade)
                {
                    a++;
                }
            }

            // 3. every N students where N is that 20% value drop a letter grade.
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else if (a / n < 1)
                return 'A';
            else if (a / n < 2 && a / n >= 1)
                return 'B';
            else if (a / n < 3 && a / n >= 2)
                return 'C';
            else if (a / n < 4 && a / n >= 3)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}