// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CMP1903M_A01_2223
{
    // The Program class works as a Testing class, it creates a Pack class, chooses a shuffle and a deal method based on user input, and then prints the pack. 
    // If any tests need to be conducted, a copy of Pack.cs is present.
    class Program 
    {
        static void Main(string[] args)
        {
 
           // print Pack class

            Pack pack = new Pack();
            pack.setUpDeck();
           
            Card[] cards = pack.getPack;

            foreach (Card c in cards)
            {
                Console.WriteLine(c.MyValue + " of " + c.MySuit);
            }
            
            
        
        



            

            

        }

        

        }

        
        }
        

        
        
    


   


