using PersonalExpense;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker
{
    class Program
    {
        static List<Expense> expenses = new List<Expense>();

        static void Main(string[] args)
        {
            // Sample data
            expenses.Add(new Expense("Lunch", 120, "Food", "05/12/2024"));
            expenses.Add(new Expense("Bus Ticket", 30, "Transportation", "06/12/2024"));

            while (true)
            {
                DisplayMenu();
                Console.Write("Enter your choice (1-6): ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter numbers only.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;
                    case 2:
                        ViewAllExpenses();
                        break;
                    case 3:
                        ViewExpensesByCategory();
                        break;
                    case 4:
                        CalculateTotal();
                        break;
                    case 5:
                        CalculateAverage();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using Personal Expense Tracker. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Enter 1-6 only.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("  PERSONAL EXPENSE TRACKER");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add New Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. View Expenses by Category");
            Console.WriteLine("4. Calculate Total Expenses");
            Console.WriteLine("5. Calculate Average Expense");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=================================");
        }

        static void AddExpense()
        {
            Console.Write("Enter Description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Amount must be a positive number!");
                return;
            }

            string[] categories =
            {
                "Food", "Transportation", "Entertainment", "Shopping", "Bills", "Other"
            };

            Console.WriteLine("Select Category:");
            for (int i = 0; i < categories.Length; i++)
                Console.WriteLine($"{i + 1}. {categories[i]}");

            Console.Write("Enter category number: ");
            if (!int.TryParse(Console.ReadLine(), out int catChoice) || catChoice < 1 || catChoice > categories.Length)
            {
                Console.WriteLine("Invalid category!");
                return;
            }

            string category = categories[catChoice - 1];

            Console.Write("Enter Date (dd/MM/yyyy): ");
            string date = Console.ReadLine();

            expenses.Add(new Expense(desc, amount, category, date));

            Console.WriteLine("Expense added successfully!");
        }

        static void ViewAllExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded yet.");
                return;
            }

            Console.WriteLine("No.  Date         Category        Description               Amount");
            Console.WriteLine("-----------------------------------------------------------------------");

            decimal total = 0;
            for (int i = 0; i < expenses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {expenses[i]}");
                total += expenses[i].Amount;
            }

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Total Expenses: ${total:F2}");
        }

        static void ViewExpensesByCategory()
        {
            Console.Write("Enter category name: ");
            string cat = Console.ReadLine();

            var filtered = expenses.Where(e => e.Category.Equals(cat, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("No expenses found in this category!");
                return;
            }

            decimal subtotal = 0;
            foreach (var e in filtered)
            {
                Console.WriteLine(e);
                subtotal += e.Amount;
            }

            Console.WriteLine($"Subtotal for {cat}: ${subtotal:F2}");
        }

        static void CalculateTotal()
        {
            decimal total = expenses.Sum(e => e.Amount);
            Console.WriteLine($"Total Expenses: ${total:F2}");
        }

        static void CalculateAverage()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to calculate average!");
                return;
            }

            decimal avg = expenses.Average(e => e.Amount);
            Console.WriteLine($"Average Expense: ${avg:F2}");
        }
    }
}
