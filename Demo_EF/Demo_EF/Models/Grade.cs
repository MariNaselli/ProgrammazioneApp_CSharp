﻿using System.Text.Json.Serialization;

namespace Demo_EF.Models
{
    public class Grade
    {
        public Grade()
        {
            Students = new List<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public IList<Student> Students { get; set; }

    }
}


