using SuperDuperUniversity.DataAccess;
using SuperDuperUniversity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.BusinessLogic
{
    public class UniversityCatalog
    {
        private UniversityData _universityData;
        public UniversityCatalog(UniversityData universityData)
        {
            _universityData = universityData;
        }

        public UniversityClass[] GetInstructorClasses(int instructorId)
        {
            UniversityClass[] universityClasses = new UniversityClass[0];


            for (int index = 0; index < _universityData.InstructorClasses.Length; index++)
            {
                InstructorClass instructorClass = _universityData.InstructorClasses[index];

                if (instructorClass.InstructorId.Equals(instructorId))
                {
                    for (int indexJ = 0; indexJ < _universityData.UniversityClasses.Length; indexJ++)
                    {
                        UniversityClass universityClass = _universityData.UniversityClasses[indexJ];

                        if (universityClass.CourseId.Equals(instructorClass.CourseId))
                        {
                            Array.Resize(ref universityClasses, universityClasses.Length + 1);

                            universityClasses[universityClasses.Length - 1] = universityClass;
                        }
                    }
                }
            }

            return universityClasses;
        }

        public InstructorClassStudents[] GetInstructorClass(int classId)
        {
            InstructorClassStudents[] instructorClassInfo = new InstructorClassStudents[0];

            for (int index = 0; index < _universityData.InstructorClassStudents.Length; index++)
            {
                InstructorClassStudents instructorClassStudents = _universityData.InstructorClassStudents[index];

                if (instructorClassStudents.CourseId.Equals(classId))
                {
                    Array.Resize(ref instructorClassInfo, instructorClassInfo.Length + 1);

                    instructorClassInfo[instructorClassInfo.Length - 1] = instructorClassStudents;
                }
            }

            return instructorClassInfo;
        }

        internal string GetClassName(int classId)
        {
            for (int index = 0; index < _universityData.UniversityClasses.Length; index++)
            {
                UniversityClass universityClass = _universityData.UniversityClasses[index];

                if (universityClass.CourseId.Equals(classId))
                {
                    return universityClass.Title;
                }
            }

            return "";
        }
    }
}
