using System.Collections.Generic;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Securities;

namespace QuantConnect.Report
{
    /// <summary>
    /// Provides a test implementation of a security provider
    /// </summary>
    public class ReportSecurityProvider : ISecurityProvider
    {
        private readonly Dictionary<Symbol, Security> _securities;

        public ReportSecurityProvider(Dictionary<Symbol, Security> securities)
        {
            _securities = securities;
        }

        public ReportSecurityProvider()
        {
            _securities = new Dictionary<Symbol, Security>();
        }

        public Security this[Symbol symbol]
        {
            get { return _securities[symbol]; }
            set { _securities[symbol] = value; }
        }

        public Security GetSecurity(Symbol symbol)
        {
            Security holding;
            _securities.TryGetValue(symbol, out holding);

            return holding ?? CreateSecurity(symbol);
        }

        public bool TryGetValue(Symbol symbol, out Security security)
        {
            return _securities.TryGetValue(symbol, out security);
        }

        internal static Security CreateSecurity(Symbol symbol)
        {
            return new Security(
                SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork),
                new SubscriptionDataConfig(
                    typeof(TradeBar),
                    symbol,
                    Resolution.Minute,
                    TimeZones.NewYork,
                    TimeZones.NewYork,
                    false,
                    false,
                    false
                ),
                new Cash(Currencies.USD, 0, 1m),
                SymbolProperties.GetDefault(Currencies.USD),
                ErrorCurrencyConverter.Instance,
                RegisteredSecurityDataTypesProvider.Null,
                new SecurityCache()
           );
        }
    }
}
