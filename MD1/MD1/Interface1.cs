using System;
using System.Collections.Generic;


namespace MD1
{
    interface IDataManager
    {
        // Atgriež informāciju par visiem kolekcijās esošajiem elementiem kā tekstu
        string Print();

        // Saglabā visu kolekciju datus failā
        void Save(string filePath);

        // Nolasīt visu kolekciju datus no faila
        void Load(string filePath);

        // Radīt testa datus kolekcijās
        void CreateTestData();

        // Izdzēst visus datus kolekcijās
        void Reset();
    }
}
