namespace SeriesA
{
    //Mengulang statement sampai kondisi terakhir. false, kondisi awal sudah diketahui
    // for-loop
    // while - loop
    internal class FLooping
    {
        public static void ForLoop()
        {
            // FORMAT
            // for (initialization; condition; opeartor increment/decrement) {
            // statement
            // }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Counter : " + i);
            }

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numbers)
            {
                Console.WriteLine("No : " + number);
            }
        }

        // whileLoop adalah ketika kondisi tidak menentu atau dinamis
        public static void WhileLoop() 
            {
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine("Counter : " + counter);
                counter++;
            }

            counter = 0;
            do
            {
                Console.WriteLine("Counter : " + counter);
                counter++;
            } while (counter < 10);
        }
    }
}
