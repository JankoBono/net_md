using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MD1
{
    public interface IDataManager
    {
        // Atgriež informāciju par visiem kolekcijās esošajiem elementiem kā tekstu
        string Print();

        // Saglabā visu kolekciju datus failā
        bool Save();

        // Nolasa visu kolekciju datus no faila
        bool Load();

        // Izveido testa datus kolekcijās
        bool CreateTestData();

        // Izdzēš visus datus kolekcijās
        bool Reset();

        // Atgriež objetu datus sarakstā
        List<Course> GetCourse();
        List<Assignement> GetAssignements();

        List<Student> GetStudents();
    }
}
