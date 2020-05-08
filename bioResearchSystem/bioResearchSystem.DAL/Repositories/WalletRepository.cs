using bioResearchSystem.Context;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {

        public WalletRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }
        public Task<bool> ChangeOffMoneyTransaction(Wallet wallet, decimal summa)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> FindUserWallet(string id)
        {
            throw new NotImplementedException();
        }
    }
}
