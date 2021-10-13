using System;   //Erik Norell SUT21
using System.Threading;

namespace Individuellt_Projekt_Erik
{
    public class accounts
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
            var Users = new accounts[]
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
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Välkommen till Eriks bank"));
                int TargetIndex = 0;
                Console.WriteLine("[1] Logga in.");
                Console.WriteLine("[2] Skapa nytt konto.");
                int mainMenu;
                int.TryParse(Console.ReadLine(), out mainMenu);
                if (mainMenu == 1)
                {
                    bool Bank = inLogg(Users, ref TargetIndex, ref loggedout);
                    while (Bank)
                    {
                        myMenu();
                        int menu;
                        bool Menu1 = int.TryParse(Console.ReadLine(), out menu);
                        if (Menu1)
                        {
                            switch (menu)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
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
                    Users[Users.Length - 1] = new accounts(newUsername, newPassword, newAmount1, newAmount2);
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


        public static void myMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[1] Se dina konton och saldo");
            Console.WriteLine("[2] Överföring mellan konton");
            Console.WriteLine("[3] Ta ut pengar");
            Console.WriteLine("[4] Sätt in pengar");
            Console.WriteLine("[5] Logga ut");
        }
        public static bool inLogg(accounts[] Users, ref int x, ref bool loggedout)//klar
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                Console.Write("Vänligen skriv in ditt användarnamn: ");
                var username = Console.ReadLine();
                Console.Write("Vänligen skriv in ditt lösenord: ");
                var password = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Välkommen till Eriks bank"));

                for (int j = 0; j < Users.Length; j++)
                {
                    if (username == Users[j].username && password == Users[j].password)
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
            return false;
        }


    }
}
