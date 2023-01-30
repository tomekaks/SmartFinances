using SmartFinances.Application.Dto.Enums;
using SmartFinances.Application.Dto.ExpenseDtos;

namespace SmartFinances.Models.BudgetPlanner
{
    public class ExpensesVM
    {
        public ExpensesVM(List<ExpenseDto> expenses, decimal budget)
        {
            Expenses = expenses;
            Budget = budget;
            GetTotalAmount();
        }

        public List<ExpenseDto> Expenses { get; private set; }
        public decimal Budget { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal HousingAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Housing); }
        public decimal UtilitiesAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Utilities); }
        public decimal FoodAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Food); }
        public decimal ClothesAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Clothes); }
        public decimal HealthAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Health); }
        public decimal EntertainmentAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Entertainment); }
        public decimal ElectronicsAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Electronics); }
        public decimal HouseholdAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Household); }
        public decimal TransportationAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Transportation); }
        public decimal PersonalAmount { get => GetTotalAmountByExpenseType(ExpenseTypeDto.Personal); }

        private void GetTotalAmount()
        {
            foreach (var item in Expenses)
            {
                TotalAmount += item.Amount;
            }
        }

        private decimal GetTotalAmountByExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            var expenses = Expenses.FindAll(q => q.Type == expenseTypeDto);
            decimal amount = 0;

            foreach (var item in expenses)
            {
                amount += item.Amount;
            }

            return amount;
        }
    }
}
