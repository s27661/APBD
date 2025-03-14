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

            var p1 = new Person(7, "Tomasz Hajto", 45);

            string p1string = p1.ToString();
            Console.WriteLine(p1string);


            var avg = countAvg([3, 6, 7, 1, 2, 8]);
            Console.WriteLine(avg);

            var max = selectMax([3, 6, 7, 1, 2, 8]);
            Console.WriteLine(max);


        }
    
        static double countAvg(int[] numbers)
        {
            return numbers.Average(x => x);
        }
        static int selectMax(int[] numbers)
        {
            return numbers.Max(x => x);
        }
    
    
    
    
    
    
    
    
    }
}