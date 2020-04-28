using SuperDuperUniversity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperDuperUniversity.DataAccess
{
    public class UniversityData
    {
        private string _dbPath;
        private Student[] _students;
        private Instructor[] _instructors;
        private UniversityClass[] _universityClass;
        private InstructorClass[] _instructorClass;
        private InstructorClassStudents[] _instructorClassStudents;

        public Student[] Students 
        { 
            get 
            { 
                return _students; 
            }
        }

        public Instructor[] Instructors 
        { 
            get 
            { 
                return _instructors; 
            } 
        }

        public UniversityClass[] UniversityClasses
        {
            get 
            {
                return _universityClass;
            }
        }

        public InstructorClass[] InstructorClasses 
        {
            get 
            {
                return _instructorClass;
            }
        }

        public InstructorClassStudents[] InstructorClassStudents
        {
            get
            {
                return _instructorClassStudents;
            }
        }

        public UniversityData()
        {
            _dbPath = "";

            LoadData();
        }

        public UniversityData(string dbPath)
        {
            _dbPath = dbPath;

            LoadData();
        }

        private void LoadData()
        {
            LoadStudentAndInstructors();
            LoadInstructorClasses();
            LoadClasses();
            LoadStudentClasses();
        }

        private void LoadStudentClasses()
        {
            string[] allLines = File.ReadAllLines(string.Concat(_dbPath, @"Data\\", "StudentGrade.csv"));

            _instructorClassStudents = new InstructorClassStudents[allLines.Length];

            for (int index = 1; index < allLines.Length; index++)
            {
                string line = allLines[index];
                string[] columns = line.Split('|');

                _instructorClassStudents[index] = MapInstructorClassStudents(columns);
            }

        }

        private InstructorClassStudents MapInstructorClassStudents(string[] columns)
        {
            InstructorClassStudents instructorClassStudents = new InstructorClassStudents();

            instructorClassStudents.CourseId = int.Parse(columns[1]);
            instructorClassStudents.StudentId = int.Parse(columns[2]);
            instructorClassStudents.FirstName = GetStudentName(int.Parse(columns[2]));

            return instructorClassStudents;
        }

        private string GetStudentName(int studentId)
        {
            for (int index = 0; index < _students.Length; index++)
            {
                Student student = _students[index];

                if (student.PersonId.Equals(studentId))
                {
                    return student.FirstName;
                }
            }

            return "";
        }

        private void LoadClasses()
        {
            string[] allLines = File.ReadAllLines(string.Concat(_dbPath, @"Data\\", "Course.csv"));
            _universityClass = new UniversityClass[allLines.Length];

            for (int index = 1; index < allLines.Length; index++)
            {
                string line = allLines[index];
                string[] columns = line.Split('|');

                _universityClass[index] = MapUniversityClass(columns);
            }
        }

        private void LoadInstructorClasses()
        {
            string[] allLines = File.ReadAllLines(string.Concat(_dbPath, @"Data\\", "CourseInstructor.csv"));
            _instructorClass = new InstructorClass[allLines.Length];

            for (int index = 1; index < allLines.Length; index++)
            {
                string line = allLines[index];
                string[] columns = line.Split('|');

                _instructorClass[index] = MapInstructorClass(columns);
            }
        }

        private InstructorClass MapInstructorClass(string[] columns)
        {
            InstructorClass instructorClass = new InstructorClass();

            instructorClass.CourseId = int.Parse(columns[0]);
            instructorClass.InstructorId = int.Parse(columns[1]);

            return instructorClass;
        }

        private UniversityClass MapUniversityClass(string[] columns)
        {
            UniversityClass universityClass = new UniversityClass();

            universityClass.Title = columns[1];
            universityClass.CourseId = int.Parse(columns[0]);

            return universityClass;
        }

        private void LoadStudentAndInstructors()
        {
            string[] allLines = File.ReadAllLines(string.Concat(_dbPath, @"Data\\", "Person.csv"));
            _instructors = new Instructor[0];
            _students = new Student[0];

            for (int index = 1; index < allLines.Length; index++)
            {
                string line = allLines[index];
                string[] columns = line.Split('|');

                if (columns[5].Equals("Instructor"))
                {
                    Array.Resize(ref _instructors, _instructors.Length + 1);

                    _instructors[_instructors.Length - 1] = MapInstructor(columns);
                }
                if (columns[5].Equals("Student"))
                {
                    Array.Resize(ref _students, _students.Length + 1);

                    _students[_students.Length -1] = MapStudents(columns);
                }
            }

        }

        private Student MapStudents(string[] columns)
        {
            Student student = new Student();

            student.PersonId = int.Parse(columns[0]);
            student.LastName = columns[1];
            student.FirstName = columns[2];
            student.EnrollmentDate = DateTime.Parse(columns[4]);

            return student;
        }

        private Instructor MapInstructor(string[] columns)
        {
            Instructor instructor = new Instructor();

            instructor.PersonId = int.Parse(columns[0]);
            instructor.LastName = columns[1];
            instructor.FirstName = columns[2];
            instructor.HireDate = DateTime.Parse(columns[3]);

            return instructor;
    }
    }
}
