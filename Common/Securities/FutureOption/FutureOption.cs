using System;
using QuantConnect.Data;
using QuantConnect.Orders.Fees;
using QuantConnect.Orders.Fills;
using QuantConnect.Orders.OptionExercise;
using QuantConnect.Orders.Slippage;
using QuantConnect.Securities.Option;

namespace QuantConnect.Securities.FutureOption
{
    /// <summary>
    /// Futures Options security
    /// </summary>
    public class FutureOption : Option.Option
    {
        /// <summary>
        /// Constructor for the future option security
        /// </summary>
        /// <param name="exchangeHours">Defines the hours this exchange is open</param>
        /// <param name="quoteCurrency">The cash object that represent the quote currency</param>
        /// <param name="config">The subscription configuration for this security</param>
        /// <param name="symbolProperties">The symbol properties for this security</param>
        /// <param name="currencyConverter">Currency converter used to convert <see cref="CashAmount"/>
        /// instances into units of the account currency</param>
        /// <param name="registeredTypes">Provides all data types registered in the algorithm</param>
        public FutureOption(SecurityExchangeHours exchangeHours,
            SubscriptionDataConfig config,
            Cash quoteCurrency,
            OptionSymbolProperties symbolProperties,
            ICurrencyConverter currencyConverter,
            IRegisteredSecurityDataTypesProvider registeredTypes)
            : base(exchangeHours,
                config,
                quoteCurrency,
                symbolProperties,
                currencyConverter,
                registeredTypes
        )
        {
            MarginModel = new FuturesOptionsMarginModel();
        }

        /// <summary>
        /// Constructor for the future option security
        /// </summary>
        /// <param name="symbol">Symbol of the future option</param>
        /// <param name="exchangeHours">Exchange hours of the future option</param>
        /// <param name="quoteCurrency">Quoted currency of the future option</param>
        /// <param name="symbolProperties">Symbol properties of the future option</param>
        /// <param name="currencyConverter">Currency converter</param>
        /// <param name="registeredTypes">Provides all data types registered to the algorithm</param>
        /// <param name="securityCache">Cache of security objects</param>
        public FutureOption(Symbol symbol,
            SecurityExchangeHours exchangeHours,
            Cash quoteCurrency,
            OptionSymbolProperties symbolProperties,
            ICurrencyConverter currencyConverter,
            IRegisteredSecurityDataTypesProvider registeredTypes,
            SecurityCache securityCache)
            : base(symbol,
                quoteCurrency,
                symbolProperties,
                new OptionExchange(exchangeHours),
                securityCache,
                new OptionPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new ConstantSlippageModel(0),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new OptionMarginModel(),
                new OptionDataFilter(),
                new SecurityPriceVariationModel(),
                currencyConverter,
                registeredTypes
        )
        {
        }
    }
}
