using System;
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
        //Metod som kör programmet.
        static void Main(string[] args)
        {
            //Räknare som räknar antalet medlemmar, och tilldelar nya medlemmar sitt värde.
            int memberCounter = 0;
            int i = 6;
            bool errInput = false;
            
            //Lista som samalr alla medlems-objekt.
            List<Member> members = new List<Member>();

            //Anrop av metod som laddar data i textfil, innehållandes medlemsuppgifter
            OpenAllFromFile(members);

            //Iteration som genomförs om medlemslistan innehåller medlemmar
            if (members.Count > 0)
            {
                //Medlemsräknaren sätts till den siste medlemmens medlemsnummer.
                memberCounter = members[members.Count - 1]._memberNumber;
            }

            //Loop som körs så länge användaren inte väljer att avsluta programmet.
            do
            {
                Member member;
                Console.Clear();
                Console.WriteLine("================");
                Console.WriteLine("Medlemsregister!");
                Console.WriteLine("================");
                Console.WriteLine();
                Console.WriteLine("1. Skapa ny medlem");
                Console.WriteLine("2. Visa medlem");
                Console.WriteLine("3. Visa alla medlemmar");
                Console.WriteLine("4. Redigera medlem");
                Console.WriteLine("5. Radera medlem");
                Console.WriteLine();
                Console.WriteLine("0. Avsluta");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Välj alternativ: ");
                
                //felhantering för om användaren inte matar in ett heltal mellan 0 och 5
                do{
                    errInput = false;
                    try
                    {
                        i = int.Parse(Console.ReadLine());
                        if(i < 0 || i > 5){
                            errInput = true;
                        }
                    }
                    catch(ArgumentException)
                    {
                        errInput = true;
                    }

                    if(errInput){
                        Console.WriteLine();
                        Console.Write("Ett heltal mellan 0 - 5 måste matas in. Ange nytt heltal: ");
                    }
                }while(errInput);


                Console.WriteLine();

                //Menyval 1 - Lägg till medlem
                if (i == 1)
                {
                    Console.Clear();
                    Console.WriteLine("================");
                    Console.WriteLine("Lägg till ny medlem");
                    Console.WriteLine("================");
                    Console.WriteLine();

                    //Medlemsräknaren adderas 1
                    memberCounter++;

                    //anrop görs för att skapa ny medlem. medlems-objekt returneras och kopplas till referens.
                    member = createNewMember(memberCounter);

                    //nya medlemsobjktet adderas till listan innehållandes medlemsobjekt.
                    members.Add(member);
                  
                    //Anrop till metod som sparar listan med medlemmar.
                    SaveAllToFile(members);

                    Console.WriteLine();
                    Console.WriteLine("Medlem sparad! Tryck valfri tangent för att återgå...");
                    Console.ReadLine();
                }

                //Menyval 2 - Visa specifik medlem
                if (i == 2)
                {
                    //Iteration körs om medlemsantalet i medlemsregistret är mer än 0
                    if (members.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("================");
                        Console.WriteLine("Visa medlem!");
                        Console.WriteLine("================");
                        Console.WriteLine();

                        Console.Write("Skriv in medlemsnummer för önskad medlem [1 - {0}, Avbryt: 0]: ", members.Count);
                        int v = int.Parse(Console.ReadLine());

                        if (v != 0)
                        {
                            //Anrop görs till metod för att rå returnerat specifik medlem.
                            getMember(members, v, false);
                        }
                        Console.WriteLine("Tryck valfri tangent för att återgå...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Det finns inga medlemmar i registret.");
                    }
                }

                //Menyval 3 - Visa alla medlemmar
                if (i == 3)
                {
                    //Iteration körs om antal medlemmar är mer än 0 i medlemsregistret.
                    if (members.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Medlemsregister! Visa alla medlemmar.");
                        Console.WriteLine();
                        int count = 1;

                        //Loop som körs så många gånger som det finns medlemmar i registret.
                        foreach (Member memberShow in members)
                        {
                            //Medlem anropas från metod som hanterar medlemmar från registret.
                            getMember(members, count, false);
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Det finns tyvärr inga medlemmar i registret.");
                    }

                    Console.WriteLine("Tryck valfri tangent för att återgå...");
                    Console.ReadLine();
                }

                //Menyval 4 - Redigera medlem
                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine("================");
                    Console.WriteLine("Redigera medlem!");
                    Console.WriteLine("================");
                    Console.WriteLine();

                    string loop = "j";
                    Console.Write("Ange medlemsnummer[1 - {0}, Avbryt: 0]: ", members.Count);
                    int v = int.Parse(Console.ReadLine());
                    int r = 0;

                    //Felhantering för om inatning inte är ett heltal mellan 0 och antalet medlemmar.
                    do
                    {
                        if (v != 0)
                        {   
                            //Anrop efter specifik medlem via metod som hanterar detta.
                            getMember(members, v, true);
                            
                            Console.WriteLine();
                            Console.Write("Välj vilken data du vill redigera [1 - 3, Avbryt: 0]: ");
                            r = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            //Sats som hanterar senaste menyvalet.
                            switch (r)
                            {
                                case 1:
                                    Console.Write("Ange nytt förnamn: ");

                                    //Inmatning sker, och data skrivs till egenskap i angiven variabel.
                                    members[v-1]._firstName = Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Write("Ange nytt efternamn: ");

                                    //Inmatning sker, och data skrivs till egenskap i angiven variabel.
                                    members[v-1]._lastName = Console.ReadLine();
                                    break;

                                case 3:
                                    Console.Write("Ange nytt telefonnummer: ");
                                    
                                    bool t = false;
                                    do
                                    {
                                        //Felhantering för inmatning.
                                        t = false;
                                        try
                                        {
                                            //Inmatning sker, och data skrivs till egenskap i angiven variabel.
                                            members[v-1]._phoneNumber = int.Parse(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.Write("Bara heltal kan skrivas in som telefonnummer. Ange korrekt telfonnummer: ");
                                            t = true;
                                        }
                                    } while (t == true);

                                    break;
                            }

                            //Iteration som faller in om användaren inte valt att avsluta programmet.
                            if (r != 0)
                            {
                                //Anrop görs till metod för att spara all data i vår medlemslista
                                SaveAllToFile(members);
                                Console.WriteLine();
                                Console.WriteLine("Ändring sparad. Göra fler förändringar? [j/n]: ");
                                loop = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                    } while ((loop == "j" || loop =="J") && r != 0 && v != 0);
                }

                //Menyval 5 - Radera medlem
                if (i == 5)
                {
                    Console.Clear();
                    Console.WriteLine("================");
                    Console.WriteLine("Radera medlem!");
                    Console.WriteLine("================");
                    Console.WriteLine();

                    string loop = "";
                    int v;
                    string r = "n";

                    do
                    {
                        Console.Write("Ange medlemsnummer[1 - {0}, Avbryt: 0]: ", members.Count);
                        v = int.Parse(Console.ReadLine());

                        if (v != 0)
                        {
                            //Anrop görs för att mata ut vald medlem.
                            getMember(members, v, false);
                            
                            Console.Write("Vill du verkligen radera denna medlem [j/n]: ");
                            r = Console.ReadLine();
                            Console.WriteLine();

                            //Om användaren bekfräftat att radera vald medlem infaller nästa iteration.
                            if (r == "j" || r =="J")
                            {
                                //medlems-objekt raderas ur medlemslistan.
                                members.RemoveAt(v - 1);
                                Console.WriteLine();
                                Console.Write("Medlem raderad. Radera fler medlemmar? [j/n]: ");
                                loop = Console.ReadLine();

                                //anrop görs till metod som sparar all vår medlemslista till textfil.
                                SaveAllToFile(members);
                            }
                        }
                    } while ((loop == "j" || loop == "J") && v != 0 && (r == "j" || r == "J"));
                }
            } while (i != 0);
        }

        //Metod för att skapa ny medlem
        public static Member createNewMember(int memberCounter)
        {
            //Referens skapas och medlemsobjekt kopplat till referens instantieras.
            Member member = new Member();
            int phoneNumber = 0;

            Console.Write("Mata in förnamn: ");
            string firstName = Console.ReadLine();

            Console.Write("Mata in efternamn: ");
            string lastName = Console.ReadLine();

            Console.Write("Mata in Telefonnummer: ");

            //Felhantering för inmatning av telefonnummret.
            bool t = false;
            do
            {
                t = false;
                try
                {
                    //Inmatning av telefonnummer sker.
                    phoneNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Bara heltal kan skrivas in som telefonnummer. Ange korrekt telfonnummer: ");
                    t = true;
                }
            } while (t);

            //All inmatad data skrivs till respektive egenskap i valt medlems-objekt.
            member._firstName = firstName;
            member._lastName = lastName;
            member._phoneNumber = phoneNumber;
            member._memberNumber = memberCounter;

            //Berört medlemsobjekts referens, returneras.
            return member;
        }

        //Metod för att att skriva ut specifik medlem.
        public static void getMember(List<Member> members, int memberNumber, bool hideMemberNumber)
        {
            //Medllemes referens skapas, och medlemsobjekt kopplat till denna referens instantieras.
            Member member = members[memberNumber - 1];

            Console.WriteLine();
            Console.WriteLine("Förnamn: {0}", member._firstName);
            Console.WriteLine("Efternamn: {0}", member._lastName);
            Console.WriteLine("Telefonnummer: {0}", member._phoneNumber);

            //Iteration som infaller om användaren vid anrop av metod valt att man visa medlemsnummer vid utmatning.
            if (!hideMemberNumber)
            {
                Console.WriteLine("Medlemsnummer: {0}", member._memberNumber);
            }
            Console.WriteLine();
        }

        //Metod för att spara all data i medlemslista till textfil
        public static void SaveAllToFile(List<Member> members)
        {
            try
            {
                using (FileStream fs = new FileStream("members.txt", FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        //Data skrivs här till textfil, enligt nedan skrivna ordning, per medlem.
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

        //Metod för att ladda textfil och lägga data i objekt som sen läggs i medlemslista.
        public static void OpenAllFromFile(List<Member> members)
        {
            string line;
            int choser = 5;
            int counter = 0;

            try
            {
                using (StreamReader reader = new StreamReader("members.txt"))
                {
                    do
                    {
                        //Rad läses, och variabel "line" sätts till radens värde.
                        line = reader.ReadLine();
                        
                        //Talar om, om det är en ny medlem som streamreader har stött på.
                        if(line == "[Medlem]") {
                            members.Add(new Member());
                            counter++;
                        }

                        //Talar om, om det är en sektion för ett förnamn som streamreader har stött på.
                        if (line == "[Förnamn]")
                        {
                            choser = 0;
                        }

                        //Talar om, om det är en sektion för ett efternamn som streamreader har stött på.
                        else if (line == "[Efternamn]")
                        {
                            choser = 1;
                        }

                        //Talar om, om det är en sektion för ett telefonnummer som streamreader har stött på.
                        else if (line == "[Telefonnummer]")
                        {
                            choser = 2;
                        }

                        //Talar om, om det är en sektion för ett medlemsnummer som streamreader har stött på.
                        else if (line == "[Medlemsnummer]")
                        {
                            choser = 3;
                        }

                        //Detta händer då ett förnamn finns på läst rad.
                        if (choser == 0 && line != "[Förnamn]")
                        {
                            members[counter-1]._firstName = line;
                            choser = 5;
                        }

                        //Detta händer då ett efternamn finns på läst rad.
                        else if (choser == 1 && line != "[Efternamn]")
                        {
                            members[counter-1]._lastName = line;
                            choser = 5;
                        }

                        //Detta händer då ett telefonnummer finns på läst rad.
                        else if (choser == 2 && line != "[Telefonnummer]")
                        {
                            members[counter-1]._phoneNumber = int.Parse(line);
                            choser = 5;
                        }

                        //Detta händer då ett medlemsnummer finns på läst rad.
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