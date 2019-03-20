using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{

    public class FileAccountRepository : IAccountRepository
    {

        public virtual Account LoadAccount(string AccountNumber)
        {
            List<Account> accounts = Account();
            return accounts.FirstOrDefault(a => a.AccountNumber == AccountNumber);

        }

        public static List<Account> Account()
        {
            List<Account> results = new List<Account>();
            using (StreamReader sr = new StreamReader("Accounts.txt"))
            {
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    Account c = Mapper.ToAccount(row);
                    results.Add(c);
                }
            }
            return results;


        }

        public void SaveAccount(Account account)
        {
            List<Account> accounts = Account();
            accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber).Balance = account.Balance;
            SaveAllAccount(accounts);

        }

        public static void SaveAllAccount(List<Account> accounts)
        {
            using (StreamWriter sr = new StreamWriter("Accounts.txt"))

                foreach (Account account in accounts)
                {
                    sr.WriteLine(Mapper.toStringCSV(account));
                }


        }


    }


}

