using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Services
{
    public class WalletService:IWalletService
    {

        private readonly IMapper mapper;
        public WalletService(IMapper _mapper)
        {
   
            mapper = _mapper;
        }
    }
}
