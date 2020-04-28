using SuperDuperUniversity.Interfances;
using System;

namespace SuperDuperUniversity.Models
{
    public struct Instructor : IPerson
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Discriminiator { get; set; }
        public DateTime HireDate { get; set; }
    }
}