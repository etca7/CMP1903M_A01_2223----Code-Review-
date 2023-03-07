using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223

    // The inheritence of the Card calls proves that I have utilised Abstraction
{
    class Pack : Card
    {
        // The Pack class creates a pack of cards, shuffles it, and deals cards from it.

        const int numberOfCards = 52;
                
        // Another example of Abstraction, allows the user to access the pack of cards without knowing its implementation in future usage.
        List<Card> pack;

        
        public Pack()

        // The card pack is initialised here

        {
            pack = new List<Card>();
  
            for (int i = 0; i < numberOfCards; i++)
            {
                pack.Add(new Card());
            }
        }
    public Card[] getPack
        {
            get
            {
                return pack.ToArray();
            }
        }
        // The setUpDeck method creates a pack of cards, shuffles it, and deals cards from it. (Additional method)

        public void setUpDeck() 
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    pack[i] = new Card();
                    pack[i].MySuit = s;
                    pack[i].MyValue = v;
                    i++;
                }
            }
            // The pack is shuffled based on user input, the validInput bool (added after Code Review) creates a loop that runs as long as the input is valid.

            int shuffleNumber = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Hey, choose a shuffle. 1 for Fisher-Yates shuffle method, 2 for Riffle shuffle method, or 3 for No shuffle.");
                string input = Console.ReadLine();
                if (int.TryParse(input, out shuffleNumber) && (shuffleNumber == 1 || shuffleNumber == 2 || shuffleNumber == 3))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }          
            shuffleCardPack(shuffleNumber); // Additional method

            // Deals a certain amount of cards based on user input

            while (numberOfCards > 0)
            {
                int dealNumber = 0;
                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("What is your desired deal method? (1 for one card, 2 for multiple cards)");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out dealNumber) && (dealNumber == 1 || dealNumber == 2))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    }
                }

                if (dealNumber == 1)
                {
                    deal();
                }
                else if (dealNumber == 2)
                {
                    validInput = false;
                    while (!validInput)
                    {
                        Console.WriteLine("How many cards do you want to deal?");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int amount) && amount > 0 && amount <= numberOfCards)
                        {
                            dealCard(amount);
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a positive integer that is not greater than the number of remaining cards."); // Added after Code Review, helps the user to not get an error after reaching the end of the pack
                        }
                    }
                }

                // Shows pack              
                foreach (Card c in pack)
                {
                    Console.WriteLine(c.MyValue + " of " + c.MySuit);
                }
            }
        }
        // The deal method deals one card from the pack.
        public bool shuffleCardPack(int typeOfShuffle)   
        {
            // Shuffles the pack based on the type of shuffle if shuffleCardPack is true


            // Type 1: Fisher-Yates shuffle method

            if (typeOfShuffle == 1)
            {
                Random rnd = new Random();
                for (int i = 0; i < numberOfCards; i++)
                {
                    int j = rnd.Next(i + 1);
                    Card temp = pack[i];
                    pack[i] = pack[j];
                    pack[j] = temp;
                }
                return true;
            }
            
            //Type 2: Riffle shuffle method, the pack is split in half, the cards are added one by one
            // then the for loop is used to run the method multiple times to ensure better randomisation (added after Code Review)

            else if (typeOfShuffle == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    List<Card> pack1 = new List<Card>();
                    List<Card> pack2 = new List<Card>();
                    for (int j = 0; j < numberOfCards; j++)
                    {
                        if (j < numberOfCards / 2)
                        {
                            pack1.Add(pack[j]);
                        }
                        else
                        {
                            pack2.Add(pack[j]);
                        }
                    }
                    pack.Clear();
                    for (int k = 0; k < numberOfCards; k++)
                    {
                        if (k % 2 == 0)
                        {
                            pack.Add(pack1[k / 2]);
                        }
                        else
                        {
                            pack.Add(pack2[k / 2]);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        public Card deal()
        {
            // Asks the user if the wants to deal one card from the pack and then removes it
            Console.WriteLine("Are you sure you want to deal a card? (Yes/No)");
            
            ;
            // if Yes or yes, deal a card
            bool isYes = Console.ReadLine().ToLower() == "yes";
            if (isYes)
            {
                Card dealtCard = pack[0];
                pack.RemoveAt(0);
                return dealtCard;
            }
            else
            {
                return null;
            }
               
        }
        
        public List<Card> dealCard(int amount)
        {
            // Asks the user if he wants to deal more cards, the number of cards is specified by 'amount'
            // The cards are then removed from the pack and returned as a list
            Console.WriteLine("Are you sure you want to deal " + amount + " (Yes/No)");
            bool isYes = Console.ReadLine().ToLower() == "yes";
            if (isYes)
            {
                List<Card> dealtCards = new List<Card>();
                for (int i = 0; i < amount; i++)
                {
                    dealtCards.Add(pack[0]);
                    pack.RemoveAt(0);
                }
                return dealtCards;
            }
            else
            {
                return null;
            }
        }
    }
}
       

        

    



   


