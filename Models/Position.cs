using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Position
    {
        public Position()
        {
            PersonalInformationOfTeachers = new HashSet<PersonalInformationOfTeacher>();
            PersonalInformationOfSts = new HashSet<PersonalInformationOfSt>();
        }

        public int Id { get; set; }
        public string Position1 { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<PersonalInformationOfTeacher> PersonalInformationOfTeachers { get; set; }
        public virtual ICollection<PersonalInformationOfSt> PersonalInformationOfSts { get; set; }
    }
}
