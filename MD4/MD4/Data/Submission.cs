namespace MD4.Data
{
    public class Submission
    {
        public int Id { get; set; }
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
