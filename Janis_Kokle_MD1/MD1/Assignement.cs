using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1
{
    public class Assignement
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public Course Course { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            // Pārdefinēta ToString() metode
            return $"Beigu datums: {Deadline}, Kurss: {Course}, Apraksts: {Description}";
        }
    }
}
