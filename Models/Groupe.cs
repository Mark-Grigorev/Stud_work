using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Groupe
    {
        public Groupe()
        {
            Students = new HashSet<Student>();
            TheSubjects = new HashSet<TheSubject>();
        }

        public int Id { get; set; }
        public string NameOfGroupe { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TheSubject> TheSubjects { get; set; }
    }
}
