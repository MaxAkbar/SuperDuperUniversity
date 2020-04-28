using SuperDuperUniversity.BusinessLogic;
using SuperDuperUniversity.Interfances;

namespace SuperDuperUniversity.Screens
{
    class ScreenManager
    {
        private IScreen _startScreen;
        private UniversityAdministration _universityAdministration;
        private UniversityCatalog _universityCatalog;
        public ScreenManager(UniversityAdministration universityAdministration, UniversityCatalog universityCatalog)
        {
            _universityAdministration = universityAdministration;
            _universityCatalog = universityCatalog;

            BuildAllScreens();
        }

        private void BuildAllScreens()
        {
            // Home
            _startScreen = new Home();

            // Login
            Login login = new Login(_universityAdministration);


            // instructor
            Instructor instructor = new Instructor(_universityCatalog);

            // instructor class details
            InstructorClassDetails instructorClassDetails = new InstructorClassDetails(_universityCatalog);

            // set up home
            _startScreen.PreviousScreen = _startScreen;
            _startScreen.NextScreen = login;

            // set up login
            login.PreviousScreen = _startScreen;
            login.NextScreen = instructor;

            // set up instructor
            instructor.NextScreen = instructorClassDetails;
            instructor.PreviousScreen = _startScreen;

            // set up instructorClassDetails
            instructorClassDetails.NextScreen = null;
            instructorClassDetails.PreviousScreen = instructor;
        }

        internal void Start()
        {
            _startScreen.ProcessCommands("");
        }
    }
}
