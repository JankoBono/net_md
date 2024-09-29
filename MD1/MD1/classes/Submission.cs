using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1.classes
{
    public class Submission
    {
        public Assignement Assignement { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }
    }
}
