/*using System;

class Graph
{
    // Private fields for the interval and function values at a and b
    private double a, b;
    private double y_a, y_b;

    // Constructor to initialize the values of a and b
    public Graph(double a_val, double b_val)
    {
        a = a_val;
        b = b_val;
        y_a = 3 * a + 5; // y(a) = 3a + 5
        y_b = 3 * b + 5; // y(b) = 3b + 5
    }

    // Method to calculate the integral of y = 3x + 5 from a to b
    public double CalculateIntegral()
    {
        // Integral of 3x + 5 is (3/2)x^2 + 5x
        double integral_b = (3.0 / 2.0) * b * b + 5 * b;
        double integral_a = (3.0 / 2.0) * a * a + 5 * a;
        return integral_b - integral_a;
    }

    // Method to calculate the length of the segment of the function
    public double CalculateLength()
    {
        // Length of the segment (distance formula between (a, y(a)) and (b, y(b)))
        return Math.Sqrt(Math.Pow(b - a, 2) + Math.Pow(y_b - y_a, 2));
    }

    // Method to display the information about the object
    public void DisplayInfo()
    {
        Console.WriteLine($"Function: y = 3x + 5");
        Console.WriteLine($"Interval: [{a}, {b}]");
        Console.WriteLine($"y({a}) = {y_a}, y({b}) = {y_b}");
        Console.WriteLine($"Integral from {a} to {b}: {CalculateIntegral()}");
        Console.WriteLine($"Length of segment: {CalculateLength()}");
    }

    // Main method to interact with the user
    static void Main()
    {
        Console.Write("Enter the values for a and b: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());

        // Create the Graph object and display the info
        Graph graph = new Graph(a, b);
        graph.DisplayInfo();
    }
}
*/

/*using System;

public class ComplexNumber
{
    // Immutable fields to store real and imaginary parts of the complex number
    private readonly double real;
    private readonly double imaginary;

    // Private constructor to initialize the complex number with real and imaginary parts
    private ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    // Properties to get the real and imaginary parts
    public double Real => real;
    public double Imaginary => imaginary;

    // Property to calculate the modulus (magnitude) of the complex number
    public double Modulus => Math.Sqrt(real * real + imaginary * imaginary);

    // Property to calculate the argument (angle) of the complex number
    public double Argument => Math.Atan2(imaginary, real);

    // Static method to create a complex number from algebraic form (a + bi)
    public static ComplexNumber FromAlgebraicForm(double real, double imaginary)
    {
        return new ComplexNumber(real, imaginary);
    }

    // Static method to create a complex number from trigonometric form (r * (cosθ + i*sinθ))
    public static ComplexNumber FromTrigonometricForm(double modulus, double argument)
    {
        double real = modulus * Math.Cos(argument);
        double imaginary = modulus * Math.Sin(argument);
        return new ComplexNumber(real, imaginary);
    }

    // Method to add two complex numbers and return the result as a new ComplexNumber
    public ComplexNumber Add(ComplexNumber other)
    {
        double newReal = this.real + other.real;
        double newImaginary = this.imaginary + other.imaginary;
        return new ComplexNumber(newReal, newImaginary);
    }

    // Method to subtract two complex numbers and return the result as a new ComplexNumber
    public ComplexNumber Subtract(ComplexNumber other)
    {
        double newReal = this.real - other.real;
        double newImaginary = this.imaginary - other.imaginary;
        return new ComplexNumber(newReal, newImaginary);
    }

    // Method to display the complex number in a+bi format
    public void Display()
    {
        Console.WriteLine($"Complex Number: {real} + {imaginary}i");
        Console.WriteLine($"Modulus: {Modulus}");
        Console.WriteLine($"Argument (in radians): {Argument}");
    }

    public static void Main()
    {
        try
        {
            // Create two complex numbers using algebraic form
            ComplexNumber complex1 = ComplexNumber.FromAlgebraicForm(3, 4);
            ComplexNumber complex2 = ComplexNumber.FromAlgebraicForm(1, 2);

            // Display the complex numbers and their properties
            complex1.Display();
            complex2.Display();

            // Perform addition and subtraction
            ComplexNumber sum = complex1.Add(complex2);
            ComplexNumber difference = complex1.Subtract(complex2);

            Console.WriteLine("\nSum:");
            sum.Display();

            Console.WriteLine("\nDifference:");
            difference.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
*/

