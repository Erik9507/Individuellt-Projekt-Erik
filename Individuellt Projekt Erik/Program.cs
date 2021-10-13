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
        }
    }
}
