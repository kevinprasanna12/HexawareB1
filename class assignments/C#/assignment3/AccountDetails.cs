using System;


namespace sample_3
{
    class InsufficeintFundsException : Exception
    {
        public InsufficeintFundsException(string msg) : base(msg)
        { }
    }
        internal class AccountDetails 
        {
            public string AccHolder;
            public int Accbalance;

            public AccountDetails(string holder,int balance) 
            {
                AccHolder = holder;
                Accbalance = balance;
            }

            public void TransferAmount(int amount) 
            { 
                if (amount > Accbalance) 
                { 
                    throw new InsufficeintFundsException("Transaction Failed...amount is higher than balance");
                }

                Accbalance = Accbalance - amount;
                Console.WriteLine($"Transaction Successful - balance :{Accbalance}");
            }

            public void DisplayAcc() 
            {
                Console.WriteLine($"Account Holder : {AccHolder} Balance :{Accbalance}");
            }

        }
}
