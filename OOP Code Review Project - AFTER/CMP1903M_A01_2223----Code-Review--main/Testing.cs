using System;

namespace CMP1903M_A01_2223
{
    // Layout for the Testing Class
    class PackTest
    {
        static void Main(string[] args)
        {
            Pack pack = new Pack();

            // Tests the shuffleCardPack method with different shuffle numbers

            pack.shuffleCardPack(1);
            Console.WriteLine("After Fisher-Yates shuffle:");
            printPack(pack);

            pack.shuffleCardPack(2);
            Console.WriteLine("After Riffle shuffle:");
            printPack(pack);

            pack.shuffleCardPack(3);
            Console.WriteLine("After no shuffle:");
            printPack(pack);

            // Tests the deal and dealCard methods
            Console.WriteLine("Dealing one card:");
            pack.deal();

            Console.WriteLine("Dealing multiple cards:");
            pack.dealCard(1000);
            printPack(pack);

            Console.ReadLine();
        }

        
    }
}











