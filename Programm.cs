using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Parentage { get; set; }
    public List<Person> Children { get; } = new List<Person>();

    public Person(string name, DateTime birthDate, string parentage)
    {
        Name = name;
        BirthDate = birthDate;
        Parentage = parentage;
    }

    public void AddChild(Person child)
    {
        Children.Add(child);
    }

    public override string ToString()
    {
        return $"{Parentage} - {Name}  (родился {BirthDate.ToShortDateString()})";
    }
}

class GenealogyTree
{
    public Person Root { get; set; }

    public GenealogyTree(Person root)
    {
        Root = root;
    }

    public void PrintTree()
    {
        PrintTree(Root, 0);
    }

    private void PrintTree(Person person, int level)
    {
        Console.WriteLine(new string(' ', level * 4) + person);
        foreach (var child in person.Children)
        {
            PrintTree(child, level + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var rootPerson = new Person("Иван Иванович", new DateTime(1970, 5, 15), "Дед");
        var tree = new GenealogyTree(rootPerson);

        var child1 = new Person("Анна Ивановна", new DateTime(1995, 8, 25), "Мать");
        var child2 = new Person("Петр Иванович", new DateTime(1998, 3, 12), "Отец");

        rootPerson.AddChild(child1);
        rootPerson.AddChild(child2);

        var grandchild1 = new Person("Мария", new DateTime(2022, 4, 10), "Дочь");
        child1.AddChild(grandchild1);

        tree.PrintTree();
    }
}
