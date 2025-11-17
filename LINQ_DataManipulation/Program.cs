namespace LINQ_DataManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("1. Add a new person.");
                Console.WriteLine("2. Show the list of registered people.");
                Console.WriteLine("3. Filter by age greater than 30 years.");
                Console.WriteLine("4. Sort by name.");
                Console.WriteLine("5. Calculate the average salary.");
                Console.WriteLine("6. Calculate the total age.");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "2":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no registered people.");
                            Console.WriteLine();
                        }
                        else
                        {
                            foreach (Person p in personList)
                            {
                                Console.WriteLine($"Person: name: {p.Name}, age: {p.Age}, salary: {p.Salary}");
                            }
                        }
                        break;

                    case "1":
                        Console.WriteLine("Enter data for a new person ->");
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Age:");
                        string age = Console.ReadLine();
                        Console.WriteLine("Salary:");
                        string salary = Console.ReadLine();

                        var newPerson = new Person
                        {
                            Name = name,
                            Age = int.Parse(age),
                            Salary = int.Parse(salary)
                        };

                        personList.Add(newPerson);
                        Console.WriteLine();
                        break;

                    case "3":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no registered people.");
                            Console.WriteLine();
                        }
                        else
                        {
                            var over30 = personList.Where(p => p.Age > 30);
                            foreach (Person p in over30)
                            {
                                Console.WriteLine($"Person: name: {p.Name}, age: {p.Age}, salary: {p.Salary}");
                            }
                        }
                        break;

                    case "4":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no registered people.");
                            Console.WriteLine();
                        }
                        else
                        {
                            var ordered = personList.OrderBy(p => p.Name);
                            foreach (Person p in ordered)
                            {
                                Console.WriteLine($"Person: name: {p.Name}, age: {p.Age}, salary: {p.Salary}");
                            }
                        }
                        break;

                    case "5":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no registered people.");
                            Console.WriteLine();
                        }
                        else
                        {
                            var averageSalary = personList.Average(p => p.Salary);
                            Console.WriteLine($"Average salary is: {averageSalary}");
                        }
                        break;

                    case "6":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no registered people.");
                            Console.WriteLine();
                        }
                        else
                        {
                            var totalAge = personList.Sum(p => p.Age);
                            Console.WriteLine($"Total age is: {totalAge}");
                        }
                        break;
                }
            }

        }

        public class Person
        {
            public string Name { get; set; }   
            public int Age { get; set; }
            public int Salary { get; set; } 
        }
    }
}
