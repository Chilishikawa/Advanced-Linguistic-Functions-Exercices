using System.Runtime.Intrinsics.X86;

namespace GenericStackes_GenericStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericStack<int> intGenericStack = new GenericStack<int>();
            intGenericStack.Push(1);
            intGenericStack.Push(2);
            intGenericStack.Push(3);
            intGenericStack.Display();
            Console.WriteLine($"Extracted element: {intGenericStack.Pop()}");

            GenericStack<string> stringGenericStack = new GenericStack<string>();
            stringGenericStack.Push("uno");
            stringGenericStack.Push("dos");
            stringGenericStack.Push("tres");
            stringGenericStack.Display();
            Console.WriteLine($"Extracted element: {stringGenericStack.Pop()}");

            GenericStack<Person> personGenericStack = new GenericStack<Person>();
            personGenericStack.Push(new Person ( 1, "Gon", 1500000 ));
            personGenericStack.Push(new Person ( 2, "Killua", 1400000 ));
            personGenericStack.Push(new Person ( 3, "Kurapica", 1600000 ));
            personGenericStack.Display();
            Console.WriteLine($"Extracted element: {personGenericStack.Pop()}");
        }

        public class GenericStack<T>
        {
            private List<T> List = new List<T>();
            public void Push(T element)
            {
                List.Add(element);
            }

            public T Pop()
            {
                if (List.Count() == 0)
                {
                    throw new InvalidOperationException("The stack has no elements");
                }

                T poppedItem = List[List.Count - 1];
                List.RemoveAt(List.Count - 1);
                return poppedItem;
            }

            public void Display()
            {
                foreach (T element in List) {
                    Console.WriteLine(element);
                }
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; } 
            public int Salary { get; set; }

            public Person (int id, string name, int salary)
            {
                Id = id;
                Name = name;
                Salary = salary;
            }

            public override string ToString()
            {
                return $"{Id} - {Name} - {Salary}";
            }
        }
    }
}
