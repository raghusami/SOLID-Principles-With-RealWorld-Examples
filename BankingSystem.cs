namespace SOLIDPrinciple
{
    /*
     3. Banking System
        ✅ SRP: Separate services for account management, transactions, and notifications.
        ✅ OCP: Support different transaction types (deposit, withdrawal, transfer).
        ✅ LSP: Substitutable account types (SavingsAccount, CurrentAccount).
        ✅ ISP: Segregate interfaces for deposits, withdrawals, and loans.
        ✅ DIP: Inject dependencies for transaction handling (ITransactionService).
     */
    // -------------------- SRP: Separate Responsibilities -------------------- //
    // Account Model
    public class Account
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; } = string.Empty;
        public double Balance { get;  set; }

        public virtual void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} into account {Id}. New Balance: {Balance}");
        }

        public virtual void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount} from account {Id}. New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
    }

    // -------------------- OCP: Extend Functionality Without Modification -------------------- //
    public class SavingsAccount : Account
    {
        public override void Withdraw(double amount)
        {
            if (amount > 1000)
            {
                Console.WriteLine("Withdrawal limit exceeded for savings account.");
                return;
            }
            base.Withdraw(amount);
        }
    }

    public class CurrentAccount : Account
    {
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
        }
    }

    // -------------------- ISP: Interface Segregation -------------------- //
    public interface IDeposit
    {
        void Deposit(double amount);
    }

    public interface IWithdraw
    {
        void Withdraw(double amount);
    }

    public interface ILoan
    {
        void ApplyForLoan(double amount);
    }

    public class LoanService : ILoan
    {
        public void ApplyForLoan(double amount)
        {
            Console.WriteLine($"Loan of {amount} applied successfully.");
        }
    }

    // -------------------- DIP: Inject Dependencies -------------------- //
    public interface ITransactionService
    {
        void ProcessTransaction(Account account, double amount);
    }

    public class DepositService : ITransactionService
    {
        public void ProcessTransaction(Account account, double amount)
        {
            account.Deposit(amount);
        }
    }

    public class WithdrawalService : ITransactionService
    {
        public void ProcessTransaction(Account account, double amount)
        {
            account.Withdraw(amount);
        }
    }

    public class NotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Notification: " + message);
        }
    }

    //class BankProgram
    //{
    //    static void Main()
    //    {
    //        Account savings = new SavingsAccount { Id = 1, AccountHolder = "Alice", Balance = 5000 };
    //        Account current = new CurrentAccount { Id = 2, AccountHolder = "Bob", Balance = 10000 };

    //        ITransactionService depositService = new DepositService();
    //        ITransactionService withdrawalService = new WithdrawalService();

    //        depositService.ProcessTransaction(savings, 2000);
    //        withdrawalService.ProcessTransaction(current, 500);

    //        ILoan loanService = new LoanService();
    //        loanService.ApplyForLoan(10000);
    //    }
    //}
}
