using MD1;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml.Linq;


var dm = new DataManager(); 
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save();
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load();
Console.WriteLine(dm.Print());
Console.ReadLine();