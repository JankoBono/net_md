namespace MD4.Data
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
