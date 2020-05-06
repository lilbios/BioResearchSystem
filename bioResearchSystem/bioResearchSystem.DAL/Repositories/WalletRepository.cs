using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public class WalletRepository : IWalletRepository
    {

        private readonly BioResearchSystemDbContext dbContext;
        public WalletRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async  Task<bool> ChangeOffMoneyTransaction(Wallet wallet, decimal summa)
        {
            using (var transaction = dbContext.Database.BeginTransaction()) {
                try
                {

                    wallet.Balance -= summa;
                    dbContext.Attach(wallet);
                    dbContext.Entry(wallet).Property(w => w.Balance).IsModified = true;
                    await transaction.CommitAsync();
                    return true;    
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                
            };
        }

        public Task Create(Wallet value)
        {
            throw new NotImplementedException();
        }

        public async Task<Wallet> FindUserWallet(string id)
        {
            var wallet = await dbContext.Wallets.FirstOrDefaultAsync(w=> w.UserId == id);
            return wallet;
        }
    }
}
