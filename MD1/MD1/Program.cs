using MD1.classes;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml.Linq;

Console.WriteLine("gm");

string path = "..\\..\\"; 
var dm = new DataManager(); 
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save(path);
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load(path);
Console.WriteLine(dm.Print());
Console.ReadLine();