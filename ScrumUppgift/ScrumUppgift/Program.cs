using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumUppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Create new member
            //anropa metod som skapar ett nytt member-objekt.
            //be om indata och placera i skapat objekt

            int memberCounter = 0;
            int i;

            do
            {
                Member member;
                Console.WriteLine("1. Skapa ny medlem.");
                Console.Write("Välj alternativ: ");
                i = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    memberCounter++;
                    member = createNewMember(memberCounter);

                    Console.WriteLine("Förnamnet på medlem är: {0}", member._firstName);
                    Console.WriteLine("Efternamnet på medlem är: {0}", member._lastName);
                    Console.WriteLine("Telefonnummret till medlem är: {0}", member._phoneNumber);
                    Console.WriteLine("Medlemsnumret är: {0}", member._memberNumber);
                }
            } while (i == 1);
        }

        public static Member createNewMember(int memberCounter)
        {
            Member member = new Member();

            Console.WriteLine("Mata in förnamn: ");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Mata in efternamn: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Mata in Telefonnummer: ");
            int phoneNumber = int.Parse(Console.ReadLine());

            member._firstName = firstName;
            member._lastName = lastName;
            member._phoneNumber = phoneNumber;
            member._memberNumber = memberCounter;

            return member;
        }
    }
}
