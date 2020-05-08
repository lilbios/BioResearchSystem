using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
    public interface IWalletRepository
    {
        public Task<Wallet> FindUserWallet(string id);
        public Task<bool> ChangeOffMoneyTransaction(Wallet wallet, decimal summa);
    }
}
