using MD1.classes;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml.Linq;


string filePath  = @"..\..\figures.xml";
var dm = new DataManager(); 
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save(filePath);
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load(filePath);
Console.WriteLine(dm.Print());
Console.ReadLine();