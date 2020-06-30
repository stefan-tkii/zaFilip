using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.Models
{
    public class Student
    {
        public Student()
        {

        }

        public int Id { get; set; }

        public string fullName { get; set; }

        public string indeks { get; set; }

        public bool signature { get; set; }

        public ICollection<Studentlab> vezbi { get; set; }
    }
}
