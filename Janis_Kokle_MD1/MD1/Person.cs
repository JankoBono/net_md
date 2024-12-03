using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MD1
{
    // Definēts pārskaitāmais tips Gender
    public enum Gender
    {
        Man,
        Woman
    }
    // Komandas, kas iekļauj apakšklases virsklases serializācijā
    [XmlInclude(typeof(Teacher))]
    [XmlInclude(typeof(Student))]

    public abstract class Person
    {

        public int Id { get; set; }

        // Privātie atribūti
        private string _name;
        private string _surname;
        private Gender _gender;

        // Publiskā īpašība Name ar pārbaudi
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
            }
        }

        // Publiskā īpašība Surname
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        // Tikai lasāma īpašība FullName
        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }

        // Publiskā īpašība Gender
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        // Konstruktors
        public Person(string name, string surname, Gender gender)
        {
            _name = !string.IsNullOrWhiteSpace(name) ? name : "Unknown";
            _surname = surname;
            _gender = gender;
        }

        // Bez parametru konstruktors vajadzīgs priekš serializācijas,
        // jo tāds bija nepieciešams apakšklasei, tātad jāiekļauj arī pārējām saistītām klasēm

        public Person()
        {
        }


        // Pārdefinēta ToString() metode
        public override string ToString()
        {
            return $"Vārds: {Name}, Uzvārds: {Surname}, Pilnais vārds: {FullName}, Dzimums: {Gender}";
        }
    }
    public class Teacher : Person
    {
        public DateTime ContractDate { get; set; }
        
        // Bez parametru konstruktors
        public Teacher() : base("Vards", "Uzvards", Gender.Man)
        {
        }

        // Konstruktors, kas izsauc bāzes klases Person konstruktoru
        // Lai gan konstruktors netika prasīts pie šīs klases, tomēr ja tas bija prasīts pie 3. uzd, tad nepieciešams to izveidot visām pārējām klasēm arī
        public Teacher(string name, string surname, Gender gender, DateTime contractDate)
            : base(name, surname, gender) // Izsauc Person klases konstruktoru
        {
            ContractDate = contractDate;
        }


        public override string ToString()
        {
            return $"{base.ToString()}, Līguma datums: {ContractDate.ToShortDateString()}";
        }
    }

    public class Student : Person
    {
        public string StudentIdNumber { get; set; }

        // Pirmais konstruktors - saņem visus parametrus
        public Student(string name, string surname, Gender gender, string studentIdNumber)
            : base(name, surname, gender) // Izsauc bāzes klases Person konstruktoru
        {
            StudentIdNumber = studentIdNumber;
        }

        // Otrais konstruktors - bez parametriem
        public Student() : base("Vards", "Uzvards", Gender.Man)
        {
        }

        // Pārdefinētā metode ToString()
        public override string ToString()
        {
            // Izsauc bāzes klases ToString() un pievieno StudentIdNumber
            return $"{base.ToString()}, Studenta apliecības ID: {StudentIdNumber}";
        }
    }
}

