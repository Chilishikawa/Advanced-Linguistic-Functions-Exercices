using static MathematicalOperations.Program;

namespace MathematicalOperations
{
    public class Program
    {
        public delegate void ResultHandler(double value);
        static void Main(string[] args)
        {
            MathOperations ops = new MathOperations();
            ResultDisplay disp = new ResultDisplay();

            ops.AdditionPerformed += disp.Show;
            ops.SubtractionPerformed += disp.Show;
            ops.MultiplicationPerformed += disp.Show;
            ops.DivisionPerformed += disp.Show;

            while (true) {
                Console.WriteLine("Enter the first number:");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the second number:");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("What operation do you want to perform? (1. Addition, 2. Substraction, 3. Multiplication, 4. Division)");
                int z = int.Parse(Console.ReadLine());
                switch (z)
                {
                    case 1:
                        ops.Addition(x,y);
                        break;
                    case 2:
                        ops.Subtraction(x,y);
                        break;
                    case 3:
                        ops.Multiplication(x,y);
                        break;
                    case 4:
                        ops.Division(x,y);
                        break;
                }

                Console.WriteLine("End of operation, press 1 to perform another operation, 2 to exit the program.");
                int w = int.Parse(Console.ReadLine());

                if (w == 1) { continue; }
                else if (w == 2) { break; }
            }
        }
    }

    public class MathOperations
    {
        public event ResultHandler AdditionPerformed;
        public event ResultHandler SubtractionPerformed;
        public event ResultHandler MultiplicationPerformed;
        public event ResultHandler DivisionPerformed;

        public void Addition(int x, int y)
        {
            double r = x + y;

            AdditionPerformed?.Invoke(r);
        }

        public void Subtraction(int x, int y)
        {
            double r = x - y;

            SubtractionPerformed?.Invoke(r);
        }

        public void Multiplication(int x, int y)
        {
            double r = x * y;
            MultiplicationPerformed?.Invoke(r);
        }

        public void Division(int x, int y)
        {
            if(y != 0)
            {
                double r = x / y;
                DivisionPerformed?.Invoke(r);
            }
            else
            {
                Console.WriteLine("The divisor cannot be 0, try another operation.");
            }
        }
    }

    public class ResultDisplay
    {
        public void Show(double value)
        {
            Console.WriteLine("The result is: " + value);
        }
    }
}
