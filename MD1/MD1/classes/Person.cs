using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1.classes
{
    // Definēts pārskaitāmais tips Gender
    public enum Gender
    {
        Man,
        Woman
    }
    public abstract class Person
    {
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


        // Pārdefinēta ToString() metode
        public override string ToString()
        {
            return $"Vārds: {Name}, Uzvārds: {Surname}, Pilnais vārds: {FullName}, Dzimums: {Gender}";
        }
    }
    public class Teacher : Person
    {
        public DateTime ContractDate { get; set; }

        // Konstruktors, kas izsauc bāzes klases Person konstruktoru
        // Lai gan konstruktors netika prasīts pie šīs klases, tomēr ja tas bija prasīts pie 3. uzd, tad nepieciešams to izveidot visām pārējām klasēm arī
        public Teacher(string name, string surname, Gender gender, DateTime contractDate)
            : base(name, surname, gender) // Izsauc Person klases konstruktoru
        {
            ContractDate = contractDate;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Kontaktēšanās datums: {ContractDate.ToShortDateString()}";
        }
    }

    public class Student : Person
    {
        public int StudentIdNumber { get; set; }

        // Pirmais konstruktors - saņem visus parametrus
        public Student(string name, string surname, Gender gender, string studentIdNumber)
            : base(name, surname, gender) // Izsauc bāzes klases Person konstruktoru
        {
            StudentIdNumber = StudentIdNumber;
        }

        // Pārdefinētā metode ToString()
        public override string ToString()
        {
            // Izsauc bāzes klases ToString() un pievieno StudentIdNumber
            return $"{base.ToString()}, Studenta apliecības ID: {StudentIdNumber}";
        }
    }
}

