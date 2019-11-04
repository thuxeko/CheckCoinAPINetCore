using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkcoiAPI.Services.Interface
{
    public interface ICheckCoinService
    {
        Task<object> CheckCoinInWallet(List<string> lstWallet, string contractTK, int contractDecimal);
    }
}
