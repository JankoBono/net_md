using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MD1
{
    interface IDataManager
    {
        // Atgriež informāciju par visiem kolekcijās esošajiem elementiem kā tekstu
        string Print();

        // Saglabā visu kolekciju datus failā
        bool Save(string filePath);

        // Nolasīt visu kolekciju datus no faila
        bool Load(string filePath);

        // Radīt testa datus kolekcijās
        bool CreateTestData();

        // Izdzēst visus datus kolekcijās
        bool Reset();
    }
}
