using System;
using QuantConnect.Algorithm;
using QuantConnect.Interfaces;
using QuantConnect.Lean.Engine.DataFeeds;
using QuantConnect.Securities;

namespace QuantConnect.Report
{
    internal class StubDataManager : DataManager
    {
        public ISecurityService SecurityService { get; }
        public IAlgorithm Algorithm { get; }

        public StubDataManager()
            : this(new QCAlgorithm())
        {

        }

        public StubDataManager(ITimeKeeper timeKeeper)
            : this(new QCAlgorithm(), timeKeeper)
        {

        }

        public StubDataManager(IAlgorithm algorithm, IDataFeed dataFeed, bool liveMode = false)
            : this(dataFeed, algorithm, new TimeKeeper(DateTime.UtcNow, TimeZones.NewYork), liveMode)
        {

        }

        public StubDataManager(IAlgorithm algorithm)
            : this(new NullDataFeed(), algorithm, new TimeKeeper(DateTime.UtcNow, TimeZones.NewYork))
        {

        }

        public StubDataManager(IDataFeed dataFeed, IAlgorithm algorithm)
            : this(dataFeed, algorithm, new TimeKeeper(DateTime.UtcNow, TimeZones.NewYork))
        {

        }

        public StubDataManager(IAlgorithm algorithm, ITimeKeeper timeKeeper)
            : this(new NullDataFeed(), algorithm, timeKeeper)
        {

        }

        public StubDataManager(IDataFeed dataFeed, IAlgorithm algorithm, ITimeKeeper timeKeeper, bool liveMode = false)
            : this(dataFeed, algorithm, timeKeeper, MarketHoursDatabase.FromDataFolder(), SymbolPropertiesDatabase.FromDataFolder(), liveMode)
        {

        }

        public StubDataManager(IDataFeed dataFeed, IAlgorithm algorithm, ITimeKeeper timeKeeper, MarketHoursDatabase marketHoursDatabase, SymbolPropertiesDatabase symbolPropertiesDatabase, bool liveMode = false)
            : this(dataFeed, algorithm, timeKeeper, marketHoursDatabase,
                new SecurityService(algorithm.Portfolio.CashBook,
                    marketHoursDatabase,
                    symbolPropertiesDatabase,
                    algorithm,
                    RegisteredSecurityDataTypesProvider.Null,
                    new SecurityCacheProvider(algorithm.Portfolio)),
                liveMode)
        {
        }

        public StubDataManager(IDataFeed dataFeed, IAlgorithm algorithm, ITimeKeeper timeKeeper, MarketHoursDatabase marketHoursDatabase, SecurityService securityService, bool liveMode = false)
            : this(dataFeed,
                algorithm,
                timeKeeper,
                marketHoursDatabase,
                securityService,
                new DataPermissionManager(),
                liveMode)
        {
        }

        public StubDataManager(IDataFeed dataFeed, IAlgorithm algorithm, ITimeKeeper timeKeeper, MarketHoursDatabase marketHoursDatabase, SecurityService securityService, DataPermissionManager dataPermissionManager, bool liveMode = false)
            : base(dataFeed,
                new UniverseSelection(algorithm, securityService, dataPermissionManager, new DefaultDataProvider()),
                algorithm,
                timeKeeper,
                marketHoursDatabase,
                liveMode,
                RegisteredSecurityDataTypesProvider.Null,
                dataPermissionManager)
        {
            SecurityService = securityService;
            algorithm.Securities.SetSecurityService(securityService);
            Algorithm = algorithm;
        }
    }
}
