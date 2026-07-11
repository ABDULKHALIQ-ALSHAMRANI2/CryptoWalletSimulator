using System;
using System.Collections.Generic;

namespace CryptoWalletSimulator
{
    // Wallet class: Manages account data, financial transactions, and logging.
    class Wallet
    {
        private string OwnerName;                   // Name of the wallet owner
        private string CoinName;                    // Cryptocurrency ticker (e.g., BTC, ETH)
        private double Balance;                     // Current account balance
        private List<string> TransactionHistory;    // Stores the log of all financial activities

        // Parameterized Constructor: Initializes a custom wallet with user-defined data.
        public Wallet(string ownerName, string coinName, double balance)
        {
            OwnerName = ownerName;
            CoinName = coinName;
            Balance = balance;
            TransactionHistory = new List<string>();
            TransactionHistory.Add($"Wallet created with initial balance: {balance} {coinName}");
        }

        // Constructor Overloading: Initializes a default backup wallet with 0.0 USDT.
        public Wallet(string ownerName)
        {
            OwnerName = ownerName;
            CoinName = "USDT";
            Balance = 0.0;
            TransactionHistory = new List<string>();
            TransactionHistory.Add("Default Wallet created with 0.0 USDT");
        }

        // Deposits funds into the wallet and logs the transaction.
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                string log = $"Deposited: +{amount} {CoinName} | New Balance: {Balance} {CoinName}";
                TransactionHistory.Add(log);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔️ Success: {log}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: Deposit amount must be greater than zero.");
                Console.ResetColor();
            }
        }

        // Withdraws funds after validating sufficient balance and proper amounts.
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: Withdrawal amount must be greater than zero.");
                Console.ResetColor();
            }
            else if (amount > Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: Insufficient funds! You tried to withdraw {amount} {CoinName} but your balance is only {Balance} {CoinName}.");
                Console.ResetColor();
            }
            else
            {
                Balance -= amount;
                string log = $"Withdrew: -{amount} {CoinName} | New Balance: {Balance} {CoinName}";
                TransactionHistory.Add(log);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔️ Success: {log}");
                Console.ResetColor();
            }
        }

        // Prints the transaction history statement to the console.
        public void PrintHistory()
        {
            Console.WriteLine($"\n============= {OwnerName}'s Transaction History =============");
            if (TransactionHistory.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (string record in TransactionHistory)
                {
                    Console.WriteLine($"- {record}");
                }
                Console.ResetColor();
            }
            Console.WriteLine("===========================================================\n");
        }

        // Displays basic wallet overview and current balance info.
        public void DisplayInfo()
        {
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Owner Name: {OwnerName}");
            Console.ResetColor();

            Console.WriteLine("---------------");
            Console.WriteLine($"Balance: {Balance} {CoinName}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$ $ $ $ $ $ $ $ $ $ $ $ $ $ $ $");
            Console.ResetColor();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string restartChoice;

            // Main do-while loop to restart the entire simulation workflow based on user feedback.
            do
            {
                Console.Clear();
                PrintWelcomeBanner();

                // Get and validate wallet owner's name
                PrintMessage("Please Enter Owner Name:");
                string sName = GetValidName();

                // Get and validate cryptocurrency selection
                PrintMessage("Please Enter Coin Name:\nBTC, ETH, USDT.");
                string sCoin = GetCoinName();

                // Get and validate initial setup balance
                PrintMessage("Please enter the last balance\nthat was in the wallet.");
                double nBalance = GetBalance();

                // Instantiate custom and default wallets
                Wallet walletData1 = new Wallet(sName, sCoin, nBalance);
                Wallet walletData2 = new Wallet(sName);

                Console.Clear();

                // Handle sub-menu loop for financial operations (Deposit / Withdraw)
                int nUserChoice = UserChoice();
                while (nUserChoice == 1 || nUserChoice == 2)
                {
                    switch (nUserChoice)
                    {
                        case 1:
                            PrintMessage("Please enter the deposit amount (in numbers):");
                            walletData1.Deposit(GetAmountFromUser());
                            break;
                        case 2:
                            PrintMessage("Please enter the withdrawal amount (in numbers):");
                            walletData1.Withdraw(GetAmountFromUser());
                            break;
                    }

                    Console.WriteLine("\nPress any key to return to menu....");
                    Console.ReadKey();
                    Console.Clear();
                    nUserChoice = UserChoice();
                }

                // Final reports dashboard executed when user opts out with option 3
                Console.Clear();
                PrintMessage("--- Final Report & Financial Operations Summary ---", '*');

                PrintMessage("Displaying Wallet 1 Info (Custom):");
                walletData1.DisplayInfo();
                walletData1.PrintHistory();

                PrintMessage("Displaying Wallet 2 Info (Default USDT):");
                walletData2.Deposit(250); // Dummy transaction to demonstrate multi-object behavior
                walletData2.DisplayInfo();
                walletData2.PrintHistory();

                // Prompts the user to restart the simulation from scratch
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("=================================================");
                Console.WriteLine("Do you want to restart the simulator from scratch?");
                Console.Write("Press [Y] to restart, or any other key to exit: ");
                Console.ResetColor();

                restartChoice = Console.ReadLine().Trim().ToUpper();

            } while (restartChoice == "Y"); // Loop continues if input matches 'Y'

            Console.WriteLine("\nThank you for using Crypto Wallet Simulator. Goodbye!");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("=========================================");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("       Thank you for using our app!      ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("            👋 See you soon 👋           ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("         Developed by: C#Fazza ++        ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================");
            Console.ResetColor(); 
        }

        // UI Helper: Displays a stunning, centered welcome banner for the simulator
        static void PrintWelcomeBanner()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("$   WELCOME TO CRYPTO WALLET SIMULATOR    $");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$             🥳 v1.0 🥳                  $");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
            Console.WriteLine(); // يترك سطر فارغ مريح للعين بعد اللوحة
        }

        // Data Validation: Ensures the name is not empty and falls within 5-30 characters.
        static string GetValidName()
        {
            string sName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(sName) || sName.Length < 5 || sName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Please enter a name that is\nat least 5 characters long and no more than 30 characters long.");
                Console.ResetColor();
                Console.WriteLine("Try again:");
                sName = Console.ReadLine();
            }
            return sName;
        }

        // Data Validation: Restricts currency inputs to specific choices (BTC, ETH, USDT).
        static string GetCoinName()
        {
            string sCoin = Console.ReadLine().ToUpper();
            while (sCoin != "BTC" && sCoin != "ETH" && sCoin != "USDT")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ The currencies must be one of these only:\n Bitcoin (BTC), Ethereum (ETH), or Tether (USDT).");
                Console.ResetColor();
                Console.WriteLine("Try again:");
                sCoin = Console.ReadLine().ToUpper();
            }
            return sCoin;
        }

        // Data Validation: Guarantees initial balance is a valid non-negative number.
        static double GetBalance()
        {
            double nBalance;
            while (!double.TryParse(Console.ReadLine(), out nBalance) || nBalance < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Please enter a valid positive number.");
                Console.ResetColor();
                Console.WriteLine("Try again:");
            }
            return nBalance;
        }

        // Data Validation: Consolidated method to fetch transaction amounts strictly greater than zero.
        static double GetAmountFromUser()
        {
            double nAmount;
            while (!double.TryParse(Console.ReadLine(), out nAmount) || nAmount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: Amount must be greater than zero.");
                Console.ResetColor();
                Console.WriteLine("Try again:");
            }
            return nAmount;
        }

        // Menu Interface: Validates user main option input selection (1-3).
        static int UserChoice()
        {
            int nUserChoice;
            PrintMessage("Press 1 to deposit...\nPress 2 to withdraw...\nPress 3 to see final reports and exit...");
            while (!int.TryParse(Console.ReadLine(), out nUserChoice) || (nUserChoice < 1 || nUserChoice > 3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: The entered value is incorrect. Please enter a number (1, 2, or 3):");
                Console.ResetColor();
            }
            return nUserChoice;
        }

        // UI Helper: Wraps system text messages around customized visual patterns.
        static void PrintMessage(string sMessage, char cPattern = '-')
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Pattern(cPattern);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sMessage);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Pattern(cPattern);
            Console.ResetColor();
        }

        // UI Helper: Generates linear patterns for clear console UI section splitting.
        static void Pattern(char cPattern = '-')
        {
            for (int i = 0; i < 18; i++)
            {
                Console.Write($"{cPattern} ");
            }
            Console.WriteLine();
        }
    }
}