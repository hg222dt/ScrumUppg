﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;


namespace ScrumUppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            int memberCounter = 0;
            int i;
            List<Member> members = new List<Member>();

            OpenAllFromFile(members);

            if (members.Count > 0)
            {
                memberCounter = members[members.Count - 1]._memberNumber;
            }

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
                  
                    SaveAllToFile(members);
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

        public static void SaveAllToFile(List<Member> members)
        {
            try
            {
                using (FileStream fs = new FileStream("members.txt", FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        foreach (Member m in members)
                        {
                            writer.WriteLine("[Medlem]");
                            writer.WriteLine("[Förnamn]");
                            writer.WriteLine("{0}", m._firstName);
                            writer.WriteLine("[Efternamn]");
                            writer.WriteLine("{0}", m._lastName);
                            writer.WriteLine("[Telefonnummer]");
                            writer.WriteLine("{0}", m._phoneNumber);
                            writer.WriteLine("[Medlemsnummer]");
                            writer.WriteLine("{0}", m._memberNumber);
                        }

                    }
                }
            }
            catch 
            { 
                Console.WriteLine("Nu blev något fel!"); 
            }
        }

        //Ska öppna textdokumentet och läsa in all data, och därefter lägga detta i objekt som i sin tur läggs i lista i korrekt ordning.


        public static void OpenAllFromFile(List<Member> members)
        {
            string line;
            int choser = 5;
            int lastMemberNumber = 0;
            int counter = 0;

            try
            {
                using (StreamReader reader = new StreamReader("members.txt"))
                {
                    do
                    {
                        line = reader.ReadLine();
                        
                        if(line == "[Medlem]") {
                            members.Add(new Member());
                            counter++;
                        }
                     
                        if (line == "[Förnamn]")
                        {
                            choser = 0;
                        }

                        else if (line == "[Efternamn]")
                        {
                            choser = 1;
                        }

                        else if (line == "[Telefonnummer]")
                        {
                            choser = 2;
                        }

                        else if (line == "[Medlemsnummer]")
                        {
                            choser = 3;
                        }


                        if (choser == 0 && line != "[Förnamn]")
                        {
                            members[counter-1]._firstName = line;
                            choser = 5;
                        }

                        else if (choser == 1 && line != "[Efternamn]")
                        {
                            members[counter-1]._lastName = line;
                            choser = 5;
                        }

                        else if (choser == 2 && line != "[Telefonnummer]")
                        {
                            members[counter-1]._phoneNumber = int.Parse(line);
                            choser = 5;
                        }

                        else if (choser == 3 && line != "[Medlemsnummer]")
                        {
                            members[counter-1]._memberNumber = int.Parse(line);
                            //lastMemberNumber = int.Parse(line);
                            choser = 5;
                        }

                    } while (line != null);

                }
            }
            catch
            {
                Console.WriteLine("Nu blev något fel med inläsningen!");
            }
        }
    }
}