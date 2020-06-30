using ispit_zadaca1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.ViewModels
{
    public class StudentskiVezbiViewModel
    {
      

        public Student student { get; set; }

        public ICollection<Studentlab> vezbi_student { get; set; }

        public StudentskiVezbiViewModel(Student student, ICollection<Studentlab> labs)
        {
            this.student = student;
            foreach(var labce in labs)
            {
                this.vezbi_student.Add(labce);
            }
        }
    }
}
