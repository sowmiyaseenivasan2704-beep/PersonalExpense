using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpense
{
    internal class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }

        public Expense(string description, decimal amount, string category, string date)
        {
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date,-12} {Category,-15} {Description,-25} ${Amount:F2}";
        }
    }
}
