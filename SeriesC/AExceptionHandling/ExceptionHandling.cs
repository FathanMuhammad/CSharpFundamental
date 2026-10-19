namespace SeriesC.AExceptionHandling;

/* Exception Handling adalah error yang terjadi saat program berjalan (Runtime), bukan saat compile
 * Jika tidak ditangani, program akan berhenti atau crash!
 * 
 * Semua Exception adalah class turunan dari System.Exception
 * 
 * Exception Type	Description
 * System.ArithmeticException	A base class for exceptions that occur during arithmetic operations, such as System.DivideByZeroException and System.OverflowException.
 * System.ArrayTypeMismatchException	Thrown when a store into an array fails because the type of the stored element is incompatible with the type of the array.
 * System.DivideByZeroException	Thrown when an attempt to divide an integral value by zero occurs.
 * System.IndexOutOfRangeException	Thrown when an attempt to index an array via an index that is less than zero or outside the bounds of the array.
 * System.InvalidCastException	Thrown when an explicit conversion from a base type or interface to a derived type fails at run-time.
 * System.InvalidOperationException	Thrown when a method call is invalid for the object’s current state.
 * System.NullReferenceException	Thrown when a null reference is used in a way that causes the referenced object to be required.
 * System.OutOfMemoryException	Thrown when an attempt to allocate memory (via new) fails.
 * System.OverflowException	Thrown when an arithmetic operation in a checked context overflows.
 * System.StackOverflowException	Thrown when the execution stack is exhausted by having too many pending calls; typically indicative of very deep or unbounded recursion.
 * System.TypeInitializationException	Thrown when a static constructor or static field initializer throws an exception, and no catch clause exists to catch it.

 */



public class ExceptionHandling
{
    public static void TryCatchFinally()
    {
        string[] inputs = { "4", "0", "abc" };

        foreach (string input in inputs)
        {
            Console.WriteLine("Input: "+ input);

            //kode yang berpotensi error
            try
            {
                int divisor = int.Parse(input);
                int result = 100 / divisor;
                Console.WriteLine("Result :" + result);
            }
            // Catch, akan dijalankan jika terjadi error, bisa lebih dari satu
            catch (FormatException ex)
            {
                Console.WriteLine("==========");
                Console.WriteLine("Input harus berupa angka");
                Console.WriteLine(ex.Message);
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("==========");
                Console.WriteLine("Tidak bisa membagi dengan nol");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Lain: " + ex.Message);
                Console.WriteLine("==========");
            }
            //finally { } / akan selalu dijalankan jadi gaperlu ditulus terkadang

            finally
            {
                //Console.WriteLine("Proses Selsai");
            }


            /*Input: 4
            Result :25
            Input: 0
            ==========
            Tidak bisa membagi dengan nol
            Attempted to divide by zero.
            Input: abc
            ==========
            Input harus berupa angka
            The input string 'abc' was not in a correct format. 

            Kenapa resultnya gini
             */
            /*
             * Message, pesan error
             * StackTrace, lokasi terjadinya error (Class, method, baris)
             * GetType, jenis exception
             */

        }
    }

    public static void OtherException()
    {
        //Null Ref
        try
        {
            string[] names = new string[2];
            Console.WriteLine(names[0].Length);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            
        }

        //Invalid cast Exc
        try
        {
            object value = "seratus";
            int number = (int)value;
            Console.WriteLine(number);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("================");
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            
        }

        //overflow Exception
        try
        {
            int big = 300;
            byte small = Convert.ToByte(big);
            Console.WriteLine(small);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("================");
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);

        }

    }

    public static void ThrowKeyword()
    {
        //throw melempar exception secara sengaja
        //dipakai saat data tidak sesuai aturan program, walaupun menurut C# itu nggak error
        //format: throw new JenisException("pesan");

        //# throw biasa
        try
        {
            SetAge(20);
            SetAge(-5);
            SetAge(30);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Re-throw
        try
        {
            int average = CalculateAverage(100, 0);
            Console.WriteLine("Average :"+ average);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("error diterima oleh re-throw"+ ex.Message);
        }
    }

    public static void SetAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "must be greater than or equal than zero");
        }

        Console.WriteLine("Umur : "+ age);
    }

    public static int CalculateAverage(int total, int count)
    {
        try
        {
            return total / count;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("[Log] gagal menghitung rata rata");
            throw; // cukup lempar keyword supaya stack trace tetap utuh
        }
    }

}
