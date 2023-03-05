using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CMP1903M_A01_2223

{
    class Pack : Card
    {
        // The Pack class creates a pack of cards, shuffles it, and deals cards from it.
        const int numberOfCards = 52;
        
        

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
        // The setUpDeck method creates a pack of cards, shuffles it, and deals cards from it.
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

            Console.WriteLine("Hey, choose a shuffle. 1 for Fisher-Yates shuffle method, 2 for Riffle shuffle method, or 3 for No shuffle.");
            int shuffleNumber = Convert.ToInt32(Console.ReadLine());
            
            shuffleCardPack(shuffleNumber);
            while (numberOfCards > 0)
            {   
                Console.WriteLine("What is your desired deal method? (1 for one card, 2 for multiple cards)");
                int dealNumber = Convert.ToInt32(Console.ReadLine());
                if (dealNumber == 1)
                {
                    deal();
                }
                else if (dealNumber == 2)
                {
                    Console.WriteLine("How many cards do you want to deal?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    dealCard(amount);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
               
                //show pack
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
            
            //Type 2: Riffle shuffle method

            else if (typeOfShuffle == 2)
            {
                Random rnd = new Random();
                int j = rnd.Next(0, pack.Count);
                for (int i = 0; i < pack.Count; i++)
                {
                    if (i < j)
                    {
                        Card temp = pack[i];
                        pack[i] = pack[j];
                        pack[j] = temp;
                    }
                    else
                    {
                        j = rnd.Next(0, pack.Count);
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
       

        

    



   


