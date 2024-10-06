using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1.classes
{
    public class Course
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public override string ToString()
        {
            // Izsauc bāzes klases ToString() un klases Course pievieno īpašības
            return $"Kurss: {Name}, Pasniedzējs: {Teacher}";
        }
    }
}
