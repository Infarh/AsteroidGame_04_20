﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Models
{
    internal class StudentsGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"[{Id}]{Name}";
    }
}
