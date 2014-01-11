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
            int memberCounter = 0;
            int i;
            List<Member> members = new List<Member>();

            do
            {
                Member member, fetchedMember;
                Console.WriteLine("1. Skapa ny medlem.");
                Console.WriteLine("2. Ladda alla medlemmar.");
                Console.WriteLine("\n0. Avsluta.");

                Console.Write("Välj alternativ: ");
                i = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    memberCounter++;
                    member = createNewMember(memberCounter);
                    members.Add(member);
                    /*
                    Console.WriteLine("Förnamnet på medlem är: {0}", member._firstName);
                    Console.WriteLine("Efternamnet på medlem är: {0}", member._lastName);
                    Console.WriteLine("Telefonnummret till medlem är: {0}", member._phoneNumber);
                    Console.WriteLine("Medlemsnumret är: {0}", member._memberNumber);
                    */
                }

                if (i == 2)
                {
                    Console.Write("Skriv in medlemsnummer för önskad medlem: ");
                    int v = int.Parse(Console.ReadLine());

                     fetchedMember = getMember(members, v);

                     Console.WriteLine("Förnamnet på medlem är: {0}", fetchedMember._firstName);
                     Console.WriteLine("Efternamnet på medlem är: {0}", fetchedMember._lastName);
                     Console.WriteLine("Telefonnummret till medlem är: {0}", fetchedMember._phoneNumber);
                     Console.WriteLine("Medlemsnumret är: {0}", fetchedMember._memberNumber);
                     
                }

            } while (i != 0);
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

        public static Member getMember(List<Member> members, int memberNumber)
        {
            Member member = members[memberNumber - 1];

            return member;
        }
    }
}


//Gör så att det går att spara alla objekt/medlemmar i en lista.
//Gör så att det sparas till textfil