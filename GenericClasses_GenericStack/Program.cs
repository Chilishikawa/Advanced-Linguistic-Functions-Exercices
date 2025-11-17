using System.Runtime.Intrinsics.X86;

namespace GenericClasses_GenericStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class GenericClass<T>
        {
            public List<T> List = new List<T>();
            public void Push(T element)
            {
                List.Add(element);
                Console.WriteLine(List);
            }

            public Pop()
            {

            }
        }
    }
}
