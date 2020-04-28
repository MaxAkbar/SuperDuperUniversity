using SuperDuperUniversity.Interfances;
using System;

namespace SuperDuperUniversity.Models
{
    public struct Student : IPerson
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Discriminiator { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}