using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDuperUniversity.Interfances
{
    public interface IPerson
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Discriminiator { get; set; }
    }
}
