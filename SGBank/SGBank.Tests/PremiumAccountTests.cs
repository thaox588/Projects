﻿using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("98765", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, 250, true)]

        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("98765", "Premium Account", 1500, AccountType.Premium, -1000, 1500, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("98765", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("98765", "Premium Account", 0, AccountType.Premium, -600, 0, false)]

        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account() { AccountNumber = accountNumber, Name = name, Balance = balance, Type = accountType };

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }

        }
    }
}
