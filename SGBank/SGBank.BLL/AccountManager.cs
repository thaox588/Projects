﻿using SGBank.BLL.DepositRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using SGBank.UI.WithdrawRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }

            return response;
        }
        

        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                Console.WriteLine($"{accountNumber} is not valid");
                return response;
            }
            else
            {
                response.Success = true;
            }            

            IWithdraw withdrawRules = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRules.Withdraw(response.Account, amount);
        
            if (response.Success == true)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }
    }


}
