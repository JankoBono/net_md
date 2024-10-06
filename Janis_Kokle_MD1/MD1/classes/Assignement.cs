using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1.classes
{
    public class Assignement
    {
        public DateTime Deadline { get; set; }
        public Course Course { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            // Izsauc bāzes klases ToString() un pievieno klases Assignement īpašības
            return $"Beigu datums: {Deadline}, Kurss: {Course}, Apraksts: {Description}";
        }
    }
}
