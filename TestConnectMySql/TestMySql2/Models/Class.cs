using System;
using System.Collections.Generic;

#nullable disable

namespace TestMySql2.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
