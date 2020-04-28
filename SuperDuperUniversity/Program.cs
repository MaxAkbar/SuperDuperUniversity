using SuperDuperUniversity.BusinessLogic;
using SuperDuperUniversity.DataAccess;
using SuperDuperUniversity.Screens;
using System;

namespace SuperDuperUniversity
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityData universityData = new UniversityData();
            UniversityCatalog universityCatalog = new UniversityCatalog(universityData);
            UniversityAdministration universityAdministration = new UniversityAdministration(universityData);

            ScreenManager screenManager = new ScreenManager(universityAdministration, universityCatalog);
            screenManager.Start();
        }
    }
}
