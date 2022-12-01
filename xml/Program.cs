using System.Xml.Serialization;

const string filename="demo.xml";

XmlSerializer ser = new(typeof(Person));
Person p = new() { name="Petra", alter=20 };

using (StreamWriter o = File.CreateText(filename)) { 
    ser.Serialize(o, p); 
}

using (StreamReader o = File.OpenText(filename))
{ 
    Person? q = ser.Deserialize(o) as Person; 
    if (q!=null) {
        System.Console.WriteLine($"{q.name}: {q.alter}");
    }
}

public class Person
{
    public String? name { get; set; }
    public int alter { get; set; }
}