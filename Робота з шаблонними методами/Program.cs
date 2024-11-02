namespace Робота_з_шаблонними_методами
{
    public abstract class Operation
    {
        // Метод для розрахунку операції
        public abstract double Calculate(double a, double b);

        // Метод для логування операції
        protected virtual void Log(double a, double b, double result, string operation)
        {
            Console.WriteLine($"{a} {operation} {b} = {result}");
        }
    }

    // Клас для додавання
    public class Sum : Operation
    {
        public override double Calculate(double a, double b)
        {
            double result = a + b;
            Log(a, b, result, "+");
            return result;
        }
    }

    // Клас для ділення
    public class Divide : Operation
    {
        public override double Calculate(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("На нуль ділити не можна.");
            }

            double result = a / b;
            Log(a, b, result, "/");
            return result;
        }
    }

    // Клас для множення
    public class Multiply : Operation
    {
        public override double Calculate(double a, double b)
        {
            double result = a * b;
            Log(a, b, result, "*");
            return result;
        }
    }

    // Основна програма
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Введіть перше число:");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Введіть друге число:");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("Виберіть операцію (+, -, *):");
                string operation = Console.ReadLine();

                Operation op;

                switch (operation)
                {
                    case "+":
                        op = new Sum();
                        break;
                    case "/":
                        op = new Divide();
                        break;
                    case "*":
                        op = new Multiply();
                        break;
                    default:
                        Console.WriteLine("Неправильна операція.");
                        return;
                }

                // Обчислення та виведення результату
                op.Calculate(a, b);
            }
            catch (FormatException)
            {
                Console.WriteLine("Будь ласка, введіть правильне число.");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
