// See https://aka.ms/new-console-template for more information
//using Lekcija9;
using MD1;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new MD3Context())
{
    var s = new Student() { StudentIdNumber = "gh46567", Name = "Gauja", Surname = "Kupla", Gender = Gender.Woman };
    context.Studenti.Add(s);
    context.SaveChanges();
    //context.Studenti.Remove(s1);
    //context.SaveChanges();
    Console.WriteLine(s);
    //   Console.WriteLine($"Student: {s}, StudentID: {s.StudentId}, Name: {s.Name}, Surname: {s.Surname}");
    // Queries go here
}