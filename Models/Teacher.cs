using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            PersonalInformationOfTeachers = new HashSet<PersonalInformationOfTeacher>();
            Questions = new HashSet<Question>();
            Tests = new HashSet<Test>();
            TheSubjects = new HashSet<TheSubject>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<PersonalInformationOfTeacher> PersonalInformationOfTeachers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<TheSubject> TheSubjects { get; set; }
    }
}
