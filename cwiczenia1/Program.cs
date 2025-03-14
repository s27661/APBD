namespace cwiczenia1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (j == 9)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
            }
        }
    }
}