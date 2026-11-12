using System;
using System.Collections.Generic;
using System.Text;




namespace ApiCe.Core.Entites
{
    public class Instructor
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?FullName { get; set; }

        public List<Course> Courses { get; set; } = [];
    }
}
