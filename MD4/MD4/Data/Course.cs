namespace MD4.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public override string ToString()
        {
            // Pārdefinēta ToString() metode
            return $"Kurss: {Name}, Pasniedzējs: {Teacher}";
        }
    }
}
