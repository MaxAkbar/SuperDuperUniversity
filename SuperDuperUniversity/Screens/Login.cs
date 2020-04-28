using SuperDuperUniversity.BusinessLogic;
using SuperDuperUniversity.Interfances;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.Screens
{
    public class Login : IScreen
    {
        private UniversityAdministration _universityAdministration;

        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public string InstructorName { get; set; }

        public Login(UniversityAdministration universityAdministration)
        {
            _universityAdministration = universityAdministration;
        }

        public IScreen NextScreen { get; set; }
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
            Console.Title = "Super Duper University (Login)";

            // display instructions
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*Welcome to the Super - Duper University Instructor Application*");
            Console.WriteLine(" ****************************************************************");
            Console.WriteLine("");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("");
            Console.WriteLine("Please enter your instructor name and Id:");
            Console.WriteLine("");
            Console.Write("Instructor name: ");

            string userName = Console.ReadLine();

            if (!string.IsNullOrEmpty(userName))
            {
                Console.Write("Instructor Id: ");

                string userId = Console.ReadLine();

                if (!string.IsNullOrEmpty(userId))
                {
                    if (_universityAdministration.AuthenticateInstructor(userName, int.Parse(userId)))
                    {
                        NextScreen.InstructorId = int.Parse(userId);
                        NextScreen.InstructorName = userName;

                        MoveNextScreen();
                    }
                    else
                    {
                        ProcessCommands("Invalid username or password.");
                    }
                }
                else
                {
                    ProcessCommands("Please enter username or password.");
                }
            }
            else
            {
                ProcessCommands("Please enter username or password.");
            }
        }
    }
}
