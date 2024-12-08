using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD1
{
    public class DbDataManeger : IDataManager, IAddStudent, IAddAssignement, IAddSubmission
    {
        public MD3Context context;
        private string _connectionString = "";

        public DbDataManeger()
        {
            try
            {
                context = new MD3Context();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, veidojot datu bāzes kontekstu: {ex.Message}");
            }
        }
        public DbDataManeger(string cs)
        {
            _connectionString = cs;
        }

        public List<Student> studenti
        {
            get
            {
                return context.Studenti.ToList();
            }
            set
            {
                var removeSt = context.Studenti.Except(value).ToList();
                foreach (var st in removeSt)
                {
                    context.Studenti.Remove(st);
                }

                var addSt = value.Except(context.Studenti).ToList();
                foreach (var st in addSt)
                {
                    context.Studenti.Add(st);
                }
                Save();

            }
        }

        public List<Submission> submissions
        {
            get
            {
                return context.Submissions.ToList();
            }
            set
            {
                var removeSubs = context.Submissions.Except(value).ToList();
                foreach (var sub in removeSubs)
                {
                    context.Submissions.Remove(sub);
                }

                var addSubs = value.Except(context.Submissions).ToList();
                foreach (var sub in addSubs)
                {
                    context.Submissions.Add(sub);
                }
                Save();

            }
        }

        public List<Assignement> assignements
        {
            get
            {
                return context.Assignements.ToList();
            }
            set
            {
                var removeAssignements = context.Assignements.Except(value).ToList();
                foreach (var assignement in removeAssignements)
                {
                    context.Assignements.Remove(assignement);
                }

                var addAssignements = value.Except(context.Assignements).ToList();
                foreach (var assignement in addAssignements)
                {
                    context.Assignements.Add(assignement);
                }

                Save();
            }
        }




        public bool AddPerson(Student s)
        {
            try
            {
                if (s != null)
                {
                    context.Studenti.Add(s);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, pievienojot studentu: {ex.Message}");
                return false;
            }

        }
        public bool AddAssignement(Assignement a)
        {
            try
            {
                if (a != null)
                {
                    context.Assignements.Add(a);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, pievienojot uzdevumu: {ex.Message}");
                return false;
            }

        }
        public bool AddSubmission(Submission n)
        {
            try
            {
                if (n != null)
                {
                    context.Submissions.Add(n);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, pievienojot iesniegumu: {ex.Message}");
                return false;
            }

        }

        public bool CreateTestData()
        {
            try
            {
                var teacher1 = new Teacher("Jānis", "Kalniņš", Gender.Man, DateTime.Now);
                var teacher2 = new Teacher("Paula", "Taure", Gender.Woman, DateTime.Now);
                context.Teachers.Add(teacher1);
                context.Teachers.Add(teacher2);

                var student1 = new Student("Fabiāns", "Duks", Gender.Man, "FB1234");
                var student2 = new Student("Estere", "Pakalna", Gender.Woman, "EP5678");
                context.Studenti.Add(student1);
                context.Studenti.Add(student2);

                var course1 = new Course { Name = "Matemātika", Teacher = teacher1 };
                var course2 = new Course { Name = "Bioloģija", Teacher = teacher2 };
                context.Courses.Add(course1);
                context.Courses.Add(course2);

                var assignment1 = new Assignement { Deadline = DateTime.Now.AddDays(7), Course = course1, Description = "Iesniegt MD1" };
                var assignment2 = new Assignement { Deadline = DateTime.Now.AddDays(10), Course = course2, Description = "Prezentēt" };
                context.Assignements.Add(assignment1);
                context.Assignements.Add(assignment2);

                var submission1 = new Submission { Assignement = assignment1, Student = student1, SubmissionTime = DateTime.Now, Score = 95 };
                var submission2 = new Submission { Assignement = assignment2, Student = student2, SubmissionTime = DateTime.Now, Score = 90 };
                context.Submissions.Add(submission1);
                context.Submissions.Add(submission2);

                Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, izveidojot testa datus: {ex.Message}");
                return false;
            }
        }

        //------------ Šī koda daļa tika daļēji uzbūvēta ar mākslīgā intelekta palīdzību --------------------
        public bool Load()
        {
            try
            {
                // Ja savienojuma virkne ir pieejama, veido jaunu kontekstu ar to
                if (!string.IsNullOrEmpty(_connectionString))
                {
                    context = new MD3Context(); // Nepieciešams, ja izmanto citādu konstruktoru ar connection string
                }
                else
                {
                    context = new MD3Context();
                }

                Console.WriteLine("Dati veiksmīgi ielādēti no datubāzes.");
                return true;
            }
            catch (Exception ex)
            {
                // Saprotams kļūdas paziņojums lietotājam
                Console.WriteLine("Neizdevās izveidot savienojumu ar datubāzi. Lūdzu, pārbaudiet savienojuma iestatījumus.");
                Console.WriteLine($"Detalizēta kļūda: {ex.Message}");
                return false;
            }
        }
        //-----------------------------------AI koda beigas--------------------------------------


        public string Print()
        {
            string result = "=== Skolotāji ===\n";
            foreach (var teacher in context.Teachers)
            {
                result += teacher.ToString() + "\n";
            }

            result += "\n=== Studenti ===\n";
            foreach (var student in context.Studenti)
            {
                result += student.ToString() + "\n";
            }

            result += "\n=== Kursi ===\n";
            foreach (var course in context.Courses)
            {
                result += course.ToString() + "\n";
            }

            result += "\n=== Uzdevumi ===\n";
            foreach (var assignment in context.Assignements)
            {
                result += assignment.ToString() + "\n";
            }

            result += "\n=== Nodevumi ===\n";
            foreach (var submission in context.Submissions)
            {
                result += submission.ToString() + "\n";
            }

            return result;
        }
        public bool Reset()
        {
            try
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, atjaunojot datu bāzi: {ex.Message}");
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, saglabājot datus: {ex.Message}");
                return false;
            }
        }
        public List<Assignement> GetAssignements()
        {
            try
            {
                return context.Assignements.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda: {ex.Message}");
                return new List<Assignement>();
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                return context.Studenti.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda: {ex.Message}");
                return new List<Student>();
            }
        }

        public List<Course> GetCourse()
        {
            try
            {
                return context.Courses.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda: {ex.Message}");
                return new List<Course>();
            }
        }
    }

    }
