using ispit_zadaca1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.ViewModels
{
    public class EnrollViewModel
    {
        public Student student { get; set; }

        public ICollection<Labvezba> vezbi { get; set; }

        public EnrollViewModel(Student student, ICollection<Labvezba> vezbi)
        {
            this.student = student;
            foreach(var vezba in vezbi)
            {
                this.vezbi.Add(vezba);
            }
        }
    }
}
