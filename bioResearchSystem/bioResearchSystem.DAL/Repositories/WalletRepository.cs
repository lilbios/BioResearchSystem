
using bioResearchSystem.Mode;
using bioResearchSystem.Models;
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

        public async Task<Wallet> FindUserWallet(string id)
        {
            var wallet = await dbSet.Include(u => u.User).FirstOrDefaultAsync(w => w.UserId == id);
            return wallet;
        }
    }
}
