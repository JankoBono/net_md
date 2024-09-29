using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace MD1.classes
{
    public class DataManager : IDataManager
    {
        // Kolekcijas priekš klasēm
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Assignement> Assignments { get; set; }
        public List<Submission> Submissions { get; set; }
        public List<ReviewForm> Reviews { get; set; }

        // Konstruktors
        public DataManager()
        {
            Teachers = new List<Teacher>();
            Students = new List<Student>();
            Courses = new List<Course>();
            Assignments = new List<Assignement>();
            Submissions = new List<Submission>();
            Reviews = new List<ReviewForm>();
        }

        // Implementācija metodei Print() - izveido lasāmu pārskatu par visiem datiem
        public string Print()
        {
            string result = "=== Skolotāji ===\n";
            foreach (var teacher in Teachers)
            {
                result += teacher.ToString() + "\n";
            }

            result += "\n=== Studenti ===\n";
            foreach (var student in Students)
            {
                result += student.ToString() + "\n";
            }

            result += "\n=== Kursi ===\n";
            foreach (var course in Courses)
            {
                result += course.ToString() + "\n";
            }

            result += "\n=== Uzdevumi ===\n";
            foreach (var assignment in Assignments)
            {
                result += assignment.ToString() + "\n";
            }

            result += "\n=== Nodevumi ===\n";
            foreach (var submission in Submissions)
            {
                result += submission.ToString() + "\n";
            }

            result += "\n=== Atsauksmes anketas ===\n";
            foreach (var review in Reviews)
            {
                result += review.ToString() + "\n";
            }

            return result;
        }

        // Implementācija metodei Save() - saglabā datus failā XML formātā
        public void Save(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataManager));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }
        }

        // Implementācija metodei Load() - ielādē datus no XML faila
        public void Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataManager));
                using (TextReader reader = new StreamReader(filePath))
                {
                    var data = (DataManager)serializer.Deserialize(reader);
                    this.Teachers = data.Teachers;
                    this.Students = data.Students;
                    this.Courses = data.Courses;
                    this.Assignments = data.Assignments;
                    this.Submissions = data.Submissions;
                    this.Reviews = data.Reviews;
                }
            }
            else
            {
                throw new FileNotFoundException("File not found.");
            }
        }

        // Implementācija metodei CreateTestData() - radīt testa datus priekš visām klasēm
        public void CreateTestData()
        {
            // Testa dati priekš skolotājiem
            var teacher1 = new Teacher("Jānis", "Kalniņš", Gender.Man, DateTime.Now);
            var teacher2 = new Teacher("Paula", "Taure", Gender.Woman, DateTime.Now);
            Teachers.Add(teacher1);
            Teachers.Add(teacher2);

            // Testa dati priekš studentiem
            var student1 = new Student("Fabiāns", "Duks", Gender.Man, "S12345");
            var student2 = new Student("Estere", "Pakalna", Gender.Woman, "S67890");
            Students.Add(student1);
            Students.Add(student2);

            // Testa dati priekš kursiem
            var course1 = new Course { Name = "Matemātika", Teacher = teacher1 };
            var course2 = new Course { Name = "Bioloģija", Teacher = teacher2 };
            Courses.Add(course1);
            Courses.Add(course2);

            // Testa dati priekš uzdevumiem
            var assignment1 = new Assignement { Deadline = DateTime.Now.AddDays(7), Course = course1, Description = "Iesniegt MD1" };
            var assignment2 = new Assignement { Deadline = DateTime.Now.AddDays(10), Course = course2, Description = "Prezentēt" };
            Assignments.Add(assignment1);
            Assignments.Add(assignment2);

            // Testa dati priekš iesniegumiem
            var submission1 = new Submission { Assignement = assignment1, Student = student1, SubmissionTime = DateTime.Now, Score = 95 };
            var submission2 = new Submission { Assignement = assignment2, Student = student2, SubmissionTime = DateTime.Now, Score = 90 };
            Submissions.Add(submission1);
            Submissions.Add(submission2);

            // Testa dati priekš atsauksmēm
            Reviews.Add(new ReviewForm { Student = student1, Course = course1, Score = 88, Description = "Viss bija saprotams" });
            Reviews.Add(new ReviewForm { Student = student2, Course = course2, Score = 92, Description = "Garlaicīgi stāstija" });
        }

        // Implementācija metodei Reset() - notīra visus datus
        public void Reset()
        {
            Teachers.Clear();
            Students.Clear();
            Courses.Clear();
            Assignments.Clear();
            Submissions.Clear();
            Reviews.Clear();
        }
    }
}
