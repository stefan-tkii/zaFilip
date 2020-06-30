using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.Models
{
    public class Labvezba
    {
        public Labvezba()
        {

        }

        public int Id { get; set;}

        public string title { get; set; }

        public string desc { get; set; }

        public ICollection<Studentlab> studenti { get; set; }

    }
}