/*using System;

class BinaryString
{
    private string binaryValue;

    // Constructor that initializes the binary value, ensuring it's valid
    public BinaryString(string binary)
    {
        if (!IsValidBinary(binary))
        {
            throw new ArgumentException("The input is not a valid binary number.");
        }
        binaryValue = binary;
    }

    // Default constructor
    public BinaryString() : this("0") { }

    // Property to get the binary value
    public string BinaryValue
    {
        get { return binaryValue; }
        set
        {
            if (!IsValidBinary(value))
            {
                throw new ArgumentException("The input is not a valid binary number.");
            }
            binaryValue = value;
        }
    }

    // Method to check if a string is a valid binary number
    private bool IsValidBinary(string binary)
    {
        foreach (char c in binary)
        {
            if (c != '0' && c != '1')
            {
                return false;
            }
        }
        return true;
    }

    // Method to add two binary numbers
    public BinaryString Add(BinaryString other)
    {
        int num1 = Convert.ToInt32(this.binaryValue, 2);
        int num2 = Convert.ToInt32(other.binaryValue, 2);
        int sum = num1 + num2;
        return new BinaryString(Convert.ToString(sum, 2));
    }

    // Method to subtract two binary numbers
    public BinaryString Subtract(BinaryString other)
    {
        int num1 = Convert.ToInt32(this.binaryValue, 2);
        int num2 = Convert.ToInt32(other.binaryValue, 2);
        if (num1 < num2)
        {
            throw new InvalidOperationException("Cannot subtract a larger binary number from a smaller one.");
        }
        int difference = num1 - num2;
        return new BinaryString(Convert.ToString(difference, 2));
    }

    // Method to multiply two binary numbers
    public BinaryString Multiply(BinaryString other)
    {
        int num1 = Convert.ToInt32(this.binaryValue, 2);
        int num2 = Convert.ToInt32(other.binaryValue, 2);
        int product = num1 * num2;
        return new BinaryString(Convert.ToString(product, 2));
    }

    // Method to divide two binary numbers
    public BinaryString Divide(BinaryString other)
    {
        int num1 = Convert.ToInt32(this.binaryValue, 2);
        int num2 = Convert.ToInt32(other.binaryValue, 2);
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        int quotient = num1 / num2;
        return new BinaryString(Convert.ToString(quotient, 2));
    }

    // Method to display the binary string and its integer value
    public void DisplayInfo()
    {
        Console.WriteLine($"Binary Value: {binaryValue}");
        Console.WriteLine($"Integer Value: {Convert.ToInt32(binaryValue, 2)}");
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter the first binary number: ");
            string firstBinary = Console.ReadLine();
            BinaryString bin1 = new BinaryString(firstBinary);

            Console.Write("Enter the second binary number: ");
            string secondBinary = Console.ReadLine();
            BinaryString bin2 = new BinaryString(secondBinary);

            // Demonstrating operations
            BinaryString sum = bin1.Add(bin2);
            Console.WriteLine($"Sum: {sum.BinaryValue}");

            BinaryString difference = bin1.Subtract(bin2);
            Console.WriteLine($"Difference: {difference.BinaryValue}");

            BinaryString product = bin1.Multiply(bin2);
            Console.WriteLine($"Product: {product.BinaryValue}");

            BinaryString quotient = bin1.Divide(bin2);
            Console.WriteLine($"Quotient: {quotient.BinaryValue}");

            // Displaying information
            bin1.DisplayInfo();
            bin2.DisplayInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
*/

