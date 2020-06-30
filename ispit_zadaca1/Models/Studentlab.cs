using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.Models
{
    public class Studentlab
    {
        public Studentlab()
        {

        }

        public int Id { get; set; }

        public int studentId { get; set; }

        public Student student { get; set; }

        public int labvezbaId { get; set; }

        public Labvezba vezba { get; set; }

        public bool finished { get; set; }

        public int points { get; set; }

        [DataType(DataType.Date)]
        public DateTime finishDate { get; set; }
    }
}
