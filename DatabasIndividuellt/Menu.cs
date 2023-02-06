using DatabasIndividuellt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasIndividuellt
{
    internal class Menu
    {
        Data context = new Data();
        public void MenuList()
        {
            Console.Clear();
            Console.WriteLine("\n\tSchool Eastwood High" +
                "\n" +
                "\n\t--Menu--" +
                "\n\t1. Teacher And Sections" +
                "\n\t2. All Student Information" +
                "\n\t3. Active Courses");

            string input = Console.ReadLine();
            int.TryParse(input, out int pick);

            switch (pick)
            {
                case 1:
                    TeacherSection();
                    break;
                case 2:
                    AllStudentInfo();
                    break;
                case 3:
                    ActiveCourses();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n\tInvalid Pick!");
                    Console.ReadLine();
                    MenuList();
                    break;
            }
        }
        public void TeacherSection()
        {
            int Elementary = 0;
            int Middle = 0;
            int High = 0;
            var TeacherProffession = context.Personals.Where(x => x.ProffessionId == 1);
            foreach (var item in TeacherProffession)
            {
                if (item.SectionId == 1)
                {
                    Elementary++;
                }
                else if (item.SectionId == 2)
                {
                    Middle++;
                }
                else if (item.SectionId == 3)
                {
                    High++;
                }
            }
            Console.Clear();
            Console.WriteLine($"\n\tTeachers In Elementary Section: {Elementary}" +
                $"\n\tTeachers In Middle Section: {Middle}" +
                $"\n\tTeachers In High Section: {High}");
            Console.ReadLine();
            MenuList();
        }
        public void AllStudentInfo()
        {
            var info = context.Students.OrderBy(x => x.FName);
            Console.Clear();
            foreach (var item in info)
            {
                Console.WriteLine($"\n\t ID: {item.StudentId}, SSN: {item.Ssn}, Name: {item.FName} {item.LName}, ClassID: {item.ClassId}");
            }
            Console.ReadLine();
            MenuList();
        }
        public void ActiveCourses()
        {
            var CourseActive = context.Subjects.Where(x => x.CourseActive == "Yes");
            Console.Clear();
            foreach (var item in CourseActive)
            {
                Console.WriteLine($"\n\tCourse Name: {item.SubjectName}, Course Active: {item.CourseActive}");
            }
            Console.ReadLine();
            MenuList();
        }
    }
}
