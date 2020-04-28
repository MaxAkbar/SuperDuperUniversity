using SuperDuperUniversity.BusinessLogic;
using SuperDuperUniversity.Interfances;
using SuperDuperUniversity.Models;
using System;

namespace SuperDuperUniversity.Screens
{
    public class Instructor : IScreen
    {
        private UniversityCatalog _universityCatalog;
        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public string InstructorName { get; set; }


        public Instructor(UniversityCatalog universityCatalog)
        {
            _universityCatalog = universityCatalog;
        }

        public IScreen NextScreen { get; set ; }
        public IScreen PreviousScreen { get; set; }

        public void MoveNextScreen()
        {
            NextScreen.ProcessCommands("");
        }

        public void MovePreviousScreen()
        {
            PreviousScreen.ProcessCommands("");
        }

        public void ProcessCommands(string message)
        {
            Console.Clear();
            Console.Title = "Super Duper University (Instructor)";

            Console.WriteLine("****************************************************************");
            Console.WriteLine("*Welcome to the Super - Duper University Instructor Application*");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("");
            Console.WriteLine($"Welcome {InstructorName} please select an option:");
            Console.WriteLine("");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("");
            Console.WriteLine("(1) List Classes");
            Console.WriteLine("(2) Search Class");
            Console.WriteLine("(3) Search Student");
            Console.WriteLine("(4) Home");

            string userOption = Console.ReadLine();

            if (!string.IsNullOrEmpty(userOption))
            {
                if (userOption.Equals("1"))
                {
                    DisplayAllClasses("");
                }
                if (userOption.Equals("2"))
                {
                    SearchClasses();
                }
                if (userOption.Equals("3"))
                {
                    SearchStudents();
                }
                if (userOption.Equals("4"))
                {
                    MovePreviousScreen();
                }
            }
            else
            {
                ProcessCommands("Please select an option!");
            }

        }

        private void SearchStudents()
        {
            throw new NotImplementedException();
        }

        private void SearchClasses()
        {
            throw new NotImplementedException();
        }

        private void DisplayAllClasses(string message)
        {
            Console.Clear();
            Console.Title = "Super Duper University (Instructor - Classes)";

            Console.WriteLine("****************************************************************");
            Console.WriteLine("*Welcome to the Super - Duper University Instructor Application*");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("");
            Console.WriteLine($"Welcome {InstructorName} please select an option:");
            Console.WriteLine("");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("");
            Console.WriteLine("(1) Please select class Id to view details.");
            Console.WriteLine("");

            // display columns
            Console.WriteLine("Course Id|Course Title");

            UniversityClass[] universityClasses = _universityCatalog.GetInstructorClasses(InstructorId);

            for (int index = 0; index < universityClasses.Length; index++)
            {
                UniversityClass universityClass = universityClasses[index];

                Console.WriteLine($"{universityClass.CourseId}|{universityClass.Title}");
            }

            string userOption = Console.ReadLine();

            if (!string.IsNullOrEmpty(userOption))
            {
                int classId = int.Parse(userOption);

                NextScreen.InstructorId = InstructorId;
                NextScreen.ClassId = classId;
                NextScreen.InstructorName = InstructorName;

                MoveNextScreen();

            }
            else
            {
                DisplayAllClasses("Pease select a class Id!");
            }
        }
    }
}
