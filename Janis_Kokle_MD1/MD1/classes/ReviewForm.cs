using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1.classes
{
    public class ReviewForm // klase domāta kā anketa, ko iesniedz students par kursa vērtējumu
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }

    }
}
