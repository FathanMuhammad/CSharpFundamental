namespace SeriesA;

internal class CNumeric
{
    // byte > short > int > long > float > double    HIREARKI
    static byte byteType = 5;
    static short shortType = 5;
    static int intType = 5;
    static long longType = 5;
    static float floatType = 5;
    static double doubleType = 5;


    public static void toDouble()
    {
        double toDouble;
        toDouble = byteType;
        toDouble = shortType;
        toDouble = intType;
        toDouble = longType;
        toDouble = floatType;
        toDouble = doubleType;
    }

    public static void toFloat()
    {
        float toFloat;
        toFloat = byteType;
        toFloat = shortType;
        toFloat = intType;
        toFloat = longType;
        toFloat = floatType;
        //toFloat = doubleType; //Float gabisa nampung double karna hirearki
    }

    public static void toLong ()
    {
        long toLong;
        toLong  = byteType;
        toLong = shortType;
        toLong = intType;
        toLong = longType;
        //toLong = floatType;
        //toLong = doubleType;
    }

    public static void toInt()
    {
        int toInt;
        toInt = byteType;
        toInt = shortType;
        toInt = intType;
        //toInt = longType;
        //toInt = floatType;
        //toInt = doubleType;
    }

    public static void toShort()
    {
        short toShort;
        toShort = byteType;
        toShort = shortType;
        //toShort = intType;
        //toShort = longType;
        //toShort = floatType;
        //toShort = doubleType;
    }

    public static void toByte()
    {
        byte toByte;
        //toByte = byteType;
        //toByte = shortType;
        //toByte = intType;
        //toByte = longType;
        //toByte = floatType;
        //toByte = doubleType;
    }

    public static void Conversion()
    {
        long l1 = 500L;
        long l2 = 500;

        int i2 = (int)l1; // Convert with Cast
        int i3 = Convert.ToInt32(l1); // Convert with parsing

        Console.WriteLine(i2);
        Console.WriteLine(i3);
    }

}
