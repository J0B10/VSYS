using System.Text.Json;

string txt = File.ReadAllText("person.json");
Data? d = JsonSerializer.Deserialize<Data>(txt);
if (d != null) Console.WriteLine($"{d.data?.person?[0].name??""}, {d.data?.person?[0].age}");

class Data {
    public PersonList? data { get; set; }
}

class PersonList
{
    public List<Person>? person { get; set; }
}

class Person
{
    public String? name { get; set; }
    public int age { get; set; }
}