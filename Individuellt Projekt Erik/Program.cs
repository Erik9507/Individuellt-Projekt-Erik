using System;   //Erik Norell SUT21
using System.Threading;

namespace Individuellt_Projekt_Erik
{
    public class accounts   //klass för bankkonto, variablar för användarnamn, lösenord, och 3st bankkonton
    {
        public string username;
        public string password;
        public double amount1;
        public double amount2;
        public double amount3;
        public accounts(string username, string password, double amount1, double amount2 = 0, double amount3 = 0)
        {
            this.username = username;
            this.password = password;
            this.amount1 = amount1;
            this.amount2 = amount2;
            this.amount3 = amount3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Users = new accounts[]  //Tilldelat värden för alla användare
            {
                new accounts("Erik", "erik1", 100.00),
                new accounts("Lukas", "lukas1", 50.20, 500.40),
                new accounts("Viktor", "viktor1", 10.30, 1000.00, 600.00),
                new accounts("Tobias", "tobias1",25.00, 800.000),
                new accounts("Anas", "anas1", 100, 300),
            };
            bool loggedout = true;
            while (loggedout)
            {
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Välkommen till Eriks bank"));//centrerar texten i konsollen
                int TargetIndex = 0;
                Console.WriteLine("[1] Logga in.");
                Console.WriteLine("[2] Skapa nytt konto.");
                int mainMenu;
                int.TryParse(Console.ReadLine(), out mainMenu);
                if (mainMenu == 1)  //if sats för huvudmeny val
                {
                    bool Bank = inLogg(Users, ref TargetIndex, ref loggedout);
                    while (Bank)
                    {
                        myMenu();//hämtar metoden för menyval
                        int menu;
                        bool Menu1 = int.TryParse(Console.ReadLine(), out menu);
                        if (Menu1)
                        {
                            switch (menu)//switch för olika menyval
                            {
                                case 1:
                                    case1(Users, TargetIndex);
                                    break;
                                case 2:
                                    case2(Users, TargetIndex);
                                    break;
                                case 3:
                                    case3(Users, TargetIndex);
                                    break;
                                case 4:
                                    
                                    break;
                                case 5:
                                    Console.WriteLine("Loggas ut......");
                                    int mydelay = 2000;
                                    Thread.Sleep(mydelay);
                                    Console.Clear();
                                    Bank = false;
                                    loggedout = true;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vänligen välj alternativ 1 - 4");
                        }
                    }
                }
                else if (mainMenu == 2)
                {
                    Console.WriteLine("Lägg till nytt konto.");
                    Console.Write("Vänligen Välj ett användarnamn: ");
                    string newUsername = Console.ReadLine();
                    Console.Write("Vänligen välj ett lösenord: ");
                    string newPassword = Console.ReadLine();
                    Console.Write("Vänligen ange saldo för lönekonto: ");
                    double newAmount1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Vänligen ange saldo för sparkonto: ");
                    double newAmount2 = Convert.ToDouble(Console.ReadLine());
                    Array.Resize(ref Users, Users.Length + 1);
                    Users[Users.Length - 1] = new accounts(newUsername, newPassword, newAmount1, newAmount2);   //registerar nya värden för en ny användare i Accounts.
                    Console.WriteLine("Nytt konto registererat.");
                    Console.WriteLine("Välkommen " + newUsername);
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Vänligen välj ett giltigt alternativ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public static void myMenu()//metod för menyval
        {
            Console.WriteLine();
            Console.WriteLine("[1] Se dina konton och saldo");
            Console.WriteLine("[2] Överföring mellan konton");
            Console.WriteLine("[3] Ta ut pengar");
            Console.WriteLine("[4] Sätt in pengar");
            Console.WriteLine("[5] Logga ut");
        }
        public static bool inLogg(accounts[] Users, ref int x, ref bool loggedout)//metof för inloggning
        {
            for (int i = 0; i < 3; i++) //loop för att ge användare 3 försök att logga in.
            {
                Console.WriteLine();
                Console.Write("Vänligen skriv in ditt användarnamn: ");
                var username = Console.ReadLine();
                Console.Write("Vänligen skriv in ditt lösenord: ");
                var password = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Välkommen till Eriks bank"));

                for (int j = 0; j < Users.Length; j++)  //loopar igenom alla existernade användare.
                {
                    if (username == Users[j].username && password == Users[j].password) //kontrollerar om inmatning för inloggning stämmer med en existerande användare.
                    {

                        Console.WriteLine("Loggar in...");
                        int mydelay = 2000;
                        Thread.Sleep(mydelay);
                        Console.Clear();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Välkommen " + username));

                        x = j;
                        return true;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("För många försök, Konto spärrat", Console.ForegroundColor);
            loggedout = false;
            return false;   //om 3 felaktiga försöka matats in, programmet stänger.
        }
        public static void case1(accounts[] Users, int case1)//metod för visning av saldon på bankkonton
        {
            Console.Clear();
            Console.WriteLine("Se dina konton och saldon:");
            Console.WriteLine("Saldo för Lönekonto är : " + Users[case1].amount1 + " sek");//skriver ut saldo för konto 1
            if (Users[case1].amount2 != 0)//kollar om det finns värde i konto 2. skriver ut om det finns.
            {
                Console.WriteLine("Saldo för sparkonto är : " + Users[case1].amount2 + " sek"); 
            }
            if (Users[case1].amount3 != 0)//kollar om det finns värde i konto 3. skriver ut om det finns.
            {
                Console.WriteLine("Saldo för Investeringskonto är : " + Users[case1].amount3 + " sek");
            }

            Console.Write("Tryck enter för att komma till huvudmenyn: ");
            Console.ReadKey();
            Console.Clear();
        }
        public static void case2(accounts[] Users, int case2)//Metof för överföring mellan konton
        {
            Console.Clear();
            Console.WriteLine("Överföring mellan konton.");
            Console.WriteLine("1: Lönekonto: " + Users[case2].amount1 + " kr");
            if (Users[case2].amount2 != 0)  //skriver ut de bankkonton med värde och låter användaren välja konto att flytta från
            {
                Console.WriteLine("2: Sparkonto: " + Users[case2].amount2 + " kr");
            }
            if (Users[case2].amount3 != 0)
            {
                Console.WriteLine("3: investeringskonto: " + Users[case2].amount3 + " kr");
            }       
            Console.WriteLine();
            Console.Write("Välj vilket konto du vill föra över ifrån: ");
            string input1 = Console.ReadLine();
            Console.WriteLine("Hur mycket vill du flytta?");
            double transfer = Int32.Parse(Console.ReadLine());  //användaren får välja hur mycket som ska flyttas

            if (input1 == "1")
            {
                Users[case2].amount1 = Users[case2].amount1 - transfer;
            }
            else if (input1 == "2")
            {
                Users[case2].amount2 = Users[case2].amount2 - transfer;
            }
            else if (input1 == "3")
            {
                Users[case2].amount3 = Users[case2].amount3 - transfer;
            }

            Console.WriteLine("Välj vilket konto du vill föra över till");//låter användaren välja vilket konto att flytta till.
            string input2 = Console.ReadLine();
            if (input2 == "1")
            {
                Users[case2].amount1 = Users[case2].amount1 + transfer;
                Console.WriteLine("Överföringen lyckades!");

            }
            else if (input2 == "2")
            {
                Users[case2].amount2 = Users[case2].amount2 + transfer;
                Console.WriteLine("Överföringen lyckades!");
            }
            else if (input2 == "3")
            {
                Users[case2].amount3 = Users[case2].amount3 + transfer;
                Console.WriteLine("Överföringen lyckades!");
            }
        }
        public static void case3(accounts[] Users, int case3)//metod för uttag av pengar
        {
            Console.Clear();
            Console.WriteLine("Ta ut pengar.");
            Console.WriteLine("1: Lönekonto: " + Users[case3].amount1 + " kr");
            if (Users[case3].amount2 != 0)
            {
                Console.WriteLine("2: Sparkonto: " + Users[case3].amount2 + " kr");
            }
            if (Users[case3].amount3 != 0)
            {
                Console.WriteLine("3: investeringskonto: " + Users[case3].amount3 + " kr");
            }
            Console.WriteLine();
            Console.Write("Välj vilket konto du vill ta ut ifrån: ");
            string input1 = Console.ReadLine();//låter användre välja konto att ta ut pengar från
            Console.WriteLine("Hur mycket vill du ta ut?");
            double draw = Int32.Parse(Console.ReadLine());//låter användare välja hur mycket som ska tas ut
            Console.Write("Vänligen bekräfta med löseord: ");
            string Confirm = Console.ReadLine();//Användare får bekräfta med lösenord.
            if (Confirm == Users[case3].password)
            {
                if (input1 == "1")//justerar salod för valt konto.
                {
                    Users[case3].amount1 = Users[case3].amount1 - draw;
                    Console.WriteLine("Överföringen lyckades, saldo är nu: " + Users[case3].amount1);
                }
                else if (input1 == "2")
                {
                    Users[case3].amount2 = Users[case3].amount2 - draw;
                    Console.WriteLine("Överföringen lyckades, saldo är nu: " + Users[case3].amount2);
                }
                else if (input1 == "3")
                {
                    Users[case3].amount3 = Users[case3].amount3 - draw;
                    Console.WriteLine("Överföringen lyckades, saldo är nu: " + Users[case3].amount3);
                }
                Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void case4(accounts[] Users, int case4)//metod för insätting av pengar
        {
            Console.Clear();
            Console.WriteLine("Sätt in pengar.");
            Console.WriteLine("1: Lönekonto: " + Users[case4].amount1 + " kr");//skriver ut tillgänglika konton
            if (Users[case4].amount2 != 0)
            {
                Console.WriteLine("2: Sparkonto: " + Users[case4].amount2 + " kr");//skriver ut tillgänglika konton
            }
            if (Users[case4].amount3 != 0)
            {
                Console.WriteLine("3: investeringskonto: " + Users[case4].amount3 + " kr");//skriver ut tillgänglika konton
            }
            Console.WriteLine();
            Console.Write("Välj vilket konto du vill sätta in pengar på?: ");
            string input1 = Console.ReadLine();//användare får välja konto att sätta in pengar på.
            Console.WriteLine("Hur mycket vill du sätta in?");
            double deposit = Int32.Parse(Console.ReadLine());//användaren får välja hur mycket pengar som ska sätta in.
            Console.Write("Vänligen bekräfta med löseord: ");
            string Confirm = Console.ReadLine();
            if (Confirm == Users[case4].password)//användaren får bekrätfra med lösenord, kontroll om lösneord stämmer.
            {
                if (input1 == "1")
                {
                    Users[case4].amount1 = Users[case4].amount1 + deposit;//justerar saldo för valt konto
                    Console.WriteLine("insättningen lyckades, saldo är nu: " + Users[case4].amount1);
                }
                else if (input1 == "2")
                {
                    Users[case4].amount2 = Users[case4].amount2 + deposit;//justerar saldo för valt konto
                    Console.WriteLine("insättningen lyckades, saldo är nu: " + Users[case4].amount2);
                }
                else if (input1 == "3")
                {
                    Users[case4].amount3 = Users[case4].amount3 + deposit;//justerar saldo för valt konto
                    Console.WriteLine("insättningen lyckades, saldo är nu: " + Users[case4].amount3);
                }
                Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                Console.ReadKey();
                Console.Clear();
            }
        } //klar
    }
}
