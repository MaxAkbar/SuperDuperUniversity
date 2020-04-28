using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.Interfances
{
    public interface IScreen
    {
        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public string InstructorName { get; set; }
        public IScreen NextScreen { get; set; }

        public IScreen PreviousScreen { get; set; }

        // display instructions and process commands
        public void ProcessCommands(string message);

        // move next screen
        public void MoveNextScreen();

        // move previous screen
        public void MovePreviousScreen();
    }
}
