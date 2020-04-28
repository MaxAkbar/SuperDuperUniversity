using SuperDuperUniversity.Interfances;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.Screens
{
    public class Home : IScreen
    {
        public IScreen NextScreen { get; set; }
        public IScreen PreviousScreen { get; set; }
        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public string InstructorName { get; set; }

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
            Console.Title = "Super Duper University (Home)";

            // display instructions
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*Welcome to the Super - Duper University Instructor Application*");
            Console.WriteLine(" ****************************************************************");

            Console.WriteLine("Use your name and instructor Id to log into the system.");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("Type Login to begin: Login");

            string userCommand = Console.ReadLine();

            if (userCommand.ToLower().Equals("Login".ToLower()))
            {
                // move to next screen
                MoveNextScreen();
            }
            else
            {
                // display error message
                ProcessCommands("You must type the correct command.");
            }
        }
    }
}
