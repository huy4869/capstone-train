using System;
using System.Collections.Generic;

#nullable disable

namespace TestMySql2.Models
{
    public partial class Student
    {
        public Student()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
