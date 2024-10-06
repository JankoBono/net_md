using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool Save(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataManager));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }
            return true;
        }

        // Implementācija metodei Load() - ielādē datus no XML faila
        public bool Load(string filePath)
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
            return true;
        }

        // Implementācija metodei CreateTestData() - izveido testa datus priekš visām klasēm
        public bool CreateTestData()
        {
            // Testa dati priekš skolotājiem
            var teacher1 = new Teacher("Jānis", "Kalniņš", Gender.Man, DateTime.Now);
            var teacher2 = new Teacher("Paula", "Taure", Gender.Woman, DateTime.Now);
            Teachers.Add(teacher1);
            Teachers.Add(teacher2);

            // Testa dati priekš studentiem
            var student1 = new Student("Fabiāns", "Duks", Gender.Man, "FB1234");
            var student2 = new Student("Estere", "Pakalna", Gender.Woman, "EP5678");
            Students.Add(student1);
            Students.Add(student2);

            // Testa dati priekš kursiem
            var course1 = new Course { Name = "Matemātika", Teacher = teacher1 };
            var course2 = new Course { Name = "Bioloģija", Teacher = teacher2 };
            Courses.Add(course1);
            Courses.Add(course2);

            // Testa dati priekš uzdevumiem
            // AddDays() reference paņemta no https://www.geeksforgeeks.org/datetime-adddays-method-in-c-sharp/
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
            var review1 = new ReviewForm { Student = student1, Course = course1, Score = 88, Description = "Viss bija saprotams" };
            var review2 = new ReviewForm { Student = student2, Course = course2, Score = 92, Description = "Garlaicīgi stāstija" };
            Reviews.Add(review1);
            Reviews.Add(review2);
            return true;
        }

        // Implementācija metodei Reset() - notīra visus datus
        public bool Reset()
        {
            Teachers.Clear();
            Students.Clear();
            Courses.Clear();
            Assignments.Clear();
            Submissions.Clear();
            Reviews.Clear();
            return true;
        }
    }
}
