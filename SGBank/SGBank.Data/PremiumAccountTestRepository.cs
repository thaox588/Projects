using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            Balance = 100M,
            AccountNumber = "98765",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string AccountNumber)
        {

            AccountLookupResponse response = new AccountLookupResponse();

            if (AccountNumber == _account.AccountNumber)
            {
                response.Success = true;
                return _account;
            }
            else
            {
                return null;
            }

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
