using System;

class Program
{
    static void Main()
    {

        double pi = -1 * Math.PI;
        double pi2 = Math.PI / 2;

        for (double x = pi; x < pi2; x += 0.2)
        {

            double y;

            if (x > 2.5)
            {
                y = x + 1;
                Console.WriteLine($"y = {y:F4}");
            }

            else if (0 <= x && x <= 2.5)
            {
                y = 1 - Math.Pow(x, 5);
                Console.WriteLine($"y = {y:F4}");
            }

            else if (x < 0)
            {
                y = x * Math.Log(Math.Abs(Math.Cos(x)));
                Console.WriteLine($"y = {y:F4}");
            }

        }
    }
}