using System.ComponentModel.Design;

namespace BankAccount
{
    internal class Program
    {
        //Felhanteringsmetod, kontrollerar så att det är siffror som matas in
        public static double NmbrCheck(string siffra)
        {
            if (double.TryParse(siffra, out double nmbr)) ;
            return nmbr;
        }


        static void Main(string[] args)
        {
            //Instansiera bankAccount klassen och testa den
            //                                      Konto              Namn        saldo  kod
            BankAccount account = new BankAccount("98465418", "Alexander Larsson", 1000, 1337);
            
            //loop för meny, count för antal försök 
            bool loop = true;
            int count = 0;
            
            //Pininmatning
            Console.WriteLine("pin");
            double pin = NmbrCheck(Console.ReadLine());
            count++;
            
            while (loop)
            {
                //rensa text sen förra genomloopningen
                Console.Clear();

                //koll om pin stämmer och meny system
                if (pin == account.Code)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Konto: {account.AccountNumber} \nKonto innehavare: {account.AccountHolder}");
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nMenyval:");
                    Console.WriteLine("1) Insättning");
                    Console.WriteLine("2) Uttag");
                    Console.WriteLine("3) Saldo");
                    Console.WriteLine("4) Avsluta");

                    double menuinput = NmbrCheck(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    //Switchval
                    switch (menuinput)

                    {
                        //Insättning
                        case 1:
                            {
                                Console.WriteLine($"Hur mycket vill du sätta in?");
                                double insättning = NmbrCheck(Console.ReadLine());
                                account.Deposit(insättning);
                                Console.ReadLine();
                                break;
                            }
                        //Uttag
                        case 2:
                            {
                                Console.WriteLine($"Hur mycket vill du ta ut?");
                                double uttag = NmbrCheck(Console.ReadLine());
                                account.Withdraw(uttag);
                                Console.ReadLine();
                                break;
                            }
                        //Saldo
                        case 3:
                            {

                                account.DisplayBalance();
                                Console.ReadLine();
                                break;
                            }
                        //Avsluta
                        case 4:
                            {
                                Console.WriteLine($"Välkommen åter");
                                loop = false;
                                break;
                            }
                        //Ogiltig inmatning
                        default:
                            {
                                Console.WriteLine($"Felaktigt val");
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                //Ny loop om fel kod har matats in
                else
                {
                    while (pin != account.Code)
                    {
                        
                        Console.WriteLine($"Fel kod! 3 försök, sen stängs programmet du har försökt {count} ggr");
                        Console.WriteLine($"Pin");
                        pin = NmbrCheck(Console.ReadLine());
                        count++;
                        Console.Clear();

                        if (pin == account.Code)
                        {
                            break;
                        }
                        
                        else if (count == 3)
                        {
                            Console.WriteLine($"För många försök programmet avslutas");
                            loop = false;
                        }
                        break;
                                              

                    }
                }

            }
        }
    }
}

