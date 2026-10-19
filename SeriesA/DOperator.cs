using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesA;

internal class DOperator
{
    public static void Arithmatic()
    {
        int x = 3;
        int y = 5;

        int add = x + y;
        int multiply = x * y;
        int devide = x / y;
        int subtract = x - y;
        int modulus = x % y;

        Console.WriteLine(add);
        Console.WriteLine(multiply);
        Console.WriteLine(devide);
        Console.WriteLine(subtract);
        Console.WriteLine(modulus);

        int number = 5;
        // number = number + 1
        Console.WriteLine("Post-Increment: " + number ++);
        number = 5;
        Console.WriteLine("Pre-Increment: " + ++number);

        //number = number - 1
        number = 5;
        Console.WriteLine("Post-Increment: " + number--);
        number = 5;
        Console.WriteLine("Post-Increment: " + --number);
    }

    public static void Assignment()
    {
        // Cascade
        int x, y, z;
        x = y = z = 5;

        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);

        // kemudahan penulisan aritmatika
        x += 2;
        Console.WriteLine(x);
        x -= 2;
        Console.WriteLine(x);
        x *= 2;
        Console.WriteLine(x);
        x /= 2;
        Console.WriteLine(x);
        x %= 2;
        Console.WriteLine(x);

    }

    public static void Logical()
    {
        int x = 3;
        int y = 5;

        // LOGIKAL AND
        // True & true = true
        // True & false = false
        // false & true = false
        // false & false = false
        bool condition = (x == 3) && (y == 5);  // cek kondisi true  or false
        Console.WriteLine(condition);

        // LOGIKAL OR
        // True | True = true
        // True | False = true
        // False | True = False
        // False | False = False

        // Logical negation
        // True > False
        // False > True
        condition = !(x == y);
        Console.WriteLine(condition);
    }
}
