using System.Collections.Generic;
using System.ServiceModel;

namespace CurrencyExchangeBackend
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double GetExchangeRate(string currencyCode);

        [OperationContract]
        string BuyCurrency(string currencyCode, double plnAmount);

        [OperationContract]
        string SellCurrency(string currencyCode, double currencyAmount);

        [OperationContract]
        double GetPLNBalance();

        [OperationContract]
        Dictionary<string, double> GetCurrencyHoldings();

    }
}
