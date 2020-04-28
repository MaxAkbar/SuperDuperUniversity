using SuperDuperUniversity.BusinessLogic;
using SuperDuperUniversity.Interfances;
using SuperDuperUniversity.Models;
using System;

namespace SuperDuperUniversity.Screens
{
    public class InstructorClassDetails : IScreen
    {
        private UniversityCatalog _universityCatalog;
        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public string InstructorName { get; set; }
        public IScreen NextScreen { get; set; }
        public IScreen PreviousScreen { get; set; }

        public InstructorClassDetails(UniversityCatalog universityCatalog)
        {
            _universityCatalog = universityCatalog;
        }

        public void MoveNextScreen()
        {
            throw new System.NotImplementedException();
        }

        public void MovePreviousScreen()
        {
            throw new System.NotImplementedException();
        }

        public void ProcessCommands(string message)
        {
            Console.Clear();
            Console.Title = $"Super Duper University (Instructor Students Class({ClassId})";

            Console.WriteLine("****************************************************************");
            Console.WriteLine("*Welcome to the Super - Duper University Instructor Application*");
            Console.WriteLine("* ***************************************************************");
            Console.WriteLine("");
            Console.WriteLine($"Welcome {InstructorName} Current class detail ({ClassId}-{GetClassName({ClassId})}).");
            Console.WriteLine("Type rollcall to begin attendance:");
            Console.WriteLine("");
            Console.WriteLine("Student Id| Student name ");

            InstructorClassStudents[] instructorClassStudents = _universityCatalog.GetInstructorClass(ClassId);

            for (int index = 0; index < instructorClassStudents.Length; index++)
            {
                InstructorClassStudents instructorClassStudent = instructorClassStudents[index];

                Console.WriteLine($"{instructorClassStudent.StudentId}|{instructorClassStudent.FirstName}");
            }

            string userOption = Console.ReadLine();
        }

        private string GetClassName(int classId)
        {
            return _universityCatalog.GetClassName(classId);
        }
    }
}