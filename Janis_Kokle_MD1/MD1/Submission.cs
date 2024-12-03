using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MD1
{
    public class Submission
    {
        public Assignement Assignement { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            // // Pārdefinēta ToString() metode, kas oriģināli nebija prasīta, bet manuprāt noderīga, lai varētu attēlot objekta datus
            return $"Uzdevums: {Assignement}, Students: {Student}, Iesniegšanas laiks: {SubmissionTime}, Vērtējums: {Score}";
        }
    }
}
