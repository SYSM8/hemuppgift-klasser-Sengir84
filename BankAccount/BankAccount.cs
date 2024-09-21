using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        //Lägg till Egenskaper (fields)
        
        //Kontonummer
        public string AccountNumber { get; set; }
        //Namn
        public string AccountHolder { get; set; }
        //Saldo
        public double Balance { get; set; }
        //La även till en pinkod
        public double Code { get; set; }
        
        
        //Lägg till Konstruktor
        
        public BankAccount(string an, string ah, double ba, int code)
        {
            AccountNumber = an;
            AccountHolder = ah;
            Balance = ba;
            Code = code;
        }
        
        //Lägg till Metoder
        
        //Metod för insättning
        public void Deposit(double deposit)
        {
            Balance = Balance + deposit;
            Console.WriteLine($"Insatt: {deposit} Saldo: {Balance} \nTryck enter för att fortsätta");
        }
        
        //Metod för uttag
        public void Withdraw(double withdraw)
        {
            if (withdraw <= Balance)
            {
                Balance = Balance - withdraw;
                Console.WriteLine($"Uttag: {withdraw} Saldo: {Balance} \nTryck enter för att fortsätta");
            }
            else if (withdraw > Balance)
            {
                Console.WriteLine($"Uttaget saknar täckning. Du har: {Balance} på kontot \nTryck enter för att fortsätta");
            }
        }
        //Metod för att kolla saldo       
        public void DisplayBalance()
        {
            Console.WriteLine($"Du har {Balance} på kontot \nTryck enter för att fortsätta");
        }
        
        //Lycka till! :)

    }
}

