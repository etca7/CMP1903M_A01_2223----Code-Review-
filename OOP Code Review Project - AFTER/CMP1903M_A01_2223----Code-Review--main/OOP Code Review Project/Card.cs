using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        // Enum for the suits and values of the cards (Additional)
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }
        // Enum for the suits and values of the cards (Additional)
        public enum Value 
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
       
        public Value MyValue { get; set; }
        public Suit MySuit { get; set; }
    }
}

   


