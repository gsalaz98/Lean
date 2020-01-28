using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Data.Custom.TradingEconomics
{
    /// <summary>
    /// Predefined manifest of <see cref="TradingEconomicsCalendar.Event"/> values possible categorized by country
    /// </summary>
    public static class TradingEconomicsEvent
    {
        /// <summary>
        /// Australia
        /// </summary>
        public static class Australia
        {
            /// <summary>
            /// AIG Construction Index - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string AigPerformanceConstructionIndex = "aig performance construction index";

            /// <summary>
            /// AIG Manufacturing Index - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string AigPerformanceManufacturingIndex = "aig performance manufacturing index";

            /// <summary>
            /// AIG Services Index - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string AigPerformanceServicesIndex = "aig performance services index";

            /// <summary>
            /// ANZ Internet Job Ads MoM - https://tradingeconomics.com/australia/job-advertisements
            /// </summary>
            /// <remarks>
            /// Source: Australia and New Zealand Banking Group
            /// </remarks>
            public const string AnzInternetJobAdvertisementsMoM = "anz internet job advertisements mom";

            /// <summary>
            /// ANZ Job Advertisement - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string AnzJobAdvertisements = "anz job advertisements";

            /// <summary>
            /// ANZ Job Advertisements MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string AnzJobAdvertisementsMoM = "anz job advertisements mom";

            /// <summary>
            /// ANZ Newspaper Job Ads MoM - https://tradingeconomics.com/australia/job-advertisements
            /// </summary>
            /// <remarks>
            /// Source: Australia and New Zealand Banking Group
            /// </remarks>
            public const string AnzNewspaperJobAdvertisementsMoM = "anz newspaper job advertisements mom";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/australia/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Building Permits MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string BuildingPermitsMoM = "building permits mom";

            /// <summary>
            /// Building Permits YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string BuildingPermitsYoY = "building permits yoy";

            /// <summary>
            /// Business Inventories QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string BusinessInventoriesQoQ = "business inventories qoq";

            /// <summary>
            /// Capital Expenditure QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CapitalExpenditureQoQ = "capital expenditure qoq";

            /// <summary>
            /// CB Leading Economic Index - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CbLeadingEconomicIndex = "cb leading economic index";

            /// <summary>
            /// CB Leading Index MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CbLeadingEconomicIndexMoM = "cb leading economic index mom";

            /// <summary>
            /// CB Leading Indicator - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CbLeadingEconomicIndicators = "cb leading economic indicators";

            /// <summary>
            /// CommBank Composite PMI Final - https://tradingeconomics.com/australia/composite-pmi
            /// </summary>
            public const string CommbankCompositePurchasingManagersIndexFinal = "commbank composite purchasing managers index final";

            /// <summary>
            /// CommBank Composite PMI Flash - https://tradingeconomics.com/australia/composite-pmi
            /// </summary>
            public const string CommbankCompositePurchasingManagersIndexFlash = "commbank composite purchasing managers index flash";

            /// <summary>
            /// CommBank Manufacturing PMI Final - https://tradingeconomics.com/australia/industrial-sentiment
            /// </summary>
            public const string CommbankManufacturingPurchasingManagersIndexFinal = "commbank manufacturing purchasing managers index final";

            /// <summary>
            /// CommBank Manufacturing PMI Flash - https://tradingeconomics.com/australia/industrial-sentiment
            /// </summary>
            public const string CommbankManufacturingPurchasingManagersIndexFlash = "commbank manufacturing purchasing managers index flash";

            /// <summary>
            /// CommBank Services PMI Final - https://tradingeconomics.com/australia/services-sentiment
            /// </summary>
            public const string CommbankServicesPurchasingManagersIndexFinal = "commbank services purchasing managers index final";

            /// <summary>
            /// CommBank Services PMI Flash - https://tradingeconomics.com/australia/services-sentiment
            /// </summary>
            public const string CommbankServicesPurchasingManagersIndexFlash = "commbank services purchasing managers index flash";

            /// <summary>
            /// Company Gross Operating Profits (QoQ) - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CompanyGrossOperatingProfitsQoQ = "company gross operating profits qoq";

            /// <summary>
            /// Company Gross Profits QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string CompanyGrossProfitsQoQ = "company gross profits qoq";

            /// <summary>
            /// Construction Work Done - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ConstructionWorkDone = "construction work done";

            /// <summary>
            /// Construction Work Done QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ConstructionWorkDoneQoQ = "construction work done qoq";

            /// <summary>
            /// Consumer Inflation Expectations - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ConsumerInflationExpectations = "consumer inflation expectations";

            /// <summary>
            /// Consumer Price Index - https://tradingeconomics.com/australia/consumer-price-index-cpi
            /// </summary>
            public const string ConsumerPriceIndex = "consumer price index";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/australia/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Employment Change - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string EmploymentChange = "employment change";

            /// <summary>
            /// Employment Change s.a. - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string EmploymentChangeSeasonallyAdjusted = "employment change seasonally adjusted";

            /// <summary>
            /// Export Prices QoQ - https://tradingeconomics.com/australia/export-prices
            /// </summary>
            public const string ExportPricesQoQ = "export prices qoq";

            /// <summary>
            /// Exports MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ExportsMoM = "exports mom";

            /// <summary>
            /// Exports YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ExportsYoY = "exports yoy";

            /// <summary>
            /// Full Time Employment Chg - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string FullTimeEmploymentChange = "full time employment change";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/australia/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Capital Expenditure - https://tradingeconomics.com/australia/gross-fixed-capital-formation
            /// </summary>
            /// <remarks>
            /// Source: Australian Bureau of Statistics
            /// </remarks>
            public const string GdpCapitalExpenditure = "gdp capital expenditure";

            /// <summary>
            /// GDP Capital Expenditure QoQ - https://tradingeconomics.com/australia/gross-fixed-capital-formation
            /// </summary>
            public const string GdpCapitalExpenditureQoQ = "gdp capital expenditure qoq";

            /// <summary>
            /// GDP Deflator - https://tradingeconomics.com/australia/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Australian Bureau of Statistics
            /// </remarks>
            public const string GdpDeflator = "gdp deflator";

            /// <summary>
            /// GDP Deflator QoQ - https://tradingeconomics.com/australia/gdp-deflator
            /// </summary>
            public const string GdpDeflatorQoQ = "gdp deflator qoq";

            /// <summary>
            /// GDP Final Consumption - https://tradingeconomics.com/australia/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: Australian Bureau of Statistics
            /// </remarks>
            public const string GdpFinalConsumption = "gdp final consumption";

            /// <summary>
            /// GDP Final Consumption QoQ - https://tradingeconomics.com/australia/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: Australian Bureau of Statistics
            /// </remarks>
            public const string GdpFinalConsumptionQoQ = "gdp final consumption qoq";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/australia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/australia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// HIA New Home Sales MoM - https://tradingeconomics.com/australia/new-home-sales
            /// </summary>
            public const string HiaNewHomeSalesMoM = "hia new home sales mom";

            /// <summary>
            /// Home Loans MoM - https://tradingeconomics.com/australia/home-loans
            /// </summary>
            public const string HomeLoansMoM = "home loans mom";

            /// <summary>
            /// House Price Index QoQ - https://tradingeconomics.com/australia/housing-index
            /// </summary>
            public const string HousePriceIndexQoQ = "house price index qoq";

            /// <summary>
            /// House Price Index YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string HousePriceIndexYoY = "house price index yoy";

            /// <summary>
            /// Import Prices QoQ - https://tradingeconomics.com/australia/import-prices
            /// </summary>
            public const string ImportPricesQoQ = "import prices qoq";

            /// <summary>
            /// Imports MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ImportsMoM = "imports mom";

            /// <summary>
            /// Imports YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ImportsYoY = "imports yoy";

            /// <summary>
            /// Inflation Rate QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string InflationRateQoQ = "inflation rate qoq";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/australia/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Investment Lending for Homes - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string InvestmentLendingForHomes = "investment lending for homes";

            /// <summary>
            /// NAB Business Confidence - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string NabBusinessConfidence = "nab business confidence";

            /// <summary>
            /// NAB Business Survey - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string NabBusinessSurvey = "nab business survey";

            /// <summary>
            /// New Motor Vehicle Sales MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string NewMotorVehicleSalesMoM = "new motor vehicle sales mom";

            /// <summary>
            /// New Motor Vehicle Sales YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string NewMotorVehicleSalesYoY = "new motor vehicle sales yoy";

            /// <summary>
            /// Part Time Employment Chg - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string PartTimeEmploymentChange = "part time employment change";

            /// <summary>
            /// Participation Rate - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ParticipationRate = "participation rate";

            /// <summary>
            /// Private Capital Expenditure QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string PrivateCapitalExpenditureQoQ = "private capital expenditure qoq";

            /// <summary>
            /// Priv. New Capital Exp. QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string PrivateNewCapitalExpenditureQoQ = "private new capital expenditure qoq";

            /// <summary>
            /// Private Sector Credit MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string PrivateSectorCreditMoM = "private sector credit mom";

            /// <summary>
            /// Private Sector Credit YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string PrivateSectorCreditYoY = "private sector credit yoy";

            /// <summary>
            /// PPI QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ProducerPriceIndexQoQ = "producer price index qoq";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// RBA Commodity Index SDR YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string RbaCommodityIndexSdrYoY = "rba commodity index sdr yoy";

            /// <summary>
            /// RBA Interest Rate Decision - https://tradingeconomics.com/australia/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Reserve Bank of Australia
            /// </remarks>
            public const string RbaInterestRateDecision = "rba interest rate decision";

            /// <summary>
            /// RBA Trimmed Mean CPI QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string RbaTrimmedMeanConsumerPriceIndexQoQ = "rba trimmed mean consumer price index qoq";

            /// <summary>
            /// RBA Trimmed Mean CPI YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string RbaTrimmedMeanConsumerPriceIndexYoY = "rba trimmed mean consumer price index yoy";

            /// <summary>
            /// RBA Weighted Mean CPI QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string RbaWeightedMeanConsumerPriceIndexQoQ = "rba weighted mean consumer price index qoq";

            /// <summary>
            /// RBA Weighted Mean CPI YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string RbaWeightedMeanConsumerPriceIndexYoY = "rba weighted mean consumer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/australia/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/australia/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// TD-MI Inflation Gauge MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string TdMelbourneInstituteInflationGaugeMoM = "td melbourne institute inflation gauge mom";

            /// <summary>
            /// TD Securities Inflation MoM - https://tradingeconomics.com/australia/inflation-cpi
            /// </summary>
            /// <remarks>
            /// Source: Australian Bureau of Statistics
            /// </remarks>
            public const string TdSecuritiesInflationMoM = "td securities inflation mom";

            /// <summary>
            /// TD Securities Inflation YoY - https://tradingeconomics.com/australia/inflation-cpi
            /// </summary>
            public const string TdSecuritiesInflationYoY = "td securities inflation yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/australia/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wage Price Index QoQ - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WagePriceIndexQoQ = "wage price index qoq";

            /// <summary>
            /// Wage Price Index YoY - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WagePriceIndexYoY = "wage price index yoy";

            /// <summary>
            /// Westpac Consumer Confidence Index - https://tradingeconomics.com/australia/consumer-confidence
            /// </summary>
            public const string WestpacConsumerConfidence = "westpac consumer confidence";

            /// <summary>
            /// Westpac Consumer Confidence Change - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WestpacConsumerConfidenceChange = "westpac consumer confidence change";

            /// <summary>
            /// Westpac Consumer Confidence MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WestpacConsumerConfidenceMoM = "westpac consumer confidence mom";

            /// <summary>
            /// Westpac Leading Index - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WestpacLeadingIndex = "westpac leading index";

            /// <summary>
            /// Westpac Leading Index MoM - https://tradingeconomics.com/australia/calendar
            /// </summary>
            public const string WestpacLeadingIndexMoM = "westpac leading index mom";
        }

        /// <summary>
        /// Austria
        /// </summary>
        public static class Austria
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/austria/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Bank Austria Manufacturing PMI - https://tradingeconomics.com/austria/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string BankOfAustriaManufacturingPurchasingManagersIndex = "bank of austria manufacturing purchasing managers index";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/austria/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/austria/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/austria/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/austria/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/austria/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/austria/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/austria/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/austria/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/austria/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/austria/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// Harmonised Inflation Rate MoM - https://tradingeconomics.com/austria/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoM = "harmonized inflation rate mom";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/austria/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/austria/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/austria/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/austria/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/austria/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/austria/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// PMI Manufacturing - https://tradingeconomics.com/austria/calendar
            /// </summary>
            public const string PurchasingManagersIndexManufacturing = "purchasing managers index manufacturing";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/austria/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/austria/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployed Persons - https://tradingeconomics.com/austria/unemployed-persons
            /// </summary>
            /// <remarks>
            /// Source: Arbeitsmarktservice Oesterreich
            /// </remarks>
            public const string UnemployedPersons = "unemployed persons";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/austria/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wholesale Prices MoM - https://tradingeconomics.com/austria/wholesale-prices
            /// </summary>
            public const string WholesalePricesMoM = "wholesale prices mom";

            /// <summary>
            /// Wholesale Prices NSA MoM - https://tradingeconomics.com/austria/wholesale-prices
            /// </summary>
            public const string WholesalePricesNotSeasonallyAdjustedMoM = "wholesale prices not seasonally adjusted mom";

            /// <summary>
            /// Wholesale Prices NSA YoY - https://tradingeconomics.com/austria/wholesale-prices
            /// </summary>
            public const string WholesalePricesNotSeasonallyAdjustedYoY = "wholesale prices not seasonally adjusted yoy";

            /// <summary>
            /// Wholesale Prices YoY - https://tradingeconomics.com/austria/wholesale-prices
            /// </summary>
            public const string WholesalePricesYoY = "wholesale prices yoy";

        }

        /// <summary>
        /// Belgium
        /// </summary>
        public static class Belgium
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/belgium/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/belgium/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/belgium/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/belgium/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/belgium/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/belgium/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Adv - https://tradingeconomics.com/belgium/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQAdvance = "gdp growth rate qoq advance";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/belgium/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/belgium/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/belgium/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Adv - https://tradingeconomics.com/belgium/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYAdvance = "gdp growth rate yoy advance";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/belgium/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/belgium/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/belgium/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/belgium/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/belgium/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/belgium/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// NBB Business Climate - https://tradingeconomics.com/belgium/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: National Bank of Belgium
            /// </remarks>
            public const string NbbBusinessClimate = "nbb business climate";

            /// <summary>
            /// NBB Business Confidence - https://tradingeconomics.com/belgium/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: National Bank of Belgium
            /// </remarks>
            public const string NbbBusinessConfidence = "nbb business confidence";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/belgium/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/belgium/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/belgium/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/belgium/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Canada
        /// </summary>
        public static class Canada
        {
            /// <summary>
            /// ADP Employment Change - https://tradingeconomics.com/canada/adp-employment-change
            /// </summary>
            public const string AdpEmploymentChange = "adp employment change";

            /// <summary>
            /// Average Hourly Wages YoY - https://tradingeconomics.com/canada/average-hourly-earnings
            /// </summary>
            /// <remarks>
            /// Source: Statistics Canada
            /// </remarks>
            public const string AverageHourlyWagesYoY = "average hourly wages yoy";

            /// <summary>
            /// Average Weekly Earnings YoY - https://tradingeconomics.com/canada/wage-growth
            /// </summary>
            public const string AverageWeeklyEarningsYoY = "average weekly earnings yoy";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/canada/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Bank of Canada Consumer Price Index Core MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string BankOfCanadaConsumerPriceIndexCoreMoM = "bank of canada consumer price index core mom";

            /// <summary>
            /// Bank of Canada Consumer Price Index Core YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string BankOfCanadaConsumerPriceIndexCoreYoY = "bank of canada consumer price index core yoy";

            /// <summary>
            /// Bank of Canada Core Inflation MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string BankOfCanadaCoreInflationMoM = "bank of canada core inflation mom";

            /// <summary>
            /// Bank of Canada Core Inflation YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string BankOfCanadaCoreInflationYoY = "bank of canada core inflation yoy";

            /// <summary>
            /// BoC Interest Rate Decision - https://tradingeconomics.com/canada/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of Canada
            /// </remarks>
            public const string BankOfCanadaInterestRateDecision = "bank of canada interest rate decision";

            /// <summary>
            /// Budget Balance - https://tradingeconomics.com/canada/government-budget-value
            /// </summary>
            public const string BudgetBalance = "budget balance";

            /// <summary>
            /// Building Permits MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string BuildingPermitsMoM = "building permits mom";

            /// <summary>
            /// Canadian Investment in Foreign Securities - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CanadianInvestmentInForeignSecurities = "canadian investment in foreign securities";

            /// <summary>
            /// Capacity Utilization - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CapacityUtilization = "capacity utilization";

            /// <summary>
            /// Consumer Price Index - Core MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ConsumerPriceIndexCoreMoM = "consumer price index core mom";

            /// <summary>
            /// Core CPI YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CoreConsumerPriceIndexYoY = "core consumer price index yoy";

            /// <summary>
            /// Core Inflation Rate MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CoreInflationRateMoM = "core inflation rate mom";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Core Retail Sales MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string CoreRetailSalesMoM = "core retail sales mom";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/canada/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Employment Change - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string EmploymentChange = "employment change";

            /// <summary>
            /// Exports - https://tradingeconomics.com/canada/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// Foreign Investment in Canadian Securities - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ForeignInvestmentInCanadianSecurities = "foreign investment in canadian securities";

            /// <summary>
            /// Foreign Securities Purchases - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ForeignSecuritiesPurchases = "foreign securities purchases";

            /// <summary>
            /// Foreign Securities Purchases by Canadians - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ForeignSecuritiesPurchasesByCanadians = "foreign securities purchases by canadians";

            /// <summary>
            /// Full Employment Change - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string FullEmploymentChange = "full employment change";

            /// <summary>
            /// Full Time Employment Chg - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string FullTimeEmploymentChange = "full time employment change";

            /// <summary>
            /// GDP Growth Rate Annualized - https://tradingeconomics.com/canada/gdp-growth-annualized
            /// </summary>
            /// <remarks>
            /// Source: Statistics Canada
            /// </remarks>
            public const string GdpGrowthRateAnnualized = "gdp growth rate annualized";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/canada/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/canada/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Implicit Price QoQ - https://tradingeconomics.com/canada/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Statistics Canada
            /// </remarks>
            public const string GdpImplicitPriceQoQ = "gdp implicit price qoq";

            /// <summary>
            /// GDP MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string GdpMoM = "gdp mom";

            /// <summary>
            /// Gross Domestic Product (MoM) - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string GrossDomesticProductMoM = "gross domestic product mom";

            /// <summary>
            /// Housing Starts - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string HousingStarts = "housing starts";

            /// <summary>
            /// Housing Starts s.a YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string HousingStartsSeasonallyAdjustedYoY = "housing starts seasonally adjusted yoy";

            /// <summary>
            /// Housing Starts YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string HousingStartsYoY = "housing starts yoy";

            /// <summary>
            /// Imports - https://tradingeconomics.com/canada/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Product Price MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string IndustrialProductPriceMoM = "industrial product price mom";

            /// <summary>
            /// Industrial Product Price YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string IndustrialProductPriceYoY = "industrial product price yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/canada/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/canada/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Portfolio Investment In Foreign Securities - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string InvestmentInForeignSecurities = "investment in foreign securities";

            /// <summary>
            /// Ivey PMI s.a - https://tradingeconomics.com/canada/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Richard Ivey School of Business
            /// </remarks>
            public const string IveyPurchasingManagersIndexSeasonallyAdjusted = "ivey purchasing managers index seasonally adjusted";

            /// <summary>
            /// Job Vacancies - https://tradingeconomics.com/canada/job-vacancies
            /// </summary>
            public const string JobVacancies = "job vacancies";

            /// <summary>
            /// Labor Productivity QoQ - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string LaborProductivityQoQ = "labor productivity qoq";

            /// <summary>
            /// Manufacturing Sales MoM - https://tradingeconomics.com/canada/manufacturing-sales
            /// </summary>
            public const string ManufacturingSalesMoM = "manufacturing sales mom";

            /// <summary>
            /// Manufacturing Sales YoY - https://tradingeconomics.com/canada/manufacturing-sales
            /// </summary>
            public const string ManufacturingSalesYoY = "manufacturing sales yoy";

            /// <summary>
            /// Manufacturing Shipments MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ManufacturingShipmentsMoM = "manufacturing shipments mom";

            /// <summary>
            /// Manufacturing Shipments YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ManufacturingShipmentsYoY = "manufacturing shipments yoy";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/canada/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Net Change in Employment - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string NetChangeInEmployment = "net change in employment";

            /// <summary>
            /// New Housing Price Index MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string NewHousingPriceIndexMoM = "new housing price index mom";

            /// <summary>
            /// New Housing Price Index YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string NewHousingPriceIndexYoY = "new housing price index yoy";

            /// <summary>
            /// New Motor Vehicle Sales - https://tradingeconomics.com/canada/car-registrations
            /// </summary>
            /// <remarks>
            /// Source: Statistics Canada
            /// </remarks>
            public const string NewMotorVehicleSales = "new motor vehicle sales";

            /// <summary>
            /// Part Time Employment Chg - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string PartTimeEmploymentChange = "part time employment change";

            /// <summary>
            /// Participation Rate - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ParticipationRate = "participation rate";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/canada/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Raw Materials Prices MoM - https://tradingeconomics.com/canada/wholesale-prices
            /// </summary>
            public const string RawMaterialsPriceIndexMoM = "raw materials price index mom";

            /// <summary>
            /// Raw Materials Prices YoY - https://tradingeconomics.com/canada/wholesale-prices
            /// </summary>
            public const string RawMaterialsPriceIndexYoY = "raw materials price index yoy";

            /// <summary>
            /// RBC Manufacturing PMI - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string RbcManufacturingPurchasingManagersIndex = "rbc manufacturing purchasing managers index";

            /// <summary>
            /// Retail Sales Ex Autos MoM - https://tradingeconomics.com/canada/calendar
            /// </summary>
            public const string RetailSalesExcludingAutosMoM = "retail sales excluding autos mom";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/canada/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/canada/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Stock Investment by Foreigners - https://tradingeconomics.com/canada/foreign-stock-investment
            /// </summary>
            public const string StockInvestmentByForeigners = "stock investment by foreigners";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/canada/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wholesale Sales MoM - https://tradingeconomics.com/canada/wholesale-sales
            /// </summary>
            public const string WholesaleSalesMoM = "wholesale sales mom";

            /// <summary>
            /// Wholesale Sales YoY - https://tradingeconomics.com/canada/wholesale-sales
            /// </summary>
            /// <remarks>
            /// Source: Statistics Canada
            /// </remarks>
            public const string WholesaleSalesYoY = "wholesale sales yoy";

        }

        /// <summary>
        /// China
        /// </summary>
        public static class China
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/china/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Caixin Composite PMI - https://tradingeconomics.com/china/composite-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string CaixinCompositePurchasingManagersIndex = "caixin composite purchasing managers index";

            /// <summary>
            /// Caixin Manufacturing PMI - https://tradingeconomics.com/china/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string CaixinManufacturingPurchasingManagersIndex = "caixin manufacturing purchasing managers index";

            /// <summary>
            /// Caixin Manufacturing PMI Final - https://tradingeconomics.com/china/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string CaixinManufacturingPurchasingManagersIndexFinal = "caixin manufacturing purchasing managers index final";

            /// <summary>
            /// Caixin Manufacturing PMI Flash - https://tradingeconomics.com/china/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string CaixinManufacturingPurchasingManagersIndexFlash = "caixin manufacturing purchasing managers index flash";

            /// <summary>
            /// Caixin Services PMI - https://tradingeconomics.com/china/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string CaixinServicesPurchasingManagersIndex = "caixin services purchasing managers index";

            /// <summary>
            /// Capital Flows - https://tradingeconomics.com/china/capital-flows
            /// </summary>
            /// <remarks>
            /// Source: State Administration of Foreign Exchange, China
            /// </remarks>
            public const string CapitalFlows = "capital flows";

            /// <summary>
            /// CB Leading Economic Index - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string CbLeadingEconomicIndex = "cb leading economic index";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/china/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Exports - https://tradingeconomics.com/china/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// Exports YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string ExportsYoY = "exports yoy";

            /// <summary>
            /// Fixed Asset Investment (YTD) YoY - https://tradingeconomics.com/china/fixed-asset-investment
            /// </summary>
            public const string FixedAssetInvestmentYtdYoY = "fixed asset investment ytd yoy";

            /// <summary>
            /// FDI (YTD) YoY - https://tradingeconomics.com/china/foreign-direct-investment
            /// </summary>
            public const string ForeignDirectInvestmentYtdYoY = "foreign direct investment ytd yoy";

            /// <summary>
            /// Foreign Exchange Reserves - https://tradingeconomics.com/china/foreign-exchange-reserves
            /// </summary>
            public const string ForeignExchangeReserves = "foreign exchange reserves";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/china/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/china/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// House Price Index MoM - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HousePriceIndexMoM = "house price index mom";

            /// <summary>
            /// House Price Index YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HousePriceIndexYoY = "house price index yoy";

            /// <summary>
            /// HSBC China Services PMI - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcChinaServicesPurchasingManagersIndex = "hsbc china services purchasing managers index";

            /// <summary>
            /// HSBC Manufacturing PMI - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcManufacturingPurchasingManagersIndex = "hsbc manufacturing purchasing managers index";

            /// <summary>
            /// HSBC Manufacturing PMI Final - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcManufacturingPurchasingManagersIndexFinal = "hsbc manufacturing purchasing managers index final";

            /// <summary>
            /// HSBC Manufacturing PMI Flash - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcManufacturingPurchasingManagersIndexFlash = "hsbc manufacturing purchasing managers index flash";

            /// <summary>
            /// HSBC Manufacturing PMI Prel. - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcManufacturingPurchasingManagersIndexPreliminary = "hsbc manufacturing purchasing managers index preliminary";

            /// <summary>
            /// HSBC Services PMI - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string HsbcServicesPurchasingManagersIndex = "hsbc services purchasing managers index";

            /// <summary>
            /// Imports - https://tradingeconomics.com/china/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Imports YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string ImportsYoY = "imports yoy";

            /// <summary>
            /// Industrial Capacity Utilization - https://tradingeconomics.com/china/capacity-utilization
            /// </summary>
            /// <remarks>
            /// Source: National Bureau of Statistics of China
            /// </remarks>
            public const string IndustrialCapacityUtilization = "industrial capacity utilization";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/china/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Industrial Profits (YTD) YoY - https://tradingeconomics.com/china/corporate-profits
            /// </summary>
            /// <remarks>
            /// Source: National Bureau of Statistics of China
            /// </remarks>
            public const string IndustrialProfitsYtdYoY = "industrial profits ytd yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/china/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/china/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Interest Rate Decision - https://tradingeconomics.com/china/interest-rate
            /// </summary>
            public const string InterestRateDecision = "interest rate decision";

            /// <summary>
            /// Loan Prime Rate 5Y - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string LoanPrimeRateFiveYear = "loan prime rate 5y";

            /// <summary>
            /// Loan Prime Rate 1Y - https://tradingeconomics.com/china/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: People's Bank of China
            /// </remarks>
            public const string LoanPrimeRateOneYear = "loan prime rate 1y";

            /// <summary>
            /// M2 Money Supply YoY - https://tradingeconomics.com/china/money-supply-m2
            /// </summary>
            public const string M2MoneySupplyYoY = "m2 money supply yoy";

            /// <summary>
            /// MNI Business Sentiment Indicator - https://tradingeconomics.com/china/mni-business-sentiment
            /// </summary>
            public const string MniBusinessSentiment = "mni business sentiment";

            /// <summary>
            /// NBS Manufacturing PMI - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string NbsManufacturingPurchasingManagersIndex = "nbs manufacturing purchasing managers index";

            /// <summary>
            /// New Loans - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string NewLoans = "new loans";

            /// <summary>
            /// New Yuan Loans - https://tradingeconomics.com/china/banks-balance-sheet
            /// </summary>
            public const string NewYuanLoans = "new yuan loans";

            /// <summary>
            /// Non Manufacturing PMI - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string NonManufacturingPurchasingManagersIndex = "non manufacturing purchasing managers index";

            /// <summary>
            /// Outstanding Loan Growth YoY - https://tradingeconomics.com/china/loan-growth
            /// </summary>
            public const string OutstandingLoanGrowthYoY = "outstanding loan growth yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/china/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Total Social Financing - https://tradingeconomics.com/china/loans-to-private-sector
            /// </summary>
            /// <remarks>
            /// Source: People's Bank of China
            /// </remarks>
            public const string TotalSocialFinancing = "total social financing";

            /// <summary>
            /// Urban Investment YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string UrbanInvestmentYoY = "urban investment yoy";

            /// <summary>
            /// Urban Investment YTD - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string UrbanInvestmentYtd = "urban investment ytd";

            /// <summary>
            /// Urban Investment (YTD) YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string UrbanInvestmentYtdYoY = "urban investment ytd yoy";

            /// <summary>
            /// Vehicle Sales YoY - https://tradingeconomics.com/china/calendar
            /// </summary>
            public const string VehicleSalesYoY = "vehicle sales yoy";

            /// <summary>
            /// Westpac MNI Consumer Sentiment - https://tradingeconomics.com/china/mni-consumer-sentiment
            /// </summary>
            /// <remarks>
            /// Source: MNI Deutsche Börse Group
            /// </remarks>
            public const string WestpacMniConsumerSentiment = "westpac mni consumer sentiment";

        }

        /// <summary>
        /// Cyprus
        /// </summary>
        public static class Cyprus
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/cyprus/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/cyprus/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/cyprus/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/cyprus/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/cyprus/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/cyprus/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate - Final - https://tradingeconomics.com/cyprus/gdp-growth
            /// </summary>
            /// <remarks>
            /// Source: Statistical Service of the Republic of Cyprus
            /// </remarks>
            public const string GdpGrowthRateFinal = "gdp growth rate final";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/cyprus/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/cyprus/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/cyprus/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/cyprus/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/cyprus/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/cyprus/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/cyprus/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/cyprus/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/cyprus/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/cyprus/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/cyprus/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wage Growth YoY - https://tradingeconomics.com/cyprus/wage-growth
            /// </summary>
            /// <remarks>
            /// Source: Statistical Service of the Republic of Cyprus
            /// </remarks>
            public const string WageGrowthYoY = "wage growth yoy";

        }

        /// <summary>
        /// Estonia
        /// </summary>
        public static class Estonia
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/estonia/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/estonia/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/estonia/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/estonia/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/estonia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/estonia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/estonia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/estonia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/estonia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/estonia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/estonia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/estonia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Imports - https://tradingeconomics.com/estonia/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/estonia/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/estonia/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/estonia/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/estonia/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/estonia/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/estonia/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/estonia/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/estonia/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/estonia/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Finland
        /// </summary>
        public static class Finland
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/finland/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/finland/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/finland/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/finland/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Export Prices YoY - https://tradingeconomics.com/finland/calendar
            /// </summary>
            public const string ExportPricesYoY = "export prices yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/finland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/finland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/finland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/finland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/finland/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/finland/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/finland/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP YoY - https://tradingeconomics.com/finland/leading-economic-index
            /// </summary>
            public const string GdpYoY = "gdp yoy";

            /// <summary>
            /// Import Prices - https://tradingeconomics.com/finland/import-prices
            /// </summary>
            /// <remarks>
            /// Source: Statistics Finland
            /// </remarks>
            public const string ImportPrices = "import prices";

            /// <summary>
            /// Import Prices YoY - https://tradingeconomics.com/finland/calendar
            /// </summary>
            public const string ImportPricesYoY = "import prices yoy";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/finland/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/finland/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/finland/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/finland/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/finland/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/finland/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/finland/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/finland/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// France
        /// </summary>
        public static class France
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/france/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Budget Balance - https://tradingeconomics.com/france/government-budget-value
            /// </summary>
            public const string BudgetBalance = "budget balance";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/france/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/france/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Consumer Spending MoM - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string ConsumerSpendingMoM = "consumer spending mom";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/france/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// 5-Year BTAN Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string FiveYearBtanAuction = "5 year btan auction";

            /// <summary>
            /// 4-Year BTAN Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string FourYearBtanAuction = "4 year btan auction";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/france/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/france/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ 1st Est - https://tradingeconomics.com/france/gdp-growth
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string GdpGrowthRateQoQFirstEstimate = "gdp growth rate qoq first estimate";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/france/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/france/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/france/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/france/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY 1st Est - https://tradingeconomics.com/france/gdp-growth-annual
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string GdpGrowthRateYoYFirstEstimate = "gdp growth rate yoy first estimate";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/france/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/france/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Harmonised Inflation Rate MoM - https://tradingeconomics.com/france/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoM = "harmonized inflation rate mom";

            /// <summary>
            /// Harmonised Inflation Rate MoM Final - https://tradingeconomics.com/france/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMFinal = "harmonized inflation rate mom final";

            /// <summary>
            /// Harmonised Inflation Rate MoM Prel - https://tradingeconomics.com/france/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMPreliminary = "harmonized inflation rate mom preliminary";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Harmonised Inflation Rate YoY Final - https://tradingeconomics.com/france/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYFinal = "harmonized inflation rate yoy final";

            /// <summary>
            /// Harmonised Inflation Rate YoY Prel - https://tradingeconomics.com/france/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYPreliminary = "harmonized inflation rate yoy preliminary";

            /// <summary>
            /// Household Consumption MoM - https://tradingeconomics.com/france/personal-spending
            /// </summary>
            public const string HouseholdConsumptionMoM = "household consumption mom";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/france/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/france/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate MoM Final - https://tradingeconomics.com/france/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMFinal = "inflation rate mom final";

            /// <summary>
            /// Inflation Rate MoM Prel - https://tradingeconomics.com/france/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMPreliminary = "inflation rate mom preliminary";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/france/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Inflation Rate YoY Final - https://tradingeconomics.com/france/inflation-cpi
            /// </summary>
            public const string InflationRateYoYFinal = "inflation rate yoy final";

            /// <summary>
            /// Inflation Rate YoY Prel - https://tradingeconomics.com/france/inflation-cpi
            /// </summary>
            public const string InflationRateYoYPreliminary = "inflation rate yoy preliminary";

            /// <summary>
            /// Jobseekers Total - https://tradingeconomics.com/france/unemployed-persons
            /// </summary>
            /// <remarks>
            /// Source: DARES, France
            /// </remarks>
            public const string JobseekersTotal = "jobseekers total";

            /// <summary>
            /// Manufacturing PMI - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string ManufacturingPurchasingManagersIndex = "manufacturing purchasing managers index";

            /// <summary>
            /// Markit Composite PMI Final - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFinal = "markit composite purchasing managers index final";

            /// <summary>
            /// Markit Composite PMI Flash - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFlash = "markit composite purchasing managers index flash";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/france/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Markit Manufacturing PMI Final - https://tradingeconomics.com/france/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFinal = "markit manufacturing purchasing managers index final";

            /// <summary>
            /// Markit Manufacturing PMI Flash - https://tradingeconomics.com/france/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFlash = "markit manufacturing purchasing managers index flash";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// Markit Services PMI Final - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFinal = "markit services purchasing managers index final";

            /// <summary>
            /// Markit Services PMI Flash - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFlash = "markit services purchasing managers index flash";

            /// <summary>
            /// Non Farm Payrolls QoQ - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string NonFarmPayrollsQoQ = "non farm payrolls qoq";

            /// <summary>
            /// Non Farm Payrolls QoQ Final - https://tradingeconomics.com/france/non-farm-payrolls
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string NonFarmPayrollsQoQFinal = "non farm payrolls qoq final";

            /// <summary>
            /// Non Farm Payrolls QoQ Prel - https://tradingeconomics.com/france/non-farm-payrolls
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string NonFarmPayrollsQoQPreliminary = "non farm payrolls qoq preliminary";

            /// <summary>
            /// Private Non Farm Payrolls QoQ Final - https://tradingeconomics.com/france/nonfarm-payrolls-private
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string PrivateNonFarmPayrollsQoQFinal = "private non farm payrolls qoq final";

            /// <summary>
            /// Private Non Farm Payrolls QoQ Prel - https://tradingeconomics.com/france/nonfarm-payrolls-private
            /// </summary>
            /// <remarks>
            /// Source: INSEE, France
            /// </remarks>
            public const string PrivateNonFarmPayrollsQoQPreliminary = "private non farm payrolls qoq preliminary";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/france/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/france/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/france/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Services PMI - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string ServicesPurchasingManagersIndex = "services purchasing managers index";

            /// <summary>
            /// 6-Month BTF Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string SixMonthBtfAuction = "6 month btf auction";

            /// <summary>
            /// 10-Year OAT Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string TenYearOatAuction = "10 year oat auction";

            /// <summary>
            /// 3-Month BTF Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string ThreeMonthBtfAuction = "3 month btf auction";

            /// <summary>
            /// 3-Year BTAN Auction - https://tradingeconomics.com/france/3-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Agence France Trésor
            /// </remarks>
            public const string ThreeYearBtanAuction = "3 year btan auction";

            /// <summary>
            /// 12-Month BTF Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string TwelveMonthBtfAuction = "12 month btf auction";

            /// <summary>
            /// 2-Year BTAN Auction - https://tradingeconomics.com/france/calendar
            /// </summary>
            public const string TwoYearBtanAuction = "2 year btan auction";

            /// <summary>
            /// Unemployment Benefit Claims - https://tradingeconomics.com/france/initial-jobless-claims
            /// </summary>
            /// <remarks>
            /// Source: DARES, France
            /// </remarks>
            public const string UnemploymentBenefitClaims = "unemployment benefit claims";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/france/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Germany
        /// </summary>
        public static class Germany
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/germany/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Balance of Trade s.a - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string BalanceOfTradeSeasonallyAdjusted = "balance of trade seasonally adjusted";

            /// <summary>
            /// Construction PMI - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ConstructionPurchasingManagersIndex = "construction purchasing managers index";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/germany/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Employed Persons - https://tradingeconomics.com/germany/employed-persons
            /// </summary>
            /// <remarks>
            /// Source: Bundesagentur für Arbeit
            /// </remarks>
            public const string EmployedPersons = "employed persons";

            /// <summary>
            /// Exports MoM - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ExportsMoM = "exports mom";

            /// <summary>
            /// Exports MoM s.a - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ExportsMoMSeasonallyAdjusted = "exports mom seasonally adjusted";

            /// <summary>
            /// Factory Orders MoM - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string FactoryOrdersMoM = "factory orders mom";

            /// <summary>
            /// Factory Orders YoY - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string FactoryOrdersYoY = "factory orders yoy";

            /// <summary>
            /// 5-Year Bobl Auction - https://tradingeconomics.com/germany/5-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury
            /// </remarks>
            public const string FiveYearBoblAuction = "5 year bobl auction";

            /// <summary>
            /// Full Year GDP Growth - https://tradingeconomics.com/germany/gdp-growth-annual
            /// </summary>
            public const string FullYearGdpGrowth = "full year gdp growth";

            /// <summary>
            /// GDP Growth Rate - https://tradingeconomics.com/germany/gdp-growth
            /// </summary>
            /// <remarks>
            /// Source: Federal Statistical Office
            /// </remarks>
            public const string GdpGrowthRate = "gdp growth rate";

            /// <summary>
            /// GDP Growth Rate Flash - https://tradingeconomics.com/germany/gdp-growth-annual
            /// </summary>
            /// <remarks>
            /// Source: Federal Statistical Office
            /// </remarks>
            public const string GdpGrowthRateFlash = "gdp growth rate flash";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/germany/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/germany/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/germany/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/germany/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/germany/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/germany/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/germany/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// Gfk Consumer Confidence - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string GfkConsumerConfidence = "gfk consumer confidence";

            /// <summary>
            /// Government Budget - https://tradingeconomics.com/germany/government-budget
            /// </summary>
            public const string GovernmentBudget = "government budget";

            /// <summary>
            /// Harmonised Inflation Rate MoM - https://tradingeconomics.com/germany/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoM = "harmonized inflation rate mom";

            /// <summary>
            /// Harmonised Inflation Rate MoM Final - https://tradingeconomics.com/germany/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMFinal = "harmonized inflation rate mom final";

            /// <summary>
            /// Harmonised Inflation Rate MoM Prel - https://tradingeconomics.com/germany/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMPreliminary = "harmonized inflation rate mom preliminary";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Harmonised Inflation Rate YoY Final - https://tradingeconomics.com/germany/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYFinal = "harmonized inflation rate yoy final";

            /// <summary>
            /// Harmonised Inflation Rate YoY Prel - https://tradingeconomics.com/germany/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYPreliminary = "harmonized inflation rate yoy preliminary";

            /// <summary>
            /// IFO Business Climate - https://tradingeconomics.com/germany/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Ifo Institute
            /// </remarks>
            public const string IfoBusinessClimate = "ifo business climate";

            /// <summary>
            /// IFO - Current Assessment - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string IfoCurrentAssessment = "ifo current assessment";

            /// <summary>
            /// IFO Current Conditions - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string IfoCurrentConditions = "ifo current conditions";

            /// <summary>
            /// IFO Expectations - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string IfoExpectations = "ifo expectations";

            /// <summary>
            /// Import Prices MoM - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ImportPricesMoM = "import prices mom";

            /// <summary>
            /// Import Prices YoY - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ImportPricesYoY = "import prices yoy";

            /// <summary>
            /// Imports MoM s.a - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ImportsMoMSeasonallyAdjusted = "imports mom seasonally adjusted";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/germany/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/germany/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate MoM Final - https://tradingeconomics.com/germany/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMFinal = "inflation rate mom final";

            /// <summary>
            /// Inflation Rate MoM Prel - https://tradingeconomics.com/germany/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMPreliminary = "inflation rate mom preliminary";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/germany/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Inflation Rate YoY Final - https://tradingeconomics.com/germany/inflation-cpi
            /// </summary>
            public const string InflationRateYoYFinal = "inflation rate yoy final";

            /// <summary>
            /// Inflation Rate YoY Prel - https://tradingeconomics.com/germany/inflation-cpi
            /// </summary>
            public const string InflationRateYoYPreliminary = "inflation rate yoy preliminary";

            /// <summary>
            /// Job Vacancies - https://tradingeconomics.com/germany/job-vacancies
            /// </summary>
            public const string JobVacancies = "job vacancies";

            /// <summary>
            /// Markit/BME Manufacturing PMI Final - https://tradingeconomics.com/germany/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitBmeManufacturingPurchasingManagersIndexFinal = "markit bme manufacturing purchasing managers index final";

            /// <summary>
            /// Markit/BME Manufacturing PMI Flash - https://tradingeconomics.com/germany/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitBmeManufacturingPurchasingManagersIndexFlash = "markit bme manufacturing purchasing managers index flash";

            /// <summary>
            /// Markit Composite PMI Final - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFinal = "markit composite purchasing managers index final";

            /// <summary>
            /// Markit Composite PMI Flash - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFlash = "markit composite purchasing managers index flash";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/germany/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Markit Manufacturing PMI Final - https://tradingeconomics.com/germany/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFinal = "markit manufacturing purchasing managers index final";

            /// <summary>
            /// Markit Manufacturing PMI Flash - https://tradingeconomics.com/germany/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFlash = "markit manufacturing purchasing managers index flash";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// Markit Services PMI Final - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFinal = "markit services purchasing managers index final";

            /// <summary>
            /// Markit Services PMI Flash - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFlash = "markit services purchasing managers index flash";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/germany/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/germany/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/germany/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Services PMI - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ServicesPurchasingManagersIndex = "services purchasing managers index";

            /// <summary>
            /// 10-Year Bund Auction - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string TenYearBundAuction = "10 year bund auction";

            /// <summary>
            /// 30-Year Bund Auction - https://tradingeconomics.com/germany/30-year-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury
            /// </remarks>
            public const string ThirtyYearBundAuction = "30 year bund auction";

            /// <summary>
            /// 12-Month Bubill Auction - https://tradingeconomics.com/germany/52-week-bill-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury
            /// </remarks>
            public const string TwelveMonthBubillAuction = "12 month bubill auction";

            /// <summary>
            /// 2-Year Schatz Auction - https://tradingeconomics.com/germany/2-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury
            /// </remarks>
            public const string TwoYearSchatzAuction = "2 year schatz auction";

            /// <summary>
            /// Unemployed Persons NSA - https://tradingeconomics.com/germany/unemployed-persons
            /// </summary>
            /// <remarks>
            /// Source: Bundesagentur für Arbeit
            /// </remarks>
            public const string UnemployedPersonsNotSeasonallyAdjusted = "unemployed persons not seasonally adjusted";

            /// <summary>
            /// Unemployment Change - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string UnemploymentChange = "unemployment change";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/germany/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Unemployment Rate Harmonised - https://tradingeconomics.com/germany/unemployment-rate
            /// </summary>
            /// <remarks>
            /// Source: Federal Statistical Office
            /// </remarks>
            public const string UnemploymentRateHarmonized = "unemployment rate harmonized";

            /// <summary>
            /// Wholesale Prices MoM - https://tradingeconomics.com/germany/wholesale-prices
            /// </summary>
            public const string WholesalePricesMoM = "wholesale prices mom";

            /// <summary>
            /// Wholesale Prices YoY - https://tradingeconomics.com/germany/wholesale-prices
            /// </summary>
            public const string WholesalePricesYoY = "wholesale prices yoy";

            /// <summary>
            /// ZEW Current Conditions - https://tradingeconomics.com/germany/calendar
            /// </summary>
            public const string ZewCurrentConditions = "zew current conditions";

            /// <summary>
            /// ZEW Economic Sentiment Index - https://tradingeconomics.com/germany/zew-economic-sentiment-index
            /// </summary>
            public const string ZewEconomicSentimentIndex = "zew economic sentiment index";

        }

        /// <summary>
        /// Greece
        /// </summary>
        public static class Greece
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/greece/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/greece/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/greece/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/greece/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Credit Expansion YoY - https://tradingeconomics.com/greece/loan-growth
            /// </summary>
            /// <remarks>
            /// Source: Bank of Greece
            /// </remarks>
            public const string CreditExpansionYoY = "credit expansion yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/greece/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Annual Growth Rate YoY - Preliminary - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            /// <remarks>
            /// Source: National Statistical Service of Greece
            /// </remarks>
            public const string GdpAnnualGrowthRateYoYPreliminary = "gdp annual growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/greece/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/greece/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/greece/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Adv - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYAdvance = "gdp growth rate yoy advance";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/greece/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/greece/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/greece/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/greece/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/greece/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Loans to Private Sector - https://tradingeconomics.com/greece/loans-to-private-sector
            /// </summary>
            /// <remarks>
            /// Source: Bank of Greece
            /// </remarks>
            public const string LoansToPrivateSector = "loans to private sector";

            /// <summary>
            /// Loans to Private Sector YoY - https://tradingeconomics.com/greece/loans-to-private-sector
            /// </summary>
            /// <remarks>
            /// Source: Bank of Greece
            /// </remarks>
            public const string LoansToPrivateSectorYoY = "loans to private sector yoy";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/greece/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/greece/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Referendum on Bailout Terms - https://tradingeconomics.com/greece/calendar
            /// </summary>
            public const string ReferendumOnBailoutTerms = "referendum on bailout terms";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/greece/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/greece/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// 13-Week Bill Auction - https://tradingeconomics.com/greece/3-month-bill-yield
            /// </summary>
            /// <remarks>
            /// Source: Public Debt Management Agency
            /// </remarks>
            public const string ThirteenWeekBillAuction = "13 week bill auction";

            /// <summary>
            /// Total Credit YoY - https://tradingeconomics.com/greece/loan-growth
            /// </summary>
            /// <remarks>
            /// Source: Bank of Greece
            /// </remarks>
            public const string TotalCreditYoY = "total credit yoy";

            /// <summary>
            /// 26-Week Bill Auction - https://tradingeconomics.com/greece/6-month-bill-yield
            /// </summary>
            /// <remarks>
            /// Source: Public Debt Management Agency
            /// </remarks>
            public const string TwentySixWeekBillAuction = "26 week bill auction";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/greece/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Ireland
        /// </summary>
        public static class Ireland
        {
            /// <summary>
            /// AIB Manufacturing PMI - https://tradingeconomics.com/ireland/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string AibManufacturingPurchasingManagersIndex = "aib manufacturing purchasing managers index";

            /// <summary>
            /// AIB Services PMI - https://tradingeconomics.com/ireland/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string AibServicesPurchasingManagersIndex = "aib services purchasing managers index";

            /// <summary>
            /// Average Weekly Earnings YoY - https://tradingeconomics.com/ireland/wage-growth
            /// </summary>
            public const string AverageWeeklyEarningsYoY = "average weekly earnings yoy";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/ireland/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Balance of Trade-Final - https://tradingeconomics.com/ireland/balance-of-trade
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string BalanceOfTradeFinal = "balance of trade final";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/ireland/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Construction PMI - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string ConstructionPurchasingManagersIndex = "construction purchasing managers index";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/ireland/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Core Inflation Rate - https://tradingeconomics.com/ireland/core-inflation-rate
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string CoreInflationRate = "core inflation rate";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/ireland/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// ESRI Consumer Sentiment Index - https://tradingeconomics.com/ireland/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: KBC Bank Ireland/ESRI
            /// </remarks>
            public const string EsriConsumerSentimentIndex = "esri consumer sentiment index";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/ireland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/ireland/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GNP QoQ - https://tradingeconomics.com/ireland/gross-national-product
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string GnpQoQ = "gnp qoq";

            /// <summary>
            /// GNP YoY - https://tradingeconomics.com/ireland/gross-national-product
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string GnpYoY = "gnp yoy";

            /// <summary>
            /// Harmonised Inflation Rate MoM - https://tradingeconomics.com/ireland/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoM = "harmonized inflation rate mom";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Household Saving Ratio - https://tradingeconomics.com/ireland/personal-savings
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string HouseholdSavingRatio = "household saving ratio";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/ireland/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/ireland/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/ireland/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Investec Manufacturing PMI - https://tradingeconomics.com/ireland/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string InvestecManufacturingPurchasingManagersIndex = "investec manufacturing purchasing managers index";

            /// <summary>
            /// Investec Services PMI - https://tradingeconomics.com/ireland/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string InvestecServicesPurchasingManagersIndex = "investec services purchasing managers index";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// Purchasing Manager Index Manufacturing - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string PurchasingManagerIndexManufacturing = "purchasing manager index manufacturing";

            /// <summary>
            /// Purchasing Manager Index Services - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string PurchasingManagerIndexServices = "purchasing manager index services";

            /// <summary>
            /// PMI Services - https://tradingeconomics.com/ireland/calendar
            /// </summary>
            public const string PurchasingManagersIndexServices = "purchasing managers index services";

            /// <summary>
            /// Residential Property Prices MoM - https://tradingeconomics.com/ireland/housing-index
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string ResidentialPropertyPricesMoM = "residential property prices mom";

            /// <summary>
            /// Residential Property Prices YoY - https://tradingeconomics.com/ireland/housing-index
            /// </summary>
            /// <remarks>
            /// Source: Central Statistics Office Ireland
            /// </remarks>
            public const string ResidentialPropertyPricesYoY = "residential property prices yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/ireland/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/ireland/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/ireland/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wholesale Prices MoM - https://tradingeconomics.com/ireland/wholesale-prices
            /// </summary>
            public const string WholesalePricesMoM = "wholesale prices mom";

            /// <summary>
            /// Wholesale Prices YoY - https://tradingeconomics.com/ireland/wholesale-prices
            /// </summary>
            public const string WholesalePricesYoY = "wholesale prices yoy";

        }

        /// <summary>
        /// Italy
        /// </summary>
        public static class Italy
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/italy/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/italy/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/italy/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/italy/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/italy/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// 5-Year BTP Auction - https://tradingeconomics.com/italy/5-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string FiveYearBtpAuction = "5 year btp auction";

            /// <summary>
            /// Full Year GDP Growth - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string FullYearGdpGrowth = "full year gdp growth";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRate = "gdp growth rate";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/italy/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Adv - https://tradingeconomics.com/italy/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQAdvance = "gdp growth rate qoq advance";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/italy/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/italy/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Adv - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYAdvance = "gdp growth rate yoy advance";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/italy/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// Government Budget - https://tradingeconomics.com/italy/government-budget
            /// </summary>
            public const string GovernmentBudget = "government budget";

            /// <summary>
            /// Harmonised Inflation Rate MoM Final - https://tradingeconomics.com/italy/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMFinal = "harmonized inflation rate mom final";

            /// <summary>
            /// Harmonised Inflation Rate MoM Prel - https://tradingeconomics.com/italy/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMPreliminary = "harmonized inflation rate mom preliminary";

            /// <summary>
            /// Harmonised Inflation Rate YoY Final - https://tradingeconomics.com/italy/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYFinal = "harmonized inflation rate yoy final";

            /// <summary>
            /// Harmonised Inflation Rate YoY Prel - https://tradingeconomics.com/italy/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYPreliminary = "harmonized inflation rate yoy preliminary";

            /// <summary>
            /// Industrial Orders MoM - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string IndustrialOrdersMoM = "industrial orders mom";

            /// <summary>
            /// Industrial Orders YoY - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string IndustrialOrdersYoY = "industrial orders yoy";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/italy/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Industrial Sales MoM - https://tradingeconomics.com/italy/manufacturing-sales
            /// </summary>
            public const string IndustrialSalesMoM = "industrial sales mom";

            /// <summary>
            /// Industrial Sales YoY - https://tradingeconomics.com/italy/manufacturing-sales
            /// </summary>
            public const string IndustrialSalesYoY = "industrial sales yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/italy/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate MoM Final - https://tradingeconomics.com/italy/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMFinal = "inflation rate mom final";

            /// <summary>
            /// Inflation Rate MoM Prel - https://tradingeconomics.com/italy/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMPreliminary = "inflation rate mom preliminary";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/italy/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Inflation Rate YoY Final - https://tradingeconomics.com/italy/inflation-cpi
            /// </summary>
            public const string InflationRateYoYFinal = "inflation rate yoy final";

            /// <summary>
            /// Inflation Rate YoY Prel - https://tradingeconomics.com/italy/inflation-cpi
            /// </summary>
            public const string InflationRateYoYPreliminary = "inflation rate yoy preliminary";

            /// <summary>
            /// Manufacturing PMI - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string ManufacturingPurchasingManagersIndex = "manufacturing purchasing managers index";

            /// <summary>
            /// Markit/ADACI Manufacturing PMI - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string MarkitAdaciManufacturingPurchasingManagersIndex = "markit adaci manufacturing purchasing managers index";

            /// <summary>
            /// Markit/ADACI Services PMI - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string MarkitAdaciServicesPurchasingManagersIndex = "markit adaci services purchasing managers index";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/italy/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/italy/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/italy/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// 7-Year BTP Auction - https://tradingeconomics.com/italy/7-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string SevenYearBtpAuction = "7 year btp auction";

            /// <summary>
            /// 6-Month BOT Auction - https://tradingeconomics.com/italy/6-month-bill-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string SixMonthBotAuction = "6 month bot auction";

            /// <summary>
            /// 10-Year Bond Auction - https://tradingeconomics.com/italy/government-bond-yield
            /// </summary>
            public const string TenYearBondAuction = "10 year bond auction";

            /// <summary>
            /// 10-Year BTP Auction - https://tradingeconomics.com/italy/government-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string TenYearBtpAuction = "10 year btp auction";

            /// <summary>
            /// 30-Year BTP Auction - https://tradingeconomics.com/italy/30-year-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string ThirtyYearBtpAuction = "30 year btp auction";

            /// <summary>
            /// 3-Year BTP Auction - https://tradingeconomics.com/italy/3-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string ThreeYearBtpAuction = "3 year btp auction";

            /// <summary>
            /// 12-Month BOT Auction - https://tradingeconomics.com/italy/52-week-bill-yield
            /// </summary>
            /// <remarks>
            /// Source: Dipartimento del Tesoro
            /// </remarks>
            public const string TwelveMonthBotAuction = "12 month bot auction";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/italy/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Wage Inflation MoM - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string WageInflationMoM = "wage inflation mom";

            /// <summary>
            /// Wage Inflation YoY - https://tradingeconomics.com/italy/calendar
            /// </summary>
            public const string WageInflationYoY = "wage inflation yoy";

        }

        /// <summary>
        /// Japan
        /// </summary>
        public static class Japan
        {
            /// <summary>
            /// All Industry Activity Index MoM - https://tradingeconomics.com/japan/all-industry-activity-index
            /// </summary>
            public const string AllIndustryActivityIndexMoM = "all industry activity index mom";

            /// <summary>
            /// Average Cash Earnings YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string AverageCashEarningsYoY = "average cash earnings yoy";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/japan/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Bank Lending YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string BankLendingYoY = "bank lending yoy";

            /// <summary>
            /// BoJ Interest Rate Decision - https://tradingeconomics.com/japan/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of Japan
            /// </remarks>
            public const string BankOfJapanInterestRateDecision = "bank of japan interest rate decision";

            /// <summary>
            /// BSI Large Manufacturing QoQ - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string BusinessSurveyIndexLargeManufacturingQoQ = "business survey index large manufacturing qoq";

            /// <summary>
            /// Capacity Utilization MoM - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string CapacityUtilizationMoM = "capacity utilization mom";

            /// <summary>
            /// Capital Spending YoY - https://tradingeconomics.com/japan/private-investment
            /// </summary>
            public const string CapitalSpendingYoY = "capital spending yoy";

            /// <summary>
            /// Coincident Index - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string CoincidentIndex = "coincident index";

            /// <summary>
            /// Coincident Index Final - https://tradingeconomics.com/japan/coincident-index
            /// </summary>
            public const string CoincidentIndexFinal = "coincident index final";

            /// <summary>
            /// Coincident Index Prel - https://tradingeconomics.com/japan/coincident-index
            /// </summary>
            public const string CoincidentIndexPreliminary = "coincident index preliminary";

            /// <summary>
            /// Construction Orders YoY - https://tradingeconomics.com/japan/construction-orders
            /// </summary>
            public const string ConstructionOrdersYoY = "construction orders yoy";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/japan/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Consumer Confidence Households - https://tradingeconomics.com/japan/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string ConsumerConfidenceHouseholds = "consumer confidence households";

            /// <summary>
            /// CPI Ex-Fresh Food YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ConsumerPriceIndexExcludingFreshFoodYoY = "consumer price index excluding fresh food yoy";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Corporate Service Price YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string CorporateServicePriceYoY = "corporate service price yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/japan/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Domestic Corporate Goods Price Index (MoM) - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string DomesticCorporateGoodsPriceIndexMoM = "domestic corporate goods price index mom";

            /// <summary>
            /// Domestic Corporate Goods Price Index (YoY) - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string DomesticCorporateGoodsPriceIndexYoY = "domestic corporate goods price index yoy";

            /// <summary>
            /// Eco Watchers Survey Current - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string EcoWatchersSurveyCurrent = "eco watchers survey current";

            /// <summary>
            /// Eco Watchers Survey Outlook - https://tradingeconomics.com/japan/economy-watchers-survey
            /// </summary>
            public const string EcoWatchersSurveyOutlook = "eco watchers survey outlook";

            /// <summary>
            /// Exports - https://tradingeconomics.com/japan/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// Exports YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ExportsYoY = "exports yoy";

            /// <summary>
            /// Foreign Bond Investment - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ForeignBondInvestment = "foreign bond investment";

            /// <summary>
            /// Foreign Exchange Reserves - https://tradingeconomics.com/japan/foreign-exchange-reserves
            /// </summary>
            public const string ForeignExchangeReserves = "foreign exchange reserves";

            /// <summary>
            /// Foreign investment in Japan stocks - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ForeignInvestmentInJapanStocks = "foreign investment in japan stocks";

            /// <summary>
            /// GDP Annual Growth Rate YoY Final - https://tradingeconomics.com/japan/gdp-growth-annual
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpAnnualGrowthRateYoYFinal = "gdp annual growth rate yoy final";

            /// <summary>
            /// GDP Capital Expenditure QoQ - https://tradingeconomics.com/japan/gross-fixed-capital-formation
            /// </summary>
            public const string GdpCapitalExpenditureQoQ = "gdp capital expenditure qoq";

            /// <summary>
            /// GDP Capital Expenditure QoQ Final - https://tradingeconomics.com/japan/gross-fixed-capital-formation
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpCapitalExpenditureQoQFinal = "gdp capital expenditure qoq final";

            /// <summary>
            /// GDP Capital Expenditure QoQ Prel - https://tradingeconomics.com/japan/gross-fixed-capital-formation
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpCapitalExpenditureQoQPreliminary = "gdp capital expenditure qoq preliminary";

            /// <summary>
            /// GDP Deflator YoY Final - https://tradingeconomics.com/japan/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpDeflatorYoYFinal = "gdp deflator yoy final";

            /// <summary>
            /// GDP Deflator YoY Prel - https://tradingeconomics.com/japan/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpDeflatorYoYPreliminary = "gdp deflator yoy preliminary";

            /// <summary>
            /// GDP External Demand QoQ - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpExternalDemandQoQ = "gdp external demand qoq";

            /// <summary>
            /// GDP External Demand QoQ Final - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpExternalDemandQoQFinal = "gdp external demand qoq final";

            /// <summary>
            /// GDP External Demand QoQ Prel - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpExternalDemandQoQPreliminary = "gdp external demand qoq preliminary";

            /// <summary>
            /// GDP Growth Annualized Final - https://tradingeconomics.com/japan/gdp-growth-annualized
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpGrowthAnnualizedFinal = "gdp growth annualized final";

            /// <summary>
            /// GDP Growth Annualized Prel - https://tradingeconomics.com/japan/gdp-growth-annualized
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpGrowthAnnualizedPreliminary = "gdp growth annualized preliminary";

            /// <summary>
            /// GDP Growth Annualized QoQ - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpGrowthAnnualizedQoQ = "gdp growth annualized qoq";

            /// <summary>
            /// GDP Growth Annualized QoQ Final - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpGrowthAnnualizedQoQFinal = "gdp growth annualized qoq final";

            /// <summary>
            /// GDP Growth Annualized QoQ Prel. - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GdpGrowthAnnualizedQoQPreliminary = "gdp growth annualized qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/japan/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/japan/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/japan/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Price Index YoY Final - https://tradingeconomics.com/japan/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpPriceIndexYoYFinal = "gdp price index yoy final";

            /// <summary>
            /// GDP Price Index YoY Prel - https://tradingeconomics.com/japan/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpPriceIndexYoYPreliminary = "gdp price index yoy preliminary";

            /// <summary>
            /// GDP Private Consumption QoQ - https://tradingeconomics.com/japan/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpPrivateConsumptionQoQ = "gdp private consumption qoq";

            /// <summary>
            /// GDP Private Consumption QoQ Final - https://tradingeconomics.com/japan/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpPrivateConsumptionQoQFinal = "gdp private consumption qoq final";

            /// <summary>
            /// GDP Private Consumption QoQ Prel - https://tradingeconomics.com/japan/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string GdpPrivateConsumptionQoQPreliminary = "gdp private consumption qoq preliminary";

            /// <summary>
            /// Gross Domestic Product Annualized Final - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GrossDomesticProductAnnualizedFinal = "gross domestic product annualized final";

            /// <summary>
            /// Gross Domestic Product Annualized (R) - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string GrossDomesticProductAnnualizedRevised = "gross domestic product annualized revised";

            /// <summary>
            /// Household Spending MoM - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string HouseholdSpendingMoM = "household spending mom";

            /// <summary>
            /// Household Spending YoY - https://tradingeconomics.com/japan/household-spending
            /// </summary>
            public const string HouseholdSpendingYoY = "household spending yoy";

            /// <summary>
            /// Housing Starts YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string HousingStartsYoY = "housing starts yoy";

            /// <summary>
            /// Imports - https://tradingeconomics.com/japan/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Imports YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ImportsYoY = "imports yoy";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production MoM Final - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string IndustrialProductionMoMFinal = "industrial production mom final";

            /// <summary>
            /// Industrial Production MoM Prel - https://tradingeconomics.com/japan/industrial-production-mom
            /// </summary>
            public const string IndustrialProductionMoMPreliminary = "industrial production mom preliminary";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/japan/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Industrial Production YoY Final - https://tradingeconomics.com/japan/industrial-production
            /// </summary>
            /// <remarks>
            /// Source: Ministry of Economy Trade & Industry (METI)
            /// </remarks>
            public const string IndustrialProductionYoYFinal = "industrial production yoy final";

            /// <summary>
            /// Industrial Production YoY Prel - https://tradingeconomics.com/japan/industrial-production
            /// </summary>
            public const string IndustrialProductionYoYPreliminary = "industrial production yoy preliminary";

            /// <summary>
            /// Inflation Rate Ex-Food and Energy YoY - https://tradingeconomics.com/japan/core-inflation-rate
            /// </summary>
            public const string InflationRateExcludingFoodAndEnergyYoY = "inflation rate excluding food and energy yoy";

            /// <summary>
            /// Inflation Rate Ex-Fresh Food YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string InflationRateExcludingFreshFoodYoY = "inflation rate excluding fresh food yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/japan/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/japan/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Jibun Bank Composite PMI Final - https://tradingeconomics.com/japan/composite-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankCompositePurchasingManagersIndexFinal = "jibun bank composite purchasing managers index final";

            /// <summary>
            /// Jibun Bank Composite PMI Flash - https://tradingeconomics.com/japan/composite-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankCompositePurchasingManagersIndexFlash = "jibun bank composite purchasing managers index flash";

            /// <summary>
            /// Jibun Bank Manufacturing PMI Final - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankManufacturingPurchasingManagersIndexFinal = "jibun bank manufacturing purchasing managers index final";

            /// <summary>
            /// Jibun Bank Manufacturing PMI Flash - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankManufacturingPurchasingManagersIndexFlash = "jibun bank manufacturing purchasing managers index flash";

            /// <summary>
            /// Jibun Bank Services PMI - https://tradingeconomics.com/japan/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankServicesPurchasingManagersIndex = "jibun bank services purchasing managers index";

            /// <summary>
            /// Jibun Bank Services PMI Final - https://tradingeconomics.com/japan/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankServicesPurchasingManagersIndexFinal = "jibun bank services purchasing managers index final";

            /// <summary>
            /// Jibun Bank Services PMI Flash - https://tradingeconomics.com/japan/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string JibunBankServicesPurchasingManagersIndexFlash = "jibun bank services purchasing managers index flash";

            /// <summary>
            /// Jobs/applications ratio - https://tradingeconomics.com/japan/jobs-to-applications-ratio
            /// </summary>
            public const string JobsApplicationsRatio = "jobs applications ratio";

            /// <summary>
            /// JP Foreign Reserves - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string JpForeignReserves = "jp foreign reserves";

            /// <summary>
            /// Large Retailer's Sales - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string LargeRetailersSales = "large retailers sales";

            /// <summary>
            /// Leading Composite Index Final - https://tradingeconomics.com/japan/leading-economic-index
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string LeadingCompositeIndexFinal = "leading composite index final";

            /// <summary>
            /// Leading Composite Index Prel - https://tradingeconomics.com/japan/leading-economic-index
            /// </summary>
            /// <remarks>
            /// Source: Cabinet Office, Japan
            /// </remarks>
            public const string LeadingCompositeIndexPreliminary = "leading composite index preliminary";

            /// <summary>
            /// Leading Economic Index - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string LeadingEconomicIndex = "leading economic index";

            /// <summary>
            /// Leading Economic Index Final - https://tradingeconomics.com/japan/leading-economic-index
            /// </summary>
            public const string LeadingEconomicIndexFinal = "leading economic index final";

            /// <summary>
            /// Leading Economic Index Prel - https://tradingeconomics.com/japan/leading-economic-index
            /// </summary>
            public const string LeadingEconomicIndexPreliminary = "leading economic index preliminary";

            /// <summary>
            /// Machine Tool Orders YoY - https://tradingeconomics.com/japan/machine-tool-orders
            /// </summary>
            public const string MachineToolOrdersYoY = "machine tool orders yoy";

            /// <summary>
            /// Machinery Orders MoM - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string MachineryOrdersMoM = "machinery orders mom";

            /// <summary>
            /// Machinery Orders YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string MachineryOrdersYoY = "machinery orders yoy";

            /// <summary>
            /// Manufacturing PMI - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ManufacturingPurchasingManagersIndex = "manufacturing purchasing managers index";

            /// <summary>
            /// Markit/JMMA Manufacturing PMI - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitJmmaManufacturingPurchasingManagersIndex = "markit jmma manufacturing purchasing managers index";

            /// <summary>
            /// Markit/JMMA Manufacturing PMI Final - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitJmmaManufacturingPurchasingManagersIndexFinal = "markit jmma manufacturing purchasing managers index final";

            /// <summary>
            /// Markit/JMMA Manufacturing PMI Flash - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitJmmaManufacturingPurchasingManagersIndexFlash = "markit jmma manufacturing purchasing managers index flash";

            /// <summary>
            /// Nikkei Markit Services PMI - https://tradingeconomics.com/japan/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitNikkeiServicesPurchasingManagersIndex = "markit nikkei services purchasing managers index";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// Monetary Base (YoY) - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string MonetaryBaseYoY = "monetary base yoy";

            /// <summary>
            /// Money Supply M2+CD (YoY) - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string MoneySupplyM2CdYoY = "money supply m2cd yoy";

            /// <summary>
            /// National Core Inflation Rate YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string NationalCoreInflationRateYoY = "national core inflation rate yoy";

            /// <summary>
            /// Nikkei Manufacturing PMI Final - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string NikkeiManufacturingPurchasingManagersIndexFinal = "nikkei manufacturing purchasing managers index final";

            /// <summary>
            /// Nikkei Manufacturing PMI Flash - https://tradingeconomics.com/japan/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string NikkeiManufacturingPurchasingManagersIndexFlash = "nikkei manufacturing purchasing managers index flash";

            /// <summary>
            /// Nikkei Services PMI - https://tradingeconomics.com/japan/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string NikkeiServicesPurchasingManagersIndex = "nikkei services purchasing managers index";

            /// <summary>
            /// Nomura/JMMA Manufacturing PMI - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string NomuraJmmaManufacturingPurchasingManagersIndex = "nomura jmma manufacturing purchasing managers index";

            /// <summary>
            /// Overall Household Spending YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string OverallHouseholdSpendingYoY = "overall household spending yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/japan/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/japan/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/japan/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Reuters Tankan Index - https://tradingeconomics.com/japan/reuters-tankan-index
            /// </summary>
            public const string ReutersTankanIndex = "reuters tankan index";

            /// <summary>
            /// Stock Investment by Foreigners - https://tradingeconomics.com/japan/foreign-stock-investment
            /// </summary>
            public const string StockInvestmentByForeigners = "stock investment by foreigners";

            /// <summary>
            /// Tankan Large All Industry Capex - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanAllLargeIndustryCapitalExpenditure = "tankan all large industry capital expenditure";

            /// <summary>
            /// Tankan All Small Industry CAPEX - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanAllSmallIndustryCapitalExpenditure = "tankan all small industry capital expenditure";

            /// <summary>
            /// Tankan Large Manufacturers Index - https://tradingeconomics.com/japan/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Bank of Japan
            /// </remarks>
            public const string TankanLargeManufacturingIndex = "tankan large manufacturing index";

            /// <summary>
            /// Tankan Large Manufacturing Outlook - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanLargeManufacturingOutlook = "tankan large manufacturing outlook";

            /// <summary>
            /// Tankan Large Non-Manufacturing Index - https://tradingeconomics.com/japan/non-manufacturing-pmi
            /// </summary>
            public const string TankanLargeNonManufacturingIndex = "tankan large non manufacturing index";

            /// <summary>
            /// Tankan Non-Manufacturing Index - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanNonManufacturingIndex = "tankan non manufacturing index";

            /// <summary>
            /// Tankan Non-Manufacturing Outlook - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanNonManufacturingOutlook = "tankan non manufacturing outlook";

            /// <summary>
            /// Tankan Small Manufacturers Index - https://tradingeconomics.com/japan/small-business-sentiment
            /// </summary>
            public const string TankanSmallManufacturingIndex = "tankan small manufacturing index";

            /// <summary>
            /// Tankan Small Manufacturing Outlook - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanSmallManufacturingOutlook = "tankan small manufacturing outlook";

            /// <summary>
            /// Tankan Small Non-Manufacturing Index - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanSmallNonManufacturingIndex = "tankan small non manufacturing index";

            /// <summary>
            /// Tankan Small Non-Manufacturing Outlook - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TankanSmallNonManufacturingOutlook = "tankan small non manufacturing outlook";

            /// <summary>
            /// 10-Year JGB Auction - https://tradingeconomics.com/japan/government-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Ministry of Finance, Japan
            /// </remarks>
            public const string TenYearJgbAuction = "10 year jgb auction";

            /// <summary>
            /// Tertiary Industry Index MoM - https://tradingeconomics.com/japan/tertiary-industry-index
            /// </summary>
            public const string TertiaryIndustryIndexMoM = "tertiary industry index mom";

            /// <summary>
            /// 30-Year JGB Auction - https://tradingeconomics.com/japan/30-year-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Ministry of Finance, Japan
            /// </remarks>
            public const string ThirtyYearJgbAuction = "30 year jgb auction";

            /// <summary>
            /// Tokyo CPI YoY - https://tradingeconomics.com/japan/tokyo-cpi
            /// </summary>
            /// <remarks>
            /// Source: Ministry of Internal Affairs & Communications
            /// </remarks>
            public const string TokyoConsumerPriceIndexYoY = "tokyo consumer price index yoy";

            /// <summary>
            /// Tokyo Core CPI YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string TokyoCoreConsumerPriceIndexYoY = "tokyo core consumer price index yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/japan/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Vehicle Sales YoY - https://tradingeconomics.com/japan/calendar
            /// </summary>
            public const string VehicleSalesYoY = "vehicle sales yoy";

        }

        /// <summary>
        /// Latvia
        /// </summary>
        public static class Latvia
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/latvia/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/latvia/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/latvia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/latvia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/latvia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/latvia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/latvia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/latvia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/latvia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/latvia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/latvia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/latvia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/latvia/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/latvia/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/latvia/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/latvia/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/latvia/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/latvia/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/latvia/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/latvia/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/latvia/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Lithuania
        /// </summary>
        public static class Lithuania
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/lithuania/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/lithuania/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/lithuania/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/lithuania/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/lithuania/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/lithuania/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/lithuania/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/lithuania/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/lithuania/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/lithuania/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/lithuania/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/lithuania/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/lithuania/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/lithuania/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/lithuania/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/lithuania/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/lithuania/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/lithuania/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/lithuania/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/lithuania/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary> /// Retail Sales MoM - https://tradingeconomics.com/lithuania/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/lithuania/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/lithuania/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Luxembourg
        /// </summary>
        public static class Luxembourg
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/luxembourg/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/luxembourg/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/luxembourg/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/luxembourg/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/luxembourg/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/luxembourg/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/luxembourg/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/luxembourg/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/luxembourg/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/luxembourg/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/luxembourg/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Malta
        /// </summary>
        public static class Malta
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/malta/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/malta/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/malta/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/malta/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/malta/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/malta/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/malta/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/malta/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/malta/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/malta/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Netherlands
        /// </summary>
        public static class Netherlands
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/netherlands/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/netherlands/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/netherlands/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Consumer Spending Volume - https://tradingeconomics.com/netherlands/calendar
            /// </summary>
            public const string ConsumerSpendingVolume = "consumer spending volume";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/netherlands/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/netherlands/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/netherlands/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/netherlands/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/netherlands/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/netherlands/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/netherlands/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/netherlands/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/netherlands/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/netherlands/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/netherlands/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Household Consumption YoY - https://tradingeconomics.com/netherlands/personal-spending
            /// </summary>
            /// <remarks>
            /// Source: Statistics Netherlands
            /// </remarks>
            public const string HouseholdConsumptionYoY = "household consumption yoy";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/netherlands/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/netherlands/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/netherlands/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Manufacturing Confidence - https://tradingeconomics.com/netherlands/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Statistics Netherlands
            /// </remarks>
            public const string ManufacturingConfidence = "manufacturing confidence";

            /// <summary>
            /// Manufacturing Production YoY - https://tradingeconomics.com/netherlands/calendar
            /// </summary>
            public const string ManufacturingProductionYoY = "manufacturing production yoy";

            /// <summary>
            /// NEVI Manufacturing PMI - https://tradingeconomics.com/netherlands/manufacturing-pmi
            /// </summary>
            public const string NeviManufacturingPurchasingManagersIndex = "nevi manufacturing purchasing managers index";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/netherlands/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/netherlands/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// 6-Month Bill Auction - https://tradingeconomics.com/netherlands/6-month-bill-yield
            /// </summary>
            public const string SixMonthBillAuction = "6 month bill auction";

            /// <summary>
            /// 10-Year Bond Auction - https://tradingeconomics.com/netherlands/government-bond-yield
            /// </summary>
            public const string TenYearBondAuction = "10 year bond auction";

            /// <summary>
            /// 3-Month Bill Auction - https://tradingeconomics.com/netherlands/3-month-bill-yield
            /// </summary>
            public const string ThreeMonthBillAuction = "3 month bill auction";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/netherlands/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// New Zealand
        /// </summary>
        public static class NewZealand
        {
            /// <summary>
            /// ANZ Business Confidence - https://tradingeconomics.com/new-zealand/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: ANZ Bank New Zealand
            /// </remarks>
            public const string AnzBusinessConfidence = "anz business confidence";

            /// <summary>
            /// ANZ Commodity Price - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string AnzCommodityPrice = "anz commodity price";

            /// <summary>
            /// ANZ Roy Morgan Consumer Confidence - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string AnzRoyMorganConsumerConfidence = "anz roy morgan consumer confidence";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/new-zealand/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Building Permits MoM - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string BuildingPermitsMoM = "building permits mom";

            /// <summary>
            /// Building Permits s.a. MoM - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string BuildingPermitsSeasonallyAdjustedMoM = "building permits seasonally adjusted mom";

            /// <summary>
            /// Business Inflation Expectations - https://tradingeconomics.com/new-zealand/inflation-expectations
            /// </summary>
            /// <remarks>
            /// Source: Reserve Bank of New Zealand
            /// </remarks>
            public const string BusinessInflationExpectations = "business inflation expectations";

            /// <summary>
            /// Business NZ PMI - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string BusinessNzPurchasingManagersIndex = "business nz purchasing managers index";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/new-zealand/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Electronic Card Retail Sales  (MoM) - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ElectronicCardRetailSalesMoM = "electronic card retail sales mom";

            /// <summary>
            /// Electronic Card Retail Sales (YoY) - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ElectronicCardRetailSalesYoY = "electronic card retail sales yoy";

            /// <summary>
            /// Electronic Retail Card Spending MoM - https://tradingeconomics.com/new-zealand/credit-card-spending
            /// </summary>
            public const string ElectronicRetailCardSpendingMoM = "electronic retail card spending mom";

            /// <summary>
            /// Electronic Retail Card Spending YoY - https://tradingeconomics.com/new-zealand/credit-card-spending
            /// </summary>
            public const string ElectronicRetailCardSpendingYoY = "electronic retail card spending yoy";

            /// <summary>
            /// Employment Change QoQ - https://tradingeconomics.com/new-zealand/employment-change
            /// </summary>
            /// <remarks>
            /// Source: Statistics New Zealand
            /// </remarks>
            public const string EmploymentChangeQoQ = "employment change qoq";

            /// <summary>
            /// Export Prices QoQ - https://tradingeconomics.com/new-zealand/export-prices
            /// </summary>
            public const string ExportPricesQoQ = "export prices qoq";

            /// <summary>
            /// Exports - https://tradingeconomics.com/new-zealand/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// Food Inflation YoY - https://tradingeconomics.com/new-zealand/food-inflation
            /// </summary>
            /// <remarks>
            /// Source: Statistics New Zealand
            /// </remarks>
            public const string FoodInflationYoY = "food inflation yoy";

            /// <summary>
            /// Food Price Index (MoM) - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string FoodPriceIndexMoM = "food price index mom";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/new-zealand/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/new-zealand/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// Global Dairy Trade Price Index - https://tradingeconomics.com/new-zealand/global-dairy-trade-price-index
            /// </summary>
            public const string GlobalDairyTradePriceIndex = "global dairy trade price index";

            /// <summary>
            /// Import Prices QoQ - https://tradingeconomics.com/new-zealand/import-prices
            /// </summary>
            public const string ImportPricesQoQ = "import prices qoq";

            /// <summary>
            /// Imports - https://tradingeconomics.com/new-zealand/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/new-zealand/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate QoQ - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string InflationRateQoQ = "inflation rate qoq";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/new-zealand/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Interest Rate Decision - https://tradingeconomics.com/new-zealand/interest-rate
            /// </summary>
            public const string InterestRateDecision = "interest rate decision";

            /// <summary>
            /// Labour Costs Index QoQ - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string LaborCostsIndexQoQ = "labor costs index qoq";

            /// <summary>
            /// Labour Costs Index YoY - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string LaborCostsIndexYoY = "labor costs index yoy";

            /// <summary>
            /// Manufacturing Production YoY - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ManufacturingProductionYoY = "manufacturing production yoy";

            /// <summary>
            /// Manufacturing sales - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ManufacturingSales = "manufacturing sales";

            /// <summary>
            /// Manufacturing Sales YoY - https://tradingeconomics.com/new-zealand/manufacturing-sales
            /// </summary>
            public const string ManufacturingSalesYoY = "manufacturing sales yoy";

            /// <summary>
            /// Business NZ/Markit PMI - https://tradingeconomics.com/new-zealand/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Business New Zealand
            /// </remarks>
            public const string MarkitBusinessNzPurchasingManagersIndex = "markit business nz purchasing managers index";

            /// <summary>
            /// NZIER Business Confidence - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string NzierBusinessConfidence = "nzier business confidence";

            /// <summary>
            /// NZIER Business Confidence QoQ - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string NzierBusinessConfidenceQoQ = "nzier business confidence qoq";

            /// <summary>
            /// NZIER Capacity Utilization - https://tradingeconomics.com/new-zealand/capacity-utilization
            /// </summary>
            /// <remarks>
            /// Source: New Zealand Institute of Economic Research
            /// </remarks>
            public const string NzierCapacityUtilization = "nzier capacity utilization";

            /// <summary>
            /// NZIER QSBO Capacity Utilization - https://tradingeconomics.com/new-zealand/capacity-utilization
            /// </summary>
            /// <remarks>
            /// Source: New Zealand Institute of Economic Research
            /// </remarks>
            public const string NzierQsboCapacityUtilization = "nzier qsbo capacity utilization";

            /// <summary>
            /// Participation Rate - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ParticipationRate = "participation rate";

            /// <summary>
            /// PPI Input QoQ - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ProducerPriceIndexInputQoQ = "producer price index input qoq";

            /// <summary>
            /// PPI Output QoQ - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string ProducerPriceIndexOutputQoQ = "producer price index output qoq";

            /// <summary>
            /// RBNZ Inflation Expectations (YoY) - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string RbnzInflationExpectationsYoY = "rbnz inflation expectations yoy";

            /// <summary>
            /// REINZ House Price Index MoM - https://tradingeconomics.com/new-zealand/housing-index
            /// </summary>
            /// <remarks>
            /// Source: Real Estate Institute of New Zealand
            /// </remarks>
            public const string ReinzHousePriceIndexMoM = "reinz house price index mom";

            /// <summary>
            /// Retail Sales QoQ - https://tradingeconomics.com/new-zealand/retail-sales
            /// </summary>
            /// <remarks>
            /// Source: Statistics New Zealand
            /// </remarks>
            public const string RetailSalesQoQ = "retail sales qoq";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/new-zealand/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Services NZ PSI - https://tradingeconomics.com/new-zealand/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Business New Zealand
            /// </remarks>
            public const string ServicesNzPerformanceOfServicesIndex = "services nz performance of services index";

            /// <summary>
            /// Terms of Trade QoQ - https://tradingeconomics.com/new-zealand/terms-of-trade
            /// </summary>
            /// <remarks>
            /// Source: Statistics New Zealand
            /// </remarks>
            public const string TermsOfTradeQoQ = "terms of trade qoq";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/new-zealand/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Visitor Arrivals MoM - https://tradingeconomics.com/new-zealand/tourist-arrivals
            /// </summary>
            /// <remarks>
            /// Source: Statistics New Zealand
            /// </remarks>
            public const string VisitorArrivalsMoM = "visitor arrivals mom";

            /// <summary>
            /// Visitor Arrivals YoY - https://tradingeconomics.com/new-zealand/tourist-arrivals
            /// </summary>
            public const string VisitorArrivalsYoY = "visitor arrivals yoy";

            /// <summary>
            /// Westpac Consumer Confidence Index - https://tradingeconomics.com/new-zealand/consumer-confidence
            /// </summary>
            public const string WestpacConsumerConfidence = "westpac consumer confidence";

            /// <summary>
            /// Westpac consumer survey - https://tradingeconomics.com/new-zealand/calendar
            /// </summary>
            public const string WestpacConsumerSurvey = "westpac consumer survey";

        }

        /// <summary>
        /// Portugal
        /// </summary>
        public static class Portugal
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/portugal/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/portugal/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/portugal/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/portugal/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Economic Activity YoY - https://tradingeconomics.com/portugal/leading-economic-index
            /// </summary>
            /// <remarks>
            /// Source: Banco de Portugal
            /// </remarks>
            public const string EconomicActivityYoY = "economic activity yoy";

            /// <summary>
            /// Exports - https://tradingeconomics.com/portugal/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/portugal/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/portugal/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/portugal/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/portugal/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/portugal/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/portugal/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/portugal/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/portugal/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/portugal/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Imports - https://tradingeconomics.com/portugal/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/portugal/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/portugal/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/portugal/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate MoM Final - https://tradingeconomics.com/portugal/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMFinal = "inflation rate mom final";

            /// <summary>
            /// Inflation Rate MoM Prel - https://tradingeconomics.com/portugal/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMPreliminary = "inflation rate mom preliminary";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/portugal/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Inflation Rate YoY Final - https://tradingeconomics.com/portugal/inflation-cpi
            /// </summary>
            public const string InflationRateYoYFinal = "inflation rate yoy final";

            /// <summary>
            /// Inflation Rate YoY Prel - https://tradingeconomics.com/portugal/inflation-cpi
            /// </summary>
            public const string InflationRateYoYPreliminary = "inflation rate yoy preliminary";

            /// <summary>
            /// Private Consumption YoY - https://tradingeconomics.com/portugal/personal-spending
            /// </summary>
            /// <remarks>
            /// Source: Banco de Portugal
            /// </remarks>
            public const string PrivateConsumptionYoY = "private consumption yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/portugal/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/portugal/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/portugal/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/portugal/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/portugal/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Slovakia
        /// </summary>
        public static class Slovakia
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/slovakia/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/slovakia/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/slovakia/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/slovakia/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Core Inflation Rate MoM - https://tradingeconomics.com/slovakia/calendar
            /// </summary>
            public const string CoreInflationRateMoM = "core inflation rate mom";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/slovakia/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/slovakia/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Exports - https://tradingeconomics.com/slovakia/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// GDP Annual Growth Rate YoY - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpAnnualGrowthRateYoY = "gdp annual growth rate yoy";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/slovakia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/slovakia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/slovakia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/slovakia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/slovakia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/slovakia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// Harmonised Inflation Rate MoM - https://tradingeconomics.com/slovakia/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoM = "harmonized inflation rate mom";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/slovakia/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Imports - https://tradingeconomics.com/slovakia/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/slovakia/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/slovakia/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/slovakia/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/slovakia/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Real Wages YoY - https://tradingeconomics.com/slovakia/wage-growth
            /// </summary>
            /// <remarks>
            /// Source: Statistical Office of the Slovak Republic
            /// </remarks>
            public const string RealWagesYoY = "real wages yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/slovakia/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/slovakia/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/slovakia/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Slovenia
        /// </summary>
        public static class Slovenia
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/slovenia/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/slovenia/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/slovenia/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/slovenia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/slovenia/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/slovenia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/slovenia/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// Harmonised Inflation Rate YoY - https://tradingeconomics.com/slovenia/calendar
            /// </summary>
            public const string HarmonizedInflationRateYoY = "harmonized inflation rate yoy";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/slovenia/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/slovenia/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/slovenia/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/slovenia/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/slovenia/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/slovenia/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Tourist Arrivals YoY - https://tradingeconomics.com/slovenia/tourist-arrivals
            /// </summary>
            public const string TouristArrivalsYoY = "tourist arrivals yoy";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/slovenia/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Spain
        /// </summary>
        public static class Spain
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/spain/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/spain/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/spain/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/spain/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// 5-Year Bonos Auction - https://tradingeconomics.com/spain/5-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Tesoro Público
            /// </remarks>
            public const string FiveYearBonosAuction = "5 year bonos auction";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/spain/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/spain/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/spain/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/spain/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/spain/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/spain/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/spain/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/spain/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// Harmonised Inflation Rate MoM Final - https://tradingeconomics.com/spain/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMFinal = "harmonized inflation rate mom final";

            /// <summary>
            /// Harmonised Inflation Rate MoM Prel - https://tradingeconomics.com/spain/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateMoMPreliminary = "harmonized inflation rate mom preliminary";

            /// <summary>
            /// Harmonised Inflation Rate YoY Final - https://tradingeconomics.com/spain/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYFinal = "harmonized inflation rate yoy final";

            /// <summary>
            /// Harmonised Inflation Rate YoY Prel - https://tradingeconomics.com/spain/harmonised-consumer-prices
            /// </summary>
            public const string HarmonizedInflationRateYoYPreliminary = "harmonized inflation rate yoy preliminary";

            /// <summary>
            /// Industrial Orders YoY - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string IndustrialOrdersYoY = "industrial orders yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/spain/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/spain/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate MoM Final - https://tradingeconomics.com/spain/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMFinal = "inflation rate mom final";

            /// <summary>
            /// Inflation Rate MoM Prel - https://tradingeconomics.com/spain/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoMPreliminary = "inflation rate mom preliminary";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/spain/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Inflation Rate YoY Final - https://tradingeconomics.com/spain/inflation-cpi
            /// </summary>
            public const string InflationRateYoYFinal = "inflation rate yoy final";

            /// <summary>
            /// Inflation Rate YoY Prel - https://tradingeconomics.com/spain/inflation-cpi
            /// </summary>
            public const string InflationRateYoYPreliminary = "inflation rate yoy preliminary";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/spain/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// New Car Sales YoY - https://tradingeconomics.com/spain/total-vehicle-sales
            /// </summary>
            public const string NewCarSalesYoY = "new car sales yoy";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/spain/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/spain/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Services PMI - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string ServicesPurchasingManagersIndex = "services purchasing managers index";

            /// <summary>
            /// 6-Month Letras Auction - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string SixMonthLetrasAuction = "6 month letras auction";

            /// <summary>
            /// 10-Year Obligacion Auction - https://tradingeconomics.com/spain/government-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Tesoro Público
            /// </remarks>
            public const string TenYearObligacionAuction = "10 year obligacion auction";

            /// <summary>
            /// 3-Month Letras Auction - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string ThreeMonthLetrasAuction = "3 month letras auction";

            /// <summary>
            /// 3-Year Bonos Auction - https://tradingeconomics.com/spain/3-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Tesoro Público
            /// </remarks>
            public const string ThreeYearBonosAuction = "3 year bonos auction";

            /// <summary>
            /// Tourist Arrivals YoY - https://tradingeconomics.com/spain/tourist-arrivals
            /// </summary>
            public const string TouristArrivalsYoY = "tourist arrivals yoy";

            /// <summary>
            /// 12-Month Letras Auction - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string TwelveMonthLetrasAuction = "12 month letras auction";

            /// <summary>
            /// Unemployment Change - https://tradingeconomics.com/spain/calendar
            /// </summary>
            public const string UnemploymentChange = "unemployment change";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/spain/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Sweden
        /// </summary>
        public static class Sweden
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/sweden/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/sweden/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Capacity Utilization QoQ - https://tradingeconomics.com/sweden/capacity-utilization
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string CapacityUtilizationQoQ = "capacity utilization qoq";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/sweden/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Consumer Inflation Expectations - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string ConsumerInflationExpectations = "consumer inflation expectations";

            /// <summary>
            /// CPIF MoM - https://tradingeconomics.com/sweden/core-consumer-prices
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string ConsumerPriceIndexFixedInterestRateMoM = "consumer price index fixed interest rate mom";

            /// <summary>
            /// CPIF YoY - https://tradingeconomics.com/sweden/core-inflation-rate
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string ConsumerPriceIndexFixedInterestRateYoY = "consumer price index fixed interest rate yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/sweden/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/sweden/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/sweden/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Flash - https://tradingeconomics.com/sweden/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFlash = "gdp growth rate qoq flash";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/sweden/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/sweden/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Flash - https://tradingeconomics.com/sweden/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFlash = "gdp growth rate yoy flash";

            /// <summary>
            /// Household Consumption MoM - https://tradingeconomics.com/sweden/personal-spending
            /// </summary>
            public const string HouseholdConsumptionMoM = "household consumption mom";

            /// <summary>
            /// Household Lending Growth YoY - https://tradingeconomics.com/sweden/loan-growth
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string HouseholdLendingGrowthYoY = "household lending growth yoy";

            /// <summary>
            /// Industrial Inventories QoQ - https://tradingeconomics.com/sweden/business-inventories
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string IndustrialInventoriesQoQ = "industrial inventories qoq";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/sweden/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/sweden/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/sweden/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Lending to Households YoY - https://tradingeconomics.com/sweden/private-sector-credit
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string LendingToHouseholdsYoY = "lending to households yoy";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// New Orders - https://tradingeconomics.com/sweden/new-orders
            /// </summary>
            /// <remarks>
            /// Source: Statistics Sweden
            /// </remarks>
            public const string NewOrders = "new orders";

            /// <summary>
            /// New Orders YoY - https://tradingeconomics.com/sweden/new-orders
            /// </summary>
            public const string NewOrdersYoY = "new orders yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/sweden/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// PMI Services - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string PurchasingManagersIndexServices = "purchasing managers index services";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/sweden/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/sweden/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Riksbank Interest Rate - https://tradingeconomics.com/sweden/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Sveriges Riksbank
            /// </remarks>
            public const string RiksbankInterestRate = "riksbank interest rate";

            /// <summary>
            /// Riksbank Rate Decision - https://tradingeconomics.com/sweden/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Sveriges Riksbank
            /// </remarks>
            public const string RiksbankRateDecision = "riksbank rate decision";

            /// <summary>
            /// Services PMI - https://tradingeconomics.com/sweden/calendar
            /// </summary>
            public const string ServicesPurchasingManagersIndex = "services purchasing managers index";

            /// <summary>
            /// Swedbank Manufacturing PMI - https://tradingeconomics.com/sweden/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Swedbank
            /// </remarks>
            public const string SwedbankManufacturingPurchasingManagersIndex = "swedbank manufacturing purchasing managers index";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/sweden/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// Switzerland
        /// </summary>
        public static class Switzerland
        {
            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/switzerland/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/switzerland/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Consumer Confidence - https://tradingeconomics.com/switzerland/consumer-confidence
            /// </summary>
            public const string ConsumerConfidence = "consumer confidence";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/switzerland/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Economic Sentiment Index - https://tradingeconomics.com/switzerland/zew-economic-sentiment-index
            /// </summary>
            /// <remarks>
            /// Source: Credit Suisse & CFA Society Switzerland
            /// </remarks>
            public const string EconomicSentimentIndex = "economic sentiment index";

            /// <summary>
            /// Employment Level (QoQ) - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string EmploymentLevelQoQ = "employment level qoq";

            /// <summary>
            /// Foreign Currency Reserves - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ForeignCurrencyReserves = "foreign currency reserves";

            /// <summary>
            /// Foreign Exchange Reserves - https://tradingeconomics.com/switzerland/foreign-exchange-reserves
            /// </summary>
            public const string ForeignExchangeReserves = "foreign exchange reserves";

            /// <summary>
            /// FX Reserves - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string FxReserves = "fx reserves";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/switzerland/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/switzerland/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// Industrial Orders YoY - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string IndustrialOrdersYoY = "industrial orders yoy";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/switzerland/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/switzerland/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/switzerland/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// KOF Leading Indicators - https://tradingeconomics.com/switzerland/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Swiss Economic Institute (KOF)
            /// </remarks>
            public const string KofLeadingIndicators = "kof leading indicators";

            /// <summary>
            /// Non Farm Payrolls - https://tradingeconomics.com/switzerland/non-farm-payrolls
            /// </summary>
            public const string NonFarmPayrolls = "non farm payrolls";

            /// <summary>
            /// procure.ch Manufacturing PMI - https://tradingeconomics.com/switzerland/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: procure.ch & Credit Suisse
            /// </remarks>
            public const string ProcurechManufacturingPurchasingManagersIndex = "procurech manufacturing purchasing managers index";

            /// <summary>
            /// Producer & Import Prices MoM - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ProducerAndImportPricesMoM = "producer and import prices mom";

            /// <summary>
            /// Producer & Import Prices YoY - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ProducerAndImportPricesYoY = "producer and import prices yoy";

            /// <summary>
            /// Producer/Import Prices MoM - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ProducerImportPricesMoM = "producer import prices mom";

            /// <summary>
            /// Producer/Import Prices YoY - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ProducerImportPricesYoY = "producer import prices yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/switzerland/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/switzerland/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/switzerland/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// SNB Interest Rate Decison - https://tradingeconomics.com/switzerland/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Swiss National Bank
            /// </remarks>
            public const string SnbInterestRateDecison = "snb interest rate decison";

            /// <summary>
            /// SVME Manufacturing PMI - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string SvmeManufacturingPurchasingManagersIndex = "svme manufacturing purchasing managers index";

            /// <summary>
            /// UBS Consumption Indicator - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string UbsConsumptionIndicators = "ubs consumption indicators";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/switzerland/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// USD Consumption Indicator - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string UsdConsumptionIndicators = "usd consumption indicators";

            /// <summary>
            /// ZEW Economic Sentiment Index - https://tradingeconomics.com/switzerland/zew-economic-sentiment-index
            /// </summary>
            public const string ZewEconomicSentimentIndex = "zew economic sentiment index";

            /// <summary>
            /// ZEW Expectations - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ZewExpectations = "zew expectations";

            /// <summary>
            /// ZEW investor sentiment - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ZewInvestorSentiment = "zew investor sentiment";

            /// <summary>
            /// ZEW Survey - Expectations - https://tradingeconomics.com/switzerland/calendar
            /// </summary>
            public const string ZewSurveyExpectations = "zew survey expectations";

        }

        /// <summary>
        /// United Kingdom
        /// </summary>
        public static class UnitedKingdom
        {
            /// <summary>
            /// Average Earnings excl. Bonus - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string AverageEarningsExcludingBonus = "average earnings excluding bonus";

            /// <summary>
            /// Average Earnings incl. Bonus - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string AverageEarningsIncludingBonus = "average earnings including bonus";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/united-kingdom/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// BoE Asset Purchase Facility - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BankOfEnglandAssetPurchaseFacility = "bank of england asset purchase facility";

            /// <summary>
            /// BoE Consumer Credit - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BankOfEnglandConsumerCredit = "bank of england consumer credit";

            /// <summary>
            /// BoE Interest Rate Decision - https://tradingeconomics.com/united-kingdom/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of England
            /// </remarks>
            public const string BankOfEnglandInterestRateDecision = "bank of england interest rate decision";

            /// <summary>
            /// BoE MPC Vote Cut - https://tradingeconomics.com/united-kingdom/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of England
            /// </remarks>
            public const string BankOfEnglandMpcVoteCut = "bank of england mpc vote cut";

            /// <summary>
            /// BoE MPC Vote Hike - https://tradingeconomics.com/united-kingdom/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of England
            /// </remarks>
            public const string BankOfEnglandMpcVoteHike = "bank of england mpc vote hike";

            /// <summary>
            /// BoE MPC Vote Unchanged - https://tradingeconomics.com/united-kingdom/interest-rate
            /// </summary>
            /// <remarks>
            /// Source: Bank of England
            /// </remarks>
            public const string BankOfEnglandMpcVoteUnchanged = "bank of england mpc vote unchanged";

            /// <summary>
            /// BoE Quantitative Easing - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BankOfEnglandQuantitativeEasing = "bank of england quantitative easing";

            /// <summary>
            /// BBA Mortgage Approvals - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BbaMortgageApprovals = "bba mortgage approvals";

            /// <summary>
            /// BRC Retail Sales Monitor YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BrcRetailSalesYoY = "brc retail sales yoy";

            /// <summary>
            /// BRC Shop Price Index MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BrcShopPriceIndexMoM = "brc shop price index mom";

            /// <summary>
            /// BRC Shop Price Index YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BrcShopPriceIndexYoY = "brc shop price index yoy";

            /// <summary>
            /// Business Confidence - https://tradingeconomics.com/united-kingdom/business-confidence
            /// </summary>
            public const string BusinessConfidence = "business confidence";

            /// <summary>
            /// Business Investment QoQ - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentQoQ = "business investment qoq";

            /// <summary>
            /// Business Investment QoQ Final - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentQoQFinal = "business investment qoq final";

            /// <summary>
            /// Business Investment QoQ Prel - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentQoQPreliminary = "business investment qoq preliminary";

            /// <summary>
            /// Business Investment YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentYoY = "business investment yoy";

            /// <summary>
            /// Business Investment YoY Final - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentYoYFinal = "business investment yoy final";

            /// <summary>
            /// Business Investment YoY Prel - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string BusinessInvestmentYoYPreliminary = "business investment yoy preliminary";

            /// <summary>
            /// CB Leading Economic Index - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CbLeadingEconomicIndex = "cb leading economic index";

            /// <summary>
            /// CB Leading Index MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CbLeadingEconomicIndexMoM = "cb leading economic index mom";

            /// <summary>
            /// CBI Business Optimism Index - https://tradingeconomics.com/united-kingdom/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Confederation of British Industry
            /// </remarks>
            public const string CbiBusinessOptimismIndex = "cbi business optimism index";

            /// <summary>
            /// CBI Distributive Trades - https://tradingeconomics.com/united-kingdom/cbi-distributive-trades
            /// </summary>
            public const string CbiDistributiveTrades = "cbi distributive trades";

            /// <summary>
            /// CBI Industrial Trends Orders - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CbiIndustrialTrendsOrders = "cbi industrial trends orders";

            /// <summary>
            /// Claimant Count Change - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ClaimantCountChange = "claimant count change";

            /// <summary>
            /// Claimant Count Rate - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ClaimantCountRate = "claimant count rate";

            /// <summary>
            /// Construction Orders YoY - https://tradingeconomics.com/united-kingdom/construction-orders
            /// </summary>
            public const string ConstructionOrdersYoY = "construction orders yoy";

            /// <summary>
            /// Construction Output YoY - https://tradingeconomics.com/united-kingdom/construction-output
            /// </summary>
            public const string ConstructionOutputYoY = "construction output yoy";

            /// <summary>
            /// Construction PMI - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ConstructionPurchasingManagersIndex = "construction purchasing managers index";

            /// <summary>
            /// Consumer Inflation Expectations - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ConsumerInflationExpectations = "consumer inflation expectations";

            /// <summary>
            /// Core Inflation Rate MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CoreInflationRateMoM = "core inflation rate mom";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Core RPI MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CoreRetailPriceIndexMoM = "core retail price index mom";

            /// <summary>
            /// Core RPI YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CoreRetailPriceIndexYoY = "core retail price index yoy";

            /// <summary>
            /// Core Retail Sales YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string CoreRetailSalesYoY = "core retail sales yoy";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/united-kingdom/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Employment Change - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string EmploymentChange = "employment change";

            /// <summary>
            /// 5-Year Treasury Gilt Auction - https://tradingeconomics.com/united-kingdom/5-year-note-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury, UK
            /// </remarks>
            public const string FiveYearTreasuryGiltAuction = "5 year treasury gilt auction";

            /// <summary>
            /// GDP Growth Rate QoQ - https://tradingeconomics.com/united-kingdom/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQ = "gdp growth rate qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/united-kingdom/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ Prel - https://tradingeconomics.com/united-kingdom/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQPreliminary = "gdp growth rate qoq preliminary";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/united-kingdom/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate YoY - https://tradingeconomics.com/united-kingdom/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoY = "gdp growth rate yoy";

            /// <summary>
            /// GDP Growth Rate YoY Final - https://tradingeconomics.com/united-kingdom/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYFinal = "gdp growth rate yoy final";

            /// <summary>
            /// GDP Growth Rate YoY Prel - https://tradingeconomics.com/united-kingdom/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYPreliminary = "gdp growth rate yoy preliminary";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/united-kingdom/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// GDP MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string GdpMoM = "gdp mom";

            /// <summary>
            /// GDP 3-Month Avg - https://tradingeconomics.com/united-kingdom/leading-economic-index
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string GdpThreeMonthAverage = "gdp 3 month average";

            /// <summary>
            /// GDP YoY - https://tradingeconomics.com/united-kingdom/leading-economic-index
            /// </summary>
            public const string GdpYoY = "gdp yoy";

            /// <summary>
            /// Gfk Consumer Confidence - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string GfkConsumerConfidence = "gfk consumer confidence";

            /// <summary>
            /// Goods Trade Balance - https://tradingeconomics.com/united-kingdom/goods-trade-balance
            /// </summary>
            public const string GoodsTradeBalance = "goods trade balance";

            /// <summary>
            /// Halifax House Price Index MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HalifaxHousePriceIndexMoM = "halifax house price index mom";

            /// <summary>
            /// Halifax House Price Index YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HalifaxHousePriceIndexYoY = "halifax house price index yoy";

            /// <summary>
            /// Hometrack Housing Prices MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HometrackHousingPricesMoM = "hometrack housing prices mom";

            /// <summary>
            /// Hometrack Housing Prices s.a - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HometrackHousingPricesSeasonallyAdjusted = "hometrack housing prices seasonally adjusted";

            /// <summary>
            /// House Price Index MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HousePriceIndexMoM = "house price index mom";

            /// <summary>
            /// House Price Index YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string HousePriceIndexYoY = "house price index yoy";

            /// <summary>
            /// Index of Services (3M/3M) - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string IndexOfServices3M3M = "index of services 3m 3m";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/united-kingdom/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/united-kingdom/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/united-kingdom/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Interest Rate Decision - https://tradingeconomics.com/united-kingdom/interest-rate
            /// </summary>
            public const string InterestRateDecision = "interest rate decision";

            /// <summary>
            /// Labour Costs Index QoQ - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string LaborCostsIndexQoQ = "labor costs index qoq";

            /// <summary>
            /// Labor Productivity QoQ - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string LaborProductivityQoQ = "labor productivity qoq";

            /// <summary>
            /// Labour Productivity QoQ Final - https://tradingeconomics.com/united-kingdom/productivity
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string LaborProductivityQoQFinal = "labor productivity qoq final";

            /// <summary>
            /// Labour Productivity QoQ Prel - https://tradingeconomics.com/united-kingdom/productivity
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string LaborProductivityQoQPreliminary = "labor productivity qoq preliminary";

            /// <summary>
            /// M4 Money Supply MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string M4MoneySupplyMoM = "m4 money supply mom";

            /// <summary>
            /// M4 Money Supply YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string M4MoneySupplyYoY = "m4 money supply yoy";

            /// <summary>
            /// Manufacturing Production MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ManufacturingProductionMoM = "manufacturing production mom";

            /// <summary>
            /// Manufacturing Production YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ManufacturingProductionYoY = "manufacturing production yoy";

            /// <summary>
            /// Markit/CIPS Composite PMI Final - https://tradingeconomics.com/united-kingdom/composite-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsCompositePurchasingManagersIndexFinal = "markit cips composite purchasing managers index final";

            /// <summary>
            /// Markit/CIPS Composite PMI Flash - https://tradingeconomics.com/united-kingdom/composite-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsCompositePurchasingManagersIndexFlash = "markit cips composite purchasing managers index flash";

            /// <summary>
            /// Markit/CIPS Manufacturing PMI - https://tradingeconomics.com/united-kingdom/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsManufacturingPurchasingManagersIndex = "markit cips manufacturing purchasing managers index";

            /// <summary>
            /// Markit/CIPS Manufacturing PMI Final - https://tradingeconomics.com/united-kingdom/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsManufacturingPurchasingManagersIndexFinal = "markit cips manufacturing purchasing managers index final";

            /// <summary>
            /// Markit/CIPS Manufacturing PMI Flash - https://tradingeconomics.com/united-kingdom/manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsManufacturingPurchasingManagersIndexFlash = "markit cips manufacturing purchasing managers index flash";

            /// <summary>
            /// Markit/CIPS UK Services PMI - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string MarkitCipsUkServicesPurchasingManagersIndex = "markit cips uk services purchasing managers index";

            /// <summary>
            /// Markit/CIPS UK Services PMI Final - https://tradingeconomics.com/united-kingdom/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsUkServicesPurchasingManagersIndexFinal = "markit cips uk services purchasing managers index final";

            /// <summary>
            /// Markit/CIPS UK Services PMI Flash - https://tradingeconomics.com/united-kingdom/services-pmi
            /// </summary>
            /// <remarks>
            /// Source: Markit Economics
            /// </remarks>
            public const string MarkitCipsUkServicesPurchasingManagersIndexFlash = "markit cips uk services purchasing managers index flash";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/united-kingdom/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Markit Services PMI - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndex = "markit services purchasing managers index";

            /// <summary>
            /// Monthly GDP - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string MonthlyGdp = "monthly gdp";

            /// <summary>
            /// Monthly GDP 3-Month Avg - https://tradingeconomics.com/united-kingdom/leading-economic-index
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string MonthlyGdpThreeMonthAverage = "monthly gdp 3 month average";

            /// <summary>
            /// Mortgage Approvals - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string MortgageApprovals = "mortgage approvals";

            /// <summary>
            /// Mortgage Lending - https://tradingeconomics.com/united-kingdom/home-loans
            /// </summary>
            public const string MortgageLending = "mortgage lending";

            /// <summary>
            /// Nationwide Housing Prices MoM - https://tradingeconomics.com/united-kingdom/nationwide-housing-prices
            /// </summary>
            public const string NationwideHousingPricesMoM = "nationwide housing prices mom";

            /// <summary>
            /// Nationwide Housing Prices YoY - https://tradingeconomics.com/united-kingdom/nationwide-housing-prices
            /// </summary>
            public const string NationwideHousingPricesYoY = "nationwide housing prices yoy";

            /// <summary>
            /// Net Lending to Individuals MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string NetLendingToIndividualsMoM = "net lending to individuals mom";

            /// <summary>
            /// New Car Sales YoY - https://tradingeconomics.com/united-kingdom/total-vehicle-sales
            /// </summary>
            public const string NewCarSalesYoY = "new car sales yoy";

            /// <summary>
            /// NIESR GDP Est (3M) - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string NiesrGdpEstimateThreeMonths = "niesr gdp estimate 3m";

            /// <summary>
            /// NIESR Monthly GDP Tracker - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string NiesrMonthlyGdpTracker = "niesr monthly gdp tracker";

            /// <summary>
            /// Parliamentary Vote on Brexit Deal - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ParliamentaryVoteOnBrexitDeal = "parliamentary vote on brexit deal";

            /// <summary>
            /// PPI Core Output MoM - https://tradingeconomics.com/united-kingdom/core-producer-prices
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string ProducerPriceIndexCoreOutputMoM = "producer price index core output mom";

            /// <summary>
            /// PPI Core Output YoY - https://tradingeconomics.com/united-kingdom/core-producer-prices
            /// </summary>
            /// <remarks>
            /// Source: Office for National Statistics
            /// </remarks>
            public const string ProducerPriceIndexCoreOutputYoY = "producer price index core output yoy";

            /// <summary>
            /// PPI Input MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ProducerPriceIndexInputMoM = "producer price index input mom";

            /// <summary>
            /// PPI Input YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ProducerPriceIndexInputYoY = "producer price index input yoy";

            /// <summary>
            /// PPI Output MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ProducerPriceIndexOutputMoM = "producer price index output mom";

            /// <summary>
            /// PPI Output YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string ProducerPriceIndexOutputYoY = "producer price index output yoy";

            /// <summary>
            /// Public Sector Borrowing MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string PublicSectorBorrowingMoM = "public sector borrowing mom";

            /// <summary>
            /// Public Sector Net Borrowing - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string PublicSectorNetBorrowing = "public sector net borrowing";

            /// <summary>
            /// Retail Price Index MoM - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string RetailPriceIndexMoM = "retail price index mom";

            /// <summary>
            /// Retail Price Index YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string RetailPriceIndexYoY = "retail price index yoy";

            /// <summary>
            /// Retail Sales ex Fuel MoM - https://tradingeconomics.com/united-kingdom/retail-sales-ex-fuel
            /// </summary>
            public const string RetailSalesExcludingFuelMoM = "retail sales excluding fuel mom";

            /// <summary>
            /// Retail Sales ex Fuel YoY - https://tradingeconomics.com/united-kingdom/retail-sales-ex-fuel
            /// </summary>
            public const string RetailSalesExcludingFuelYoY = "retail sales excluding fuel yoy";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/united-kingdom/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/united-kingdom/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// RICS House Price Balance - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string RicsHousePriceBalance = "rics house price balance";

            /// <summary>
            /// 10-Year Treasury Gilt Auction - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string TenYearTreasuryGiltAuction = "10 year treasury gilt auction";

            /// <summary>
            /// 30-Year Treasury Gilt Auction - https://tradingeconomics.com/united-kingdom/30-year-bond-yield
            /// </summary>
            /// <remarks>
            /// Source: Department of Treasury, UK
            /// </remarks>
            public const string ThirtyYearTreasuryGiltAuction = "30 year treasury gilt auction";

            /// <summary>
            /// Total Business Investment QoQ - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string TotalBusinessInvestmentQoQ = "total business investment qoq";

            /// <summary>
            /// Total Business Investment YoY - https://tradingeconomics.com/united-kingdom/calendar
            /// </summary>
            public const string TotalBusinessInvestmentYoY = "total business investment yoy";

            /// <summary>
            /// UK Finance Mortgage Approvals - https://tradingeconomics.com/united-kingdom/mortgage-applications
            /// </summary>
            /// <remarks>
            /// Source: UK Finance
            /// </remarks>
            public const string UkFinanceMortgageApprovals = "uk finance mortgage approvals";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/united-kingdom/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

        }

        /// <summary>
        /// United States
        /// </summary>
        public static class UnitedStates
        {
            /// <summary>
            /// ADP Employment Change - https://tradingeconomics.com/united-states/adp-employment-change
            /// </summary>
            public const string AdpEmploymentChange = "adp employment change";

            /// <summary>
            /// All Car Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string AllCarSales = "all car sales";

            /// <summary>
            /// All Truck Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string AllTruckSales = "all truck sales";

            /// <summary>
            /// API Crude Oil Stock Change - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ApiWeeklyCrudeStockChange = "api weekly crude stock change";

            /// <summary>
            /// API Weekly Gasoline Stock Change - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ApiWeeklyGasolineStockChange = "api weekly gasoline stock change";

            /// <summary>
            /// Average Hourly Earnings MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string AverageHourlyEarningsMoM = "average hourly earnings mom";

            /// <summary>
            /// Average Hourly Earnings YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string AverageHourlyEarningsYoY = "average hourly earnings yoy";

            /// <summary>
            /// Average Weekly Hours - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string AverageWeeklyHours = "average weekly hours";

            /// <summary>
            /// Baker Hughes Oil Rig Count - https://tradingeconomics.com/united-states/crude-oil-rigs
            /// </summary>
            /// <remarks>
            /// Source: Baker Hughes
            /// </remarks>
            public const string BakerHughesOilRigCount = "baker hughes oil rig count";

            /// <summary>
            /// Balance of Trade - https://tradingeconomics.com/united-states/balance-of-trade
            /// </summary>
            public const string BalanceOfTrade = "balance of trade";

            /// <summary>
            /// Building Permits - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string BuildingPermits = "building permits";

            /// <summary>
            /// Building Permits MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string BuildingPermitsMoM = "building permits mom";

            /// <summary>
            /// Business Inventories MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string BusinessInventoriesMoM = "business inventories mom";

            /// <summary>
            /// Capacity Utilization - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CapacityUtilization = "capacity utilization";

            /// <summary>
            /// CB Consumer Confidence - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CbConsumerConfidence = "cb consumer confidence";

            /// <summary>
            /// CB Employment Trends Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CbEmploymentTrendsIndex = "cb employment trends index";

            /// <summary>
            /// CB Leading Index MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CbLeadingEconomicIndexMoM = "cb leading economic index mom";

            /// <summary>
            /// Chain Stores Sales WoW - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ChainStoresSalesWoW = "chain stores sales wow";

            /// <summary>
            /// Chain Stores Sales YoY - https://tradingeconomics.com/united-states/chain-store-sales
            /// </summary>
            public const string ChainStoresSalesYoY = "chain stores sales yoy";

            /// <summary>
            /// Challenger Job Cuts - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ChallengerJobCuts = "challenger job cuts";

            /// <summary>
            /// Chicago Fed National Activity Index - https://tradingeconomics.com/united-states/chicago-fed-national-activity-index
            /// </summary>
            public const string ChicagoFedNationalActivityIndex = "chicago fed national activity index";

            /// <summary>
            /// Chicago PMI - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ChicagoPurchasingManagersIndex = "chicago purchasing managers index";

            /// <summary>
            /// Construction Spending MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConstructionSpendingMoM = "construction spending mom";

            /// <summary>
            /// Consumer Credit Change - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConsumerCreditChange = "consumer credit change";

            /// <summary>
            /// Consumer Inflation Expectations - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConsumerInflationExpectations = "consumer inflation expectations";

            /// <summary>
            /// Consumer Price Index - https://tradingeconomics.com/united-states/consumer-price-index-cpi
            /// </summary>
            public const string ConsumerPriceIndex = "consumer price index";

            /// <summary>
            /// Consumer Price Index Ex Food & Energy (MoM) - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConsumerPriceIndexExcludingFoodAndEnergyMoM = "consumer price index excluding food and energy mom";

            /// <summary>
            /// Consumer Price Index Ex Food & Energy (YoY) - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConsumerPriceIndexExcludingFoodAndEnergyYoY = "consumer price index excluding food and energy yoy";

            /// <summary>
            /// CPI Real Earnings MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ConsumerPriceIndexRealEarningsMoM = "consumer price index real earnings mom";

            /// <summary>
            /// Continuing Jobless Claims - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ContinuingJoblessClaims = "continuing jobless claims";

            /// <summary>
            /// Core Consumer Price Index - https://tradingeconomics.com/united-states/core-consumer-prices
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Labor Statistics
            /// </remarks>
            public const string CoreConsumerPriceIndex = "core consumer price index";

            /// <summary>
            /// Core Durable Goods Orders - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CoreDurableGoodsOrders = "core durable goods orders";

            /// <summary>
            /// Core Durable Goods Orders MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CoreDurableGoodsOrdersMoM = "core durable goods orders mom";

            /// <summary>
            /// Core Inflation Rate MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CoreInflationRateMoM = "core inflation rate mom";

            /// <summary>
            /// Core Inflation Rate YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CoreInflationRateYoY = "core inflation rate yoy";

            /// <summary>
            /// Core PCE Price Index MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexMoM = "core personal consumption expenditure price index mom";

            /// <summary>
            /// Core PCE Prices QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexQoQ = "core personal consumption expenditure price index qoq";

            /// <summary>
            /// Core PCE Prices QoQ Adv - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexQoQAdvance = "core personal consumption expenditure price index qoq advance";

            /// <summary>
            /// Core PCE Prices QoQ Final - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexQoQFinal = "core personal consumption expenditure price index qoq final";

            /// <summary>
            /// Core PCE Prices QoQ 2 Est - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexQoQSecondEstimate = "core personal consumption expenditure price index qoq second estimate";

            /// <summary>
            /// Core PCE Price Index YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CorePersonalConsumptionExpenditurePriceIndexYoY = "core personal consumption expenditure price index yoy";

            /// <summary>
            /// Core PPI MoM - https://tradingeconomics.com/united-states/core-producer-prices
            /// </summary>
            public const string CoreProducerPriceIndexMoM = "core producer price index mom";

            /// <summary>
            /// Core PPI YoY - https://tradingeconomics.com/united-states/core-producer-prices
            /// </summary>
            public const string CoreProducerPriceIndexYoY = "core producer price index yoy";

            /// <summary>
            /// Core Retail Sales MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string CoreRetailSalesMoM = "core retail sales mom";

            /// <summary>
            /// Corporate Profits QoQ - https://tradingeconomics.com/united-states/corporate-profits
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economics Analysis
            /// </remarks>
            public const string CorporateProfitsQoQ = "corporate profits qoq";

            /// <summary>
            /// Corporate Profits QoQ Final - https://tradingeconomics.com/united-states/corporate-profits
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economics Analysis
            /// </remarks>
            public const string CorporateProfitsQoQFinal = "corporate profits qoq final";

            /// <summary>
            /// Corporate Profits QoQ Prel - https://tradingeconomics.com/united-states/corporate-profits
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economics Analysis
            /// </remarks>
            public const string CorporateProfitsQoQPreliminary = "corporate profits qoq preliminary";

            /// <summary>
            /// Current Account - https://tradingeconomics.com/united-states/current-account
            /// </summary>
            public const string CurrentAccount = "current account";

            /// <summary>
            /// Dallas Fed Manufacturing Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string DallasFedManufacturingIndex = "dallas fed manufacturing index";

            /// <summary>
            /// Domestic Car Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string DomesticCarSales = "domestic car sales";

            /// <summary>
            /// Domestic Truck Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string DomesticTruckSales = "domestic truck sales";

            /// <summary>
            /// Durable Goods Orders ex Defense MoM - https://tradingeconomics.com/united-states/durable-goods-orders-ex-defense
            /// </summary>
            /// <remarks>
            /// Source: U.S. Census Bureau
            /// </remarks>
            public const string DurableGoodsOrdersExcludingDefenseMoM = "durable goods orders excluding defense mom";

            /// <summary>
            /// Durable Goods Orders Ex Transp MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string DurableGoodsOrdersExcludingTransportationMoM = "durable goods orders excluding transportation mom";

            /// <summary>
            /// Durable Goods Orders MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string DurableGoodsOrdersMoM = "durable goods orders mom";

            /// <summary>
            /// EIA Crude Oil Imports - https://tradingeconomics.com/united-states/crude-oil-imports
            /// </summary>
            /// <remarks>
            /// Source: U.S. Energy Information Administration
            /// </remarks>
            public const string EiaCrudeOilImports = "eia crude oil imports";

            /// <summary>
            /// EIA Crude Oil Stocks Change - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EiaCrudeOilStocksChange = "eia crude oil stocks change";

            /// <summary>
            /// EIA Distillate Stocks - https://tradingeconomics.com/united-states/distillate-stocks
            /// </summary>
            /// <remarks>
            /// Source: U.S. Energy Information Administration
            /// </remarks>
            public const string EiaDistillateStocks = "eia distillate stocks";

            /// <summary>
            /// EIA Gasoline Production - https://tradingeconomics.com/united-states/gasoline-production
            /// </summary>
            /// <remarks>
            /// Source: U.S. Energy Information Administration
            /// </remarks>
            public const string EiaGasolineProduction = "eia gasoline production";

            /// <summary>
            /// EIA Gasoline Stocks Change - https://tradingeconomics.com/united-states/gasoline-stocks-change
            /// </summary>
            public const string EiaGasolineStocksChange = "eia gasoline stocks change";

            /// <summary>
            /// EIA Natural Gas Stocks Change - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EiaNaturalGasStocksChange = "eia natural gas stocks change";

            /// <summary>
            /// 8-Week Bill Auction - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EightWeekBillAuction = "8 week bill auction";

            /// <summary>
            /// Employment Benefits QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EmploymentBenefitsQoQ = "employment benefits qoq";

            /// <summary>
            /// Employment Cost - Benefits QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EmploymentCostsBenefitsQoQ = "employment costs benefits qoq";

            /// <summary>
            /// Employment Cost Index QoQ - https://tradingeconomics.com/united-states/employment-cost-index
            /// </summary>
            public const string EmploymentCostsIndexQoQ = "employment costs index qoq";

            /// <summary>
            /// Employment Cost - Wages QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EmploymentCostsWagesQoQ = "employment costs wages qoq";

            /// <summary>
            /// Employment Wages QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string EmploymentWagesQoQ = "employment wages qoq";

            /// <summary>
            /// Existing Home Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ExistingHomeSales = "existing home sales";

            /// <summary>
            /// Existing Home Sales MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ExistingHomeSalesMoM = "existing home sales mom";

            /// <summary>
            /// Export Prices MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ExportPricesMoM = "export prices mom";

            /// <summary>
            /// Export Prices YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ExportPricesYoY = "export prices yoy";

            /// <summary>
            /// Exports - https://tradingeconomics.com/united-states/exports
            /// </summary>
            public const string Exports = "exports";

            /// <summary>
            /// Factory Orders ex Transportation - https://tradingeconomics.com/united-states/factory-orders
            /// </summary>
            public const string FactoryOrdersExcludingTransportation = "factory orders excluding transportation";

            /// <summary>
            /// Factory Orders MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FactoryOrdersMoM = "factory orders mom";

            /// <summary>
            /// Fed Interest Rate Decision - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FedInterestRateDecision = "fed interest rate decision";

            /// <summary>
            /// Fed Labor Market Conditions Index (MoM) - https://tradingeconomics.com/united-states/labor-market-conditions-index
            /// </summary>
            public const string FedLaborMarketConditionsIndexMoM = "fed labor market conditions index mom";

            /// <summary>
            /// Fed Pace of MBS Purchase Program - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FedPaceOfMortgageBackedSecuritiesPurchaseProgram = "fed pace of mortgage backed securities purchase program";

            /// <summary>
            /// Fed Pace of Treasury Purchase Program - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FedPaceOfTreasuryPurchaseProgram = "fed pace of treasury purchase program";

            /// <summary>
            /// Federal Budget Balance - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FederalBudgetBalance = "federal budget balance";

            /// <summary>
            /// 52-Week Bill Auction - https://tradingeconomics.com/united-states/52-week-bill-yield
            /// </summary>
            public const string FiftyTwoWeekBillAuction = "52 week bill auction";

            /// <summary>
            /// 5-Year Note Auction - https://tradingeconomics.com/united-states/5-year-note-yield
            /// </summary>
            public const string FiveYearNoteAuction = "5 year note auction";

            /// <summary>
            /// 5-Year TIPS Auction - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string FiveYearTipsAuction = "5 year tips auction";

            /// <summary>
            /// Foreign Bond Investment - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ForeignBondInvestment = "foreign bond investment";

            /// <summary>
            /// 4-Week Bill Auction - https://tradingeconomics.com/united-states/4-week-bill-yield
            /// </summary>
            public const string FourWeekBillAuction = "4 week bill auction";

            /// <summary>
            /// Gasoline Inventories - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string GasolineInventories = "gasoline inventories";

            /// <summary>
            /// GDP Consumer Spending QoQ Adv - https://tradingeconomics.com/united-states/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpConsumerSpendingQoQAdvance = "gdp consumer spending qoq advance";

            /// <summary>
            /// GDP Consumer Spending QoQ Final - https://tradingeconomics.com/united-states/consumer-spending
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpConsumerSpendingQoQFinal = "gdp consumer spending qoq final";

            /// <summary>
            /// GDP Consumer Spending YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string GdpConsumerSpendingYoY = "gdp consumer spending yoy";

            /// <summary>
            /// GDP Deflator QoQ - https://tradingeconomics.com/united-states/gdp-deflator
            /// </summary>
            public const string GdpDeflatorQoQ = "gdp deflator qoq";

            /// <summary>
            /// GDP Growth Rate QoQ Adv - https://tradingeconomics.com/united-states/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQAdvance = "gdp growth rate qoq advance";

            /// <summary>
            /// GDP Growth Rate QoQ Final - https://tradingeconomics.com/united-states/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQFinal = "gdp growth rate qoq final";

            /// <summary>
            /// GDP Growth Rate QoQ 2nd Est - https://tradingeconomics.com/united-states/gdp-growth
            /// </summary>
            public const string GdpGrowthRateQoQSecondEstimate = "gdp growth rate qoq second estimate";

            /// <summary>
            /// GDP Growth Rate 2nd Est - https://tradingeconomics.com/united-states/gdp-growth
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpGrowthRateSecondEstimate = "gdp growth rate second estimate";

            /// <summary>
            /// GDP Growth Rate YoY Adv - https://tradingeconomics.com/united-states/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYAdvance = "gdp growth rate yoy advance";

            /// <summary>
            /// GDP Growth Rate YoY 2nd Est - https://tradingeconomics.com/united-states/gdp-growth-annual
            /// </summary>
            public const string GdpGrowthRateYoYSecondEstimate = "gdp growth rate yoy second estimate";

            /// <summary>
            /// GDP Growth Rate YoY Third Estimate - https://tradingeconomics.com/united-states/gdp-growth-annual
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpGrowthRateYoYThirdEstimate = "gdp growth rate yoy third estimate";

            /// <summary>
            /// GDP Price Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string GdpPriceIndex = "gdp price index";

            /// <summary>
            /// GDP Price Index QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string GdpPriceIndexQoQ = "gdp price index qoq";

            /// <summary>
            /// GDP Price Index QoQ Adv - https://tradingeconomics.com/united-states/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpPriceIndexQoQAdvance = "gdp price index qoq advance";

            /// <summary>
            /// GDP Price Index QoQ Final - https://tradingeconomics.com/united-states/gdp-deflator
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Economic Analysis
            /// </remarks>
            public const string GdpPriceIndexQoQFinal = "gdp price index qoq final";

            /// <summary>
            /// GDP Price Index QoQ 2nd Est - https://tradingeconomics.com/united-states/gdp-deflator
            /// </summary>
            public const string GdpPriceIndexQoQSecondEstimate = "gdp price index qoq second estimate";

            /// <summary>
            /// Goods Trade Balance - https://tradingeconomics.com/united-states/goods-trade-balance
            /// </summary>
            public const string GoodsTradeBalance = "goods trade balance";

            /// <summary>
            /// Goods Trade Balance Adv - https://tradingeconomics.com/united-states/goods-trade-balance
            /// </summary>
            public const string GoodsTradeBalanceAdvance = "goods trade balance advance";

            /// <summary>
            /// Government Payrolls - https://tradingeconomics.com/united-states/government-payrolls
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Labor Statistics
            /// </remarks>
            public const string GovernmentPayrolls = "government payrolls";

            /// <summary>
            /// Gross Domestic Product Price Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string GrossDomesticProductPriceIndex = "gross domestic product price index";

            /// <summary>
            /// House Price Index MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string HousePriceIndexMoM = "house price index mom";

            /// <summary>
            /// House Price Index YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string HousePriceIndexYoY = "house price index yoy";

            /// <summary>
            /// Housing Starts - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string HousingStarts = "housing starts";

            /// <summary>
            /// Housing Starts MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string HousingStartsMoM = "housing starts mom";

            /// <summary>
            /// HSBC Services PMI - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string HsbcServicesPurchasingManagersIndex = "hsbc services purchasing managers index";

            /// <summary>
            /// IBD/TIPP Economic Optimism - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IbdTippEconomicOptimism = "ibd tipp economic optimism";

            /// <summary>
            /// Import Prices MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ImportPricesMoM = "import prices mom";

            /// <summary>
            /// Import Prices YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ImportPricesYoY = "import prices yoy";

            /// <summary>
            /// Imports - https://tradingeconomics.com/united-states/imports
            /// </summary>
            public const string Imports = "imports";

            /// <summary>
            /// Industrial Production MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IndustrialProductionMoM = "industrial production mom";

            /// <summary>
            /// Industrial Production YoY - https://tradingeconomics.com/united-states/industrial-production
            /// </summary>
            public const string IndustrialProductionYoY = "industrial production yoy";

            /// <summary>
            /// Inflation Rate MoM - https://tradingeconomics.com/united-states/inflation-rate-mom
            /// </summary>
            public const string InflationRateMoM = "inflation rate mom";

            /// <summary>
            /// Inflation Rate YoY - https://tradingeconomics.com/united-states/inflation-cpi
            /// </summary>
            public const string InflationRateYoY = "inflation rate yoy";

            /// <summary>
            /// Initial Jobless Claims - https://tradingeconomics.com/united-states/jobless-claims
            /// </summary>
            /// <remarks>
            /// Source: U.S. Department of Labor
            /// </remarks>
            public const string InitialJoblessClaims = "initial jobless claims";

            /// <summary>
            /// ISM Manufacturing Employment - https://tradingeconomics.com/united-states/business-confidence
            /// </summary>
            public const string IsmManufacturingEmployment = "ism manufacturing employment";

            /// <summary>
            /// ISM Manufacturing New Orders - https://tradingeconomics.com/united-states/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Institute for Supply Management
            /// </remarks>
            public const string IsmManufacturingNewOrders = "ism manufacturing new orders";

            /// <summary>
            /// ISM Manufacturing Prices - https://tradingeconomics.com/united-states/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Institute for Supply Management
            /// </remarks>
            public const string IsmManufacturingPrices = "ism manufacturing prices";

            /// <summary>
            /// ISM Manufacturing Prices Paid - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IsmManufacturingPricesPaid = "ism manufacturing prices paid";

            /// <summary>
            /// ISM Manufacturing PMI - https://tradingeconomics.com/united-states/business-confidence
            /// </summary>
            /// <remarks>
            /// Source: Institute for Supply Management
            /// </remarks>
            public const string IsmManufacturingPurchasingManagersIndex = "ism manufacturing purchasing managers index";

            /// <summary>
            /// ISM New York Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IsmNewYorkIndex = "ism new york index";

            /// <summary>
            /// ISM Non-Manufacturing Business Activity - https://tradingeconomics.com/united-states/non-manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Institute for Supply Management
            /// </remarks>
            public const string IsmNonManufacturingBusinessActivity = "ism non manufacturing business activity";

            /// <summary>
            /// ISM Non-Manufacturing Employment - https://tradingeconomics.com/united-states/non-manufacturing-pmi
            /// </summary>
            public const string IsmNonManufacturingEmployment = "ism non manufacturing employment";

            /// <summary>
            /// ISM Non-Manufacturing New Orders - https://tradingeconomics.com/united-states/non-manufacturing-pmi
            /// </summary>
            public const string IsmNonManufacturingNewOrders = "ism non manufacturing new orders";

            /// <summary>
            /// ISM Non-Manufacturing Prices - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IsmNonManufacturingPrices = "ism non manufacturing prices";

            /// <summary>
            /// ISM Non-Manufacturing PMI - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IsmNonManufacturingPurchasingManagersIndex = "ism non manufacturing purchasing managers index";

            /// <summary>
            /// ISM Prices Paid - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string IsmPricesPaid = "ism prices paid";

            /// <summary>
            /// JOLTs Job Openings - https://tradingeconomics.com/united-states/job-offers
            /// </summary>
            public const string JoltsJobOpenings = "jolts job openings";

            /// <summary>
            /// Kansas Fed Manufacturing Index - https://tradingeconomics.com/united-states/kansas-fed-manufacturing-index
            /// </summary>
            public const string KansasFedManufacturingIndex = "kansas fed manufacturing index";

            /// <summary>
            /// Labour Costs Index QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string LaborCostsIndexQoQ = "labor costs index qoq";

            /// <summary>
            /// Manufacturing Payrolls - https://tradingeconomics.com/united-states/manufacturing-payrolls
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Labor Statistics
            /// </remarks>
            public const string ManufacturingPayrolls = "manufacturing payrolls";

            /// <summary>
            /// Manufacturing Production MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ManufacturingProductionMoM = "manufacturing production mom";

            /// <summary>
            /// Manufacturing Production YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ManufacturingProductionYoY = "manufacturing production yoy";

            /// <summary>
            /// Markit Composite PMI Final - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFinal = "markit composite purchasing managers index final";

            /// <summary>
            /// Markit Composite PMI Flash - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MarkitCompositePurchasingManagersIndexFlash = "markit composite purchasing managers index flash";

            /// <summary>
            /// Markit Manufacturing PMI - https://tradingeconomics.com/united-states/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndex = "markit manufacturing purchasing managers index";

            /// <summary>
            /// Markit Manufacturing PMI Final - https://tradingeconomics.com/united-states/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFinal = "markit manufacturing purchasing managers index final";

            /// <summary>
            /// Markit Manufacturing PMI Flash - https://tradingeconomics.com/united-states/manufacturing-pmi
            /// </summary>
            public const string MarkitManufacturingPurchasingManagersIndexFlash = "markit manufacturing purchasing managers index flash";

            /// <summary>
            /// Markit Services PMI Final - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFinal = "markit services purchasing managers index final";

            /// <summary>
            /// Markit Services PMI Flash - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexFlash = "markit services purchasing managers index flash";

            /// <summary>
            /// Markit Services PMI Prel - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MarkitServicesPurchasingManagersIndexPreliminary = "markit services purchasing managers index preliminary";

            /// <summary>
            /// Mass Layoffs - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MassLayoffs = "mass layoffs";

            /// <summary>
            /// MBA Mortgage Applications - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MbaMortgageApplications = "mba mortgage applications";

            /// <summary>
            /// MBA Mortgage Applications WoW - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MbaMortgageApplicationsWoW = "mba mortgage applications wow";

            /// <summary>
            /// MBA 30-Year Mortgage Rate - https://tradingeconomics.com/united-states/mortgage-rate
            /// </summary>
            public const string MbaThirtyYearMortgageRate = "mba 30 year mortgage rate";

            /// <summary>
            /// Michigan Consumer Expectations Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganConsumerExpectationsFinal = "michigan consumer expectations final";

            /// <summary>
            /// Michigan Consumer Expectations Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganConsumerExpectationsPreliminary = "michigan consumer expectations preliminary";

            /// <summary>
            /// Michigan Consumer Sentiment Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganConsumerSentimentFinal = "michigan consumer sentiment final";

            /// <summary>
            /// Michigan Consumer Sentiment Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganConsumerSentimentPreliminary = "michigan consumer sentiment preliminary";

            /// <summary>
            /// Michigan Current Conditions Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganCurrentConditionsFinal = "michigan current conditions final";

            /// <summary>
            /// Michigan Current Conditions Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganCurrentConditionsPreliminary = "michigan current conditions preliminary";

            /// <summary>
            /// Michigan 5 Year Inflation Expectations Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganFiveYearInflationExpectationsFinal = "michigan 5 year inflation expectations final";

            /// <summary>
            /// Michigan 5 Year Inflation Expectations Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganFiveYearInflationExpectationsPreliminary = "michigan 5 year inflation expectations preliminary";

            /// <summary>
            /// Michigan Inflation Expectations Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganInflationExpectationsFinal = "michigan inflation expectations final";

            /// <summary>
            /// Michigan Inflation Expectations Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string MichiganInflationExpectationsPreliminary = "michigan inflation expectations preliminary";

            /// <summary>
            /// Monthly Budget Statement - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string MonthlyBudgetStatement = "monthly budget statement";

            /// <summary>
            /// NAHB Housing Market Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NahbHousingMarketIndex = "nahb housing market index";

            /// <summary>
            /// National activity index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NationalActivityIndex = "national activity index";

            /// <summary>
            /// Net Long-Term Tic Flows - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NetLongTermTicFlows = "net long term tic flows";

            /// <summary>
            /// New Home Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NewHomeSales = "new home sales";

            /// <summary>
            /// New Home Sales MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NewHomeSalesMoM = "new home sales mom";

            /// <summary>
            /// NFIB Business Optimism Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NfibBusinessOptimismIndex = "nfib business optimism index";

            /// <summary>
            /// Non Farm Payrolls - https://tradingeconomics.com/united-states/non-farm-payrolls
            /// </summary>
            public const string NonFarmPayrolls = "non farm payrolls";

            /// <summary>
            /// Nonfarm Payrolls Private - https://tradingeconomics.com/united-states/nonfarm-payrolls-private
            /// </summary>
            /// <remarks>
            /// Source: U.S. Bureau of Labor Statistics
            /// </remarks>
            public const string NonFarmPayrollsPrivate = "non farm payrolls private";

            /// <summary>
            /// Nonfarm Productivity QoQ - https://tradingeconomics.com/united-states/productivity
            /// </summary>
            public const string NonFarmProductivityQoQ = "non farm productivity qoq";

            /// <summary>
            /// Nonfarm Productivity QoQ Final - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NonFarmProductivityQoQFinal = "non farm productivity qoq final";

            /// <summary>
            /// Nonfarm Productivity QoQ Prel - https://tradingeconomics.com/united-states/productivity
            /// </summary>
            public const string NonFarmProductivityQoQPreliminary = "non farm productivity qoq preliminary";

            /// <summary>
            /// Nonfarm Productivity YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NonFarmProductivityYoY = "non farm productivity yoy";

            /// <summary>
            /// Non-Manufacturing Business Activity - https://tradingeconomics.com/united-states/non-manufacturing-pmi
            /// </summary>
            /// <remarks>
            /// Source: Institute for Supply Management
            /// </remarks>
            public const string NonManufacturingBusinessActivity = "non manufacturing business activity";

            /// <summary>
            /// NY Empire State Manufacturing Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string NyEmpireStateManufacturingIndex = "ny empire state manufacturing index";

            /// <summary>
            /// Overall Net Capital Flows - https://tradingeconomics.com/united-states/capital-flows
            /// </summary>
            /// <remarks>
            /// Source: U.S. Department of the Treasury
            /// </remarks>
            public const string OverallNetCapitalFlows = "overall net capital flows";

            /// <summary>
            /// Participation Rate - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ParticipationRate = "participation rate";

            /// <summary>
            /// Pending Home Sales MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PendingHomeSalesMoM = "pending home sales mom";

            /// <summary>
            /// Pending Home Sales YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PendingHomeSalesYoY = "pending home sales yoy";

            /// <summary>
            /// PCE Price Index MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexMoM = "personal consumption expenditure price index mom";

            /// <summary>
            /// PCE Prices QoQ - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexQoQ = "personal consumption expenditure price index qoq";

            /// <summary>
            /// PCE Prices QoQ Adv - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexQoQAdvance = "personal consumption expenditure price index qoq advance";

            /// <summary>
            /// PCE Prices QoQ Final - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexQoQFinal = "personal consumption expenditure price index qoq final";

            /// <summary>
            /// PCE Prices QoQ 2 Est - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexQoQSecondEstimate = "personal consumption expenditure price index qoq second estimate";

            /// <summary>
            /// PCE Price Index YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalConsumptionExpenditurePriceIndexYoY = "personal consumption expenditure price index yoy";

            /// <summary>
            /// Personal Income (MoM) - https://tradingeconomics.com/united-states/personal-income
            /// </summary>
            public const string PersonalIncomeMoM = "personal income mom";

            /// <summary>
            /// Personal Spending MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PersonalSpendingMoM = "personal spending mom";

            /// <summary>
            /// Philadelphia Fed Manufacturing Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PhiladelphiaFedManufacturingIndex = "philadelphia fed manufacturing index";

            /// <summary>
            /// Presidential Election Results - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string PresidentialElectionResults = "presidential election results";

            /// <summary>
            /// PPI Exl. Food and Energy MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ProducerPriceIndexExcludingFoodAndEnergyMoM = "producer price index excluding food and energy mom";

            /// <summary>
            /// PPI Exl. Food and Energy YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ProducerPriceIndexExcludingFoodAndEnergyYoY = "producer price index excluding food and energy yoy";

            /// <summary>
            /// PPI MoM - https://tradingeconomics.com/united-states/producer-prices
            /// </summary>
            public const string ProducerPriceIndexMoM = "producer price index mom";

            /// <summary>
            /// PPI YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ProducerPriceIndexYoY = "producer price index yoy";

            /// <summary>
            /// QE MBS - https://tradingeconomics.com/united-states/interest-rate
            /// </summary>
            public const string QuantitativeEasingMortgageBackedSecurities = "quantitative easing mortgage backed securities";

            /// <summary>
            /// QE Total - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string QuantitativeEasingTotal = "quantitative easing total";

            /// <summary>
            /// QE Treasuries - https://tradingeconomics.com/united-states/interest-rate
            /// </summary>
            public const string QuantitativeEasingTreasuries = "quantitative easing treasuries";

            /// <summary>
            /// Real Consumer Spending - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RealConsumerSpending = "real consumer spending";

            /// <summary>
            /// Redbook MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RedbookMoM = "redbook mom";

            /// <summary>
            /// Redbook YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RedbookYoY = "redbook yoy";

            /// <summary>
            /// Retail Sales Ex Autos MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RetailSalesExcludingAutosMoM = "retail sales excluding autos mom";

            /// <summary>
            /// Retail Sales Ex Gas/Autos  MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RetailSalesExcludingGasAutosMoM = "retail sales excluding gas autos mom";

            /// <summary>
            /// Retail Sales MoM - https://tradingeconomics.com/united-states/retail-sales
            /// </summary>
            public const string RetailSalesMoM = "retail sales mom";

            /// <summary>
            /// Retail Sales YoY - https://tradingeconomics.com/united-states/retail-sales-annual
            /// </summary>
            public const string RetailSalesYoY = "retail sales yoy";

            /// <summary>
            /// Reuters Michigan Consumer Expectations - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganConsumerExpectations = "reuters michigan consumer expectations";

            /// <summary>
            /// Reuters Michigan Consumer Expectations Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganConsumerExpectationsFinal = "reuters michigan consumer expectations final";

            /// <summary>
            /// Reuters Michigan Consumer Expectations Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            public const string ReutersMichiganConsumerExpectationsPreliminary = "reuters michigan consumer expectations preliminary";

            /// <summary>
            /// Reuters Michigan Consumer Sentiment Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganConsumerSentimentFinal = "reuters michigan consumer sentiment final";

            /// <summary>
            /// Reuters/Michigan Consumer Sentiment Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ReutersMichiganConsumerSentimentIndex = "reuters michigan consumer sentiment index";

            /// <summary>
            /// Reuters Michigan Consumer Sentiment Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganConsumerSentimentPreliminary = "reuters michigan consumer sentiment preliminary";

            /// <summary>
            /// Reuters Michigan Current Conditions - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganCurrentConditions = "reuters michigan current conditions";

            /// <summary>
            /// Reuters Michigan Current Conditions Final - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            /// <remarks>
            /// Source: University of Michigan
            /// </remarks>
            public const string ReutersMichiganCurrentConditionsFinal = "reuters michigan current conditions final";

            /// <summary>
            /// Reuters Michigan Current Conditions Prel - https://tradingeconomics.com/united-states/consumer-confidence
            /// </summary>
            public const string ReutersMichiganCurrentConditionsPreliminary = "reuters michigan current conditions preliminary";

            /// <summary>
            /// Reuters Michigan Inflation Expectations Prel - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ReutersMichiganInflationExpectationsPreliminary = "reuters michigan inflation expectations preliminary";

            /// <summary>
            /// Richmond Fed Manufacturing Index - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string RichmondFedManufacturingIndex = "richmond fed manufacturing index";

            /// <summary>
            /// S&P/Case-Shiller Home Price MoM - https://tradingeconomics.com/united-states/case-shiller-home-price-index
            /// </summary>
            public const string SandpCaseShillerHomePriceMoM = "sandp case shiller home price mom";

            /// <summary>
            /// S&P/Case-Shiller Home Price YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string SandpCaseShillerHomePriceYoY = "sandp case shiller home price yoy";

            /// <summary>
            /// 7-Year Note Auction - https://tradingeconomics.com/united-states/7-year-note-yield
            /// </summary>
            public const string SevenYearNoteAuction = "7 year note auction";

            /// <summary>
            /// 6-Month Bill Auction - https://tradingeconomics.com/united-states/6-month-bill-yield
            /// </summary>
            public const string SixMonthBillAuction = "6 month bill auction";

            /// <summary>
            /// 10-Year Note Auction - https://tradingeconomics.com/united-states/government-bond-yield
            /// </summary>
            public const string TenYearNoteAuction = "10 year note auction";

            /// <summary>
            /// 10-Year TIPS Auction - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string TenYearTipsAuction = "10 year tips auction";

            /// <summary>
            /// 30-Year Bond Auction - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ThirtyYearBondAuction = "30 year bond auction";

            /// <summary>
            /// 30-Year Note Auction - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string ThirtyYearNoteAuction = "30 year note auction";

            /// <summary>
            /// 3-Month Bill Auction - https://tradingeconomics.com/united-states/3-month-bill-yield
            /// </summary>
            public const string ThreeMonthBillAuction = "3 month bill auction";

            /// <summary>
            /// 3-Year Note Auction - https://tradingeconomics.com/united-states/3-year-note-yield
            /// </summary>
            public const string ThreeYearNoteAuction = "3 year note auction";

            /// <summary>
            /// Total Net TIC Flows - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string TotalNetTicFlows = "total net tic flows";

            /// <summary>
            /// Total Vehicle Sales - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string TotalVehicleSales = "total vehicle sales";

            /// <summary>
            /// 2-Year Note Auction - https://tradingeconomics.com/united-states/2-year-note-yield
            /// </summary>
            public const string TwoYearNoteAuction = "2 year note auction";

            /// <summary>
            /// Unemployment Rate - https://tradingeconomics.com/united-states/unemployment-rate
            /// </summary>
            public const string UnemploymentRate = "unemployment rate";

            /// <summary>
            /// Unit Labor Costs QoQ - https://tradingeconomics.com/united-states/labour-costs
            /// </summary>
            public const string UnitLaborCostsIndexQoQ = "unit labor costs index qoq";

            /// <summary>
            /// Unit Labour Costs QoQ Final - https://tradingeconomics.com/united-states/labour-costs
            /// </summary>
            public const string UnitLaborCostsIndexQoQFinal = "unit labor costs index qoq final";

            /// <summary>
            /// Unit Labour Costs QoQ Prel - https://tradingeconomics.com/united-states/labour-costs
            /// </summary>
            public const string UnitLaborCostsIndexQoQPreliminary = "unit labor costs index qoq preliminary";

            /// <summary>
            /// Unit Labor Costs YoY - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string UnitLaborCostsYoY = "unit labor costs yoy";

            /// <summary>
            /// Wholesale Inventories MoM - https://tradingeconomics.com/united-states/calendar
            /// </summary>
            public const string WholesaleInventoriesMoM = "wholesale inventories mom";

            /// <summary>
            /// Wholesale Inventories MoM Adv - https://tradingeconomics.com/united-states/wholesale-inventories
            /// </summary>
            /// <remarks>
            /// Source: U.S. Census Bureau
            /// </remarks>
            public const string WholesaleInventoriesMoMAdvance = "wholesale inventories mom advance";

        }
    }
}
