using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class Mapper
    {
        public static Account ToAccount(string row)
        {
            

            Account accounts = new Account();
            string[] fields = row.Split(',');
            accounts.AccountNumber = fields[0];
            accounts.Name = fields[1];
            accounts.Balance = decimal.Parse(fields[2]);
            switch (fields[3])
            {
                case "F":
                    accounts.Type = AccountType.Free;                    
                    break;
                case "B":
                    accounts.Type = AccountType.Basic;
                    break;
                case "P":
                    accounts.Type = AccountType.Premium;
                    break;

            }
            return accounts;
        }

        public static string toStringCSV(Account account)
        {
            string row = $"{account.AccountNumber},{account.Name},{account.Balance},{account.Type.ToString()[0]}";

            return row;
        }

    }
}
