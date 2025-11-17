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
                Console.WriteLine ("Que desea hacer:");
                Console.WriteLine("1. Agregar una nueva persona.");
                Console.WriteLine("2. Mostrar la lista de personas registradas.");
                Console.WriteLine("3. Filtrar por edad mayor de 30 años.");
                Console.WriteLine("4. Ordenar por nombre.");
                Console.WriteLine("5. Calcular el salario medio");
                Console.WriteLine("6. Calcular la edad total");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "2":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("No hay personas registradas.");
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
                        Console.WriteLine("Introduzca datos de una nueva persona ->");
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
                            Console.WriteLine("No hay personas registradas.");
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
                            Console.WriteLine("No hay personas registradas.");
                            Console.WriteLine();
                        }
                        else
                        {
                            var  ordered  = personList.OrderBy(p => p.Name);
                            foreach (Person p in ordered)
                            {
                                Console.WriteLine($"Person: name: {p.Name}, age: {p.Age}, salary: {p.Salary}");
                            }
                        }
                        break;
                    case "5":
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("No hay personas registradas.");
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
                            Console.WriteLine("No hay personas registradas.");
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
