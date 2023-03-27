// GroupBy<TSource,TKey> (Func<TSource,TKey> keySelector)

Person[] people =
{
    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
};

var companies = people.GroupBy(p => p.Company);

foreach (var company in companies)
{
    Console.WriteLine(company.Key);

    foreach (var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine(); 
}
Console.WriteLine("------------------------------");

// subquery

var companies2 = people
                    .GroupBy(p => p.Company)
                    .Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Count(),
                        Employees = g.Select(p => p)
                    });
foreach (var company in companies2)
{
    Console.WriteLine($"{company.Name} : {company.Count}");
    foreach (var employee in company.Employees)
    {
        Console.WriteLine(employee.Name);
    }
    Console.WriteLine(); 
}

Console.ReadKey();

record class Person(string Name, string Company);


