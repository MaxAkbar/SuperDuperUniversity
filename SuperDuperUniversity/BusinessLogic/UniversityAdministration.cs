using SuperDuperUniversity.DataAccess;
using SuperDuperUniversity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.BusinessLogic
{
    public class UniversityAdministration
    {
        private UniversityData _universityData;

        public UniversityAdministration(UniversityData universityData)
        {
            _universityData = universityData;
        }

        public bool AuthenticateInstructor(string username, int userId)
        {
            for (int index = 0; index < _universityData.Instructors.Length; index++)
            {
                Instructor instructor = _universityData.Instructors[index];

                if (instructor.FirstName.ToLower().Equals(username.ToLower()) &&
                    instructor.PersonId.Equals(userId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
