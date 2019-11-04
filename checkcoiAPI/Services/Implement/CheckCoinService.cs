using checkcoiAPI.Models;
using checkcoiAPI.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static checkcoiAPI.Models.DTO;

namespace checkcoiAPI.Services.Implement
{
    public class CheckCoinService : BaseService, ICheckCoinService
    {
        private IConfiguration config;
        public CheckCoinService(IConfiguration config) => this.config = config;
        public async Task<object> CheckCoinInWallet(List<string> lstWallet, string contractTK, int contractDecimal)
        {
            try
            {
                var apiLink = config.GetSection("etherscanAPI").Value;
                var apiKey = config.GetSection("etherscanAPIKey").Value;
                var lstWalletBalance = new List<WalletBalance>();

                foreach (var item in lstWallet)
                {
                    var obj = new WalletBalance();
                    obj.WalletAddress = item;
                    var objRs = await GetVLAsync<EtherscanModel>(new Uri(apiLink + "api?module=account&action=tokenbalance&contractaddress=" + contractTK + "&address=" + item + "&tag=latest&apikey=" + apiKey));
                    if (objRs.status == 1 && objRs.message == "OK")
                    {
                        obj.WalletBl = objRs.result != "0" ? objRs.result.Substring(0, objRs.result.Length - contractDecimal) + "." + objRs.result.Substring(objRs.result.Length - contractDecimal, contractDecimal) : "0";
                    }

                    lstWalletBalance.Add(obj);
                }

                return new
                {
                    List = lstWalletBalance
                };
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
