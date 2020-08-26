from .__Fundamental_31 import *
import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Data.Fundamental.MultiPeriodField
import QuantConnect.Data.Fundamental
import QuantConnect.Data
import QuantConnect
import datetime


class ImpairmentLossReversalRecognizedinProfitorLossCashFlowStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The difference between the future net cash flows expected to be received from the asset and its book value, recognized in the
                Income Statement.
    
    ImpairmentLossReversalRecognizedinProfitorLossCashFlowStatement(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    NineMonths: float

    SixMonths: float

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class ImpairmentOfCapitalAssetsIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Impairments are considered to be permanent, which is a downward revaluation of fixed assets. If the sum of all estimated future
                cash flows is less than the carrying value of the asset, then the asset would be considered impaired and would have to be written
                down to its fair value. Once an asset is written down, it may only be written back up under very few circumstances. Usually the
                company uses the sum of undiscounted future cash flows to determine if the impairment should occur, and uses the sum of
                discounted future cash flows to make the impairment judgment. The impairment decision emphasizes on capital assets' future
                profit collection ability.
    
    ImpairmentOfCapitalAssetsIncomeStatement(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    NineMonths: float

    OneMonth: float

    SixMonths: float

    ThreeMonths: float

    TwelveMonths: float

    TwoMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class IncomefromAssociatesandOtherParticipatingInterestsIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Total income from the associates and joint venture via investment, accounted for in the Non-Operating section.
    
    IncomefromAssociatesandOtherParticipatingInterestsIncomeStatement(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    NineMonths: float

    SixMonths: float

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class IncomeStatement(System.object):
    """
    Definition of the IncomeStatement class
    
    IncomeStatement()
    """
    def UpdateValues(self, update: QuantConnect.Data.Fundamental.IncomeStatement) -> None:
        pass

    Amortization: QuantConnect.Data.Fundamental.AmortizationIncomeStatement

    AmortizationOfIntangibles: QuantConnect.Data.Fundamental.AmortizationOfIntangiblesIncomeStatement

    AmortizationSupplemental: QuantConnect.Data.Fundamental.AmortizationSupplementalIncomeStatement

    AverageDilutionEarnings: QuantConnect.Data.Fundamental.AverageDilutionEarningsIncomeStatement

    CededPremiums: QuantConnect.Data.Fundamental.CededPremiumsIncomeStatement

    ChangeinInsuranceLiabilitiesNetofReinsurance: QuantConnect.Data.Fundamental.ChangeinInsuranceLiabilitiesNetofReinsuranceIncomeStatement

    ChangeinInvestmentContract: QuantConnect.Data.Fundamental.ChangeinInvestmentContractIncomeStatement

    ChangeinTheGrossProvisionforUnearnedPremiums: QuantConnect.Data.Fundamental.ChangeinTheGrossProvisionforUnearnedPremiumsIncomeStatement

    ChangeinTheGrossProvisionforUnearnedPremiumsReinsurersShare: QuantConnect.Data.Fundamental.ChangeinTheGrossProvisionforUnearnedPremiumsReinsurersShareIncomeStatement

    ClaimsandChangeinInsuranceLiabilities: QuantConnect.Data.Fundamental.ClaimsandChangeinInsuranceLiabilitiesIncomeStatement

    ClaimsandPaidIncurred: QuantConnect.Data.Fundamental.ClaimsandPaidIncurredIncomeStatement

    CommissionExpenses: QuantConnect.Data.Fundamental.CommissionExpensesIncomeStatement

    CostOfRevenue: QuantConnect.Data.Fundamental.CostOfRevenueIncomeStatement

    CreditCard: QuantConnect.Data.Fundamental.CreditCardIncomeStatement

    CreditLossesProvision: QuantConnect.Data.Fundamental.CreditLossesProvisionIncomeStatement

    CreditRiskProvisions: QuantConnect.Data.Fundamental.CreditRiskProvisionsIncomeStatement

    DDACostofRevenue: QuantConnect.Data.Fundamental.DDACostofRevenueIncomeStatement

    Depletion: QuantConnect.Data.Fundamental.DepletionIncomeStatement

    Depreciation: QuantConnect.Data.Fundamental.DepreciationIncomeStatement

    DepreciationAmortizationDepletion: QuantConnect.Data.Fundamental.DepreciationAmortizationDepletionIncomeStatement

    DepreciationAndAmortization: QuantConnect.Data.Fundamental.DepreciationAndAmortizationIncomeStatement

    DepreciationSupplemental: QuantConnect.Data.Fundamental.DepreciationSupplementalIncomeStatement

    DilutedNIAvailtoComStockholders: QuantConnect.Data.Fundamental.DilutedNIAvailtoComStockholdersIncomeStatement

    DividendIncome: QuantConnect.Data.Fundamental.DividendIncomeIncomeStatement

    EarningsFromEquityInterest: QuantConnect.Data.Fundamental.EarningsFromEquityInterestIncomeStatement

    EarningsfromEquityInterestNetOfTax: QuantConnect.Data.Fundamental.EarningsfromEquityInterestNetOfTaxIncomeStatement

    EBIT: QuantConnect.Data.Fundamental.EBITIncomeStatement

    EBITDA: QuantConnect.Data.Fundamental.EBITDAIncomeStatement

    EffectiveTaxRateAsReported: QuantConnect.Data.Fundamental.EffectiveTaxRateAsReportedIncomeStatement

    Equipment: QuantConnect.Data.Fundamental.EquipmentIncomeStatement

    ExciseTaxes: QuantConnect.Data.Fundamental.ExciseTaxesIncomeStatement

    ExplorationDevelopmentAndMineralPropertyLeaseExpenses: QuantConnect.Data.Fundamental.ExplorationDevelopmentAndMineralPropertyLeaseExpensesIncomeStatement

    FeeRevenueAndOtherIncome: QuantConnect.Data.Fundamental.FeeRevenueAndOtherIncomeIncomeStatement

    FeesandCommissionExpense: QuantConnect.Data.Fundamental.FeesandCommissionExpenseIncomeStatement

    FeesandCommissionIncome: QuantConnect.Data.Fundamental.FeesandCommissionIncomeIncomeStatement

    FeesAndCommissions: QuantConnect.Data.Fundamental.FeesAndCommissionsIncomeStatement

    ForeignExchangeTradingGains: QuantConnect.Data.Fundamental.ForeignExchangeTradingGainsIncomeStatement

    Fuel: QuantConnect.Data.Fundamental.FuelIncomeStatement

    FuelAndPurchasePower: QuantConnect.Data.Fundamental.FuelAndPurchasePowerIncomeStatement

    GainLossonDerecognitionofAvailableForSaleFinancialAssets: QuantConnect.Data.Fundamental.GainLossonDerecognitionofAvailableForSaleFinancialAssetsIncomeStatement

    GainLossonFinancialInstrumentsDesignatedasCashFlowHedges: QuantConnect.Data.Fundamental.GainLossonFinancialInstrumentsDesignatedasCashFlowHedgesIncomeStatement

    GainLossonSaleofAssets: QuantConnect.Data.Fundamental.GainLossonSaleofAssetsIncomeStatement

    GainonInvestmentProperties: QuantConnect.Data.Fundamental.GainonInvestmentPropertiesIncomeStatement

    GainOnSaleOfBusiness: QuantConnect.Data.Fundamental.GainOnSaleOfBusinessIncomeStatement

    GainonSaleofInvestmentProperty: QuantConnect.Data.Fundamental.GainonSaleofInvestmentPropertyIncomeStatement

    GainonSaleofLoans: QuantConnect.Data.Fundamental.GainonSaleofLoansIncomeStatement

    GainOnSaleOfPPE: QuantConnect.Data.Fundamental.GainOnSaleOfPPEIncomeStatement

    GainOnSaleOfSecurity: QuantConnect.Data.Fundamental.GainOnSaleOfSecurityIncomeStatement

    GainsLossesonFinancialInstrumentsDuetoFairValueAdjustmentsinHedgeAccountingTotal: QuantConnect.Data.Fundamental.GainsLossesonFinancialInstrumentsDuetoFairValueAdjustmentsinHedgeAccountingTotalIncomeStatement

    GeneralAndAdministrativeExpense: QuantConnect.Data.Fundamental.GeneralAndAdministrativeExpenseIncomeStatement

    GrossDividendPayment: QuantConnect.Data.Fundamental.GrossDividendPaymentIncomeStatement

    GrossPremiumsWritten: QuantConnect.Data.Fundamental.GrossPremiumsWrittenIncomeStatement

    GrossProfit: QuantConnect.Data.Fundamental.GrossProfitIncomeStatement

    ImpairmentLossesReversalsFinancialInstrumentsNet: QuantConnect.Data.Fundamental.ImpairmentLossesReversalsFinancialInstrumentsNetIncomeStatement

    ImpairmentOfCapitalAssets: QuantConnect.Data.Fundamental.ImpairmentOfCapitalAssetsIncomeStatement

    IncomefromAssociatesandOtherParticipatingInterests: QuantConnect.Data.Fundamental.IncomefromAssociatesandOtherParticipatingInterestsIncomeStatement

    IncreaseDecreaseInNetUnearnedPremiumReserves: QuantConnect.Data.Fundamental.IncreaseDecreaseInNetUnearnedPremiumReservesIncomeStatement

    InsuranceAndClaims: QuantConnect.Data.Fundamental.InsuranceAndClaimsIncomeStatement

    InterestExpense: QuantConnect.Data.Fundamental.InterestExpenseIncomeStatement

    InterestExpenseForDeposit: QuantConnect.Data.Fundamental.InterestExpenseForDepositIncomeStatement

    InterestExpenseForFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResell: QuantConnect.Data.Fundamental.InterestExpenseForFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellIncomeStatement

    InterestExpenseForLongTermDebtAndCapitalSecurities: QuantConnect.Data.Fundamental.InterestExpenseForLongTermDebtAndCapitalSecuritiesIncomeStatement

    InterestExpenseForShortTermDebt: QuantConnect.Data.Fundamental.InterestExpenseForShortTermDebtIncomeStatement

    InterestExpenseNonOperating: QuantConnect.Data.Fundamental.InterestExpenseNonOperatingIncomeStatement

    InterestIncome: QuantConnect.Data.Fundamental.InterestIncomeIncomeStatement

    InterestIncomeAfterProvisionForLoanLoss: QuantConnect.Data.Fundamental.InterestIncomeAfterProvisionForLoanLossIncomeStatement

    InterestIncomeFromDeposits: QuantConnect.Data.Fundamental.InterestIncomeFromDepositsIncomeStatement

    InterestIncomeFromFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResell: QuantConnect.Data.Fundamental.InterestIncomeFromFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellIncomeStatement

    InterestIncomeFromLeases: QuantConnect.Data.Fundamental.InterestIncomeFromLeasesIncomeStatement

    InterestIncomeFromLoans: QuantConnect.Data.Fundamental.InterestIncomeFromLoansIncomeStatement

    InterestIncomeFromLoansAndLease: QuantConnect.Data.Fundamental.InterestIncomeFromLoansAndLeaseIncomeStatement

    InterestIncomeFromSecurities: QuantConnect.Data.Fundamental.InterestIncomeFromSecuritiesIncomeStatement

    InterestIncomeNonOperating: QuantConnect.Data.Fundamental.InterestIncomeNonOperatingIncomeStatement

    InvestmentBankingProfit: QuantConnect.Data.Fundamental.InvestmentBankingProfitIncomeStatement

    InvestmentContractLiabilitiesIncurred: QuantConnect.Data.Fundamental.InvestmentContractLiabilitiesIncurredIncomeStatement

    ISFileDate: datetime.datetime

    LossAdjustmentExpense: QuantConnect.Data.Fundamental.LossAdjustmentExpenseIncomeStatement

    LossonExtinguishmentofDebt: QuantConnect.Data.Fundamental.LossonExtinguishmentofDebtIncomeStatement

    MaintenanceAndRepairs: QuantConnect.Data.Fundamental.MaintenanceAndRepairsIncomeStatement

    MinorityInterests: QuantConnect.Data.Fundamental.MinorityInterestsIncomeStatement

    NegativeGoodwillImmediatelyRecognized: QuantConnect.Data.Fundamental.NegativeGoodwillImmediatelyRecognizedIncomeStatement

    NetForeignExchangeGainLoss: QuantConnect.Data.Fundamental.NetForeignExchangeGainLossIncomeStatement

    NetIncome: QuantConnect.Data.Fundamental.NetIncomeIncomeStatement

    NetIncomeCommonStockholders: QuantConnect.Data.Fundamental.NetIncomeCommonStockholdersIncomeStatement

    NetIncomeContinuousOperations: QuantConnect.Data.Fundamental.NetIncomeContinuousOperationsIncomeStatement

    NetIncomeContinuousOperationsNetMinorityInterest: QuantConnect.Data.Fundamental.NetIncomeContinuousOperationsNetMinorityInterestIncomeStatement

    NetIncomeDiscontinuousOperations: QuantConnect.Data.Fundamental.NetIncomeDiscontinuousOperationsIncomeStatement

    NetIncomeExtraordinary: QuantConnect.Data.Fundamental.NetIncomeExtraordinaryIncomeStatement

    NetIncomeFromContinuingAndDiscontinuedOperation: QuantConnect.Data.Fundamental.NetIncomeFromContinuingAndDiscontinuedOperationIncomeStatement

    NetIncomeFromContinuingOperationNetMinorityInterest: QuantConnect.Data.Fundamental.NetIncomeFromContinuingOperationNetMinorityInterestIncomeStatement

    NetIncomeFromTaxLossCarryforward: QuantConnect.Data.Fundamental.NetIncomeFromTaxLossCarryforwardIncomeStatement

    NetIncomeIncludingNoncontrollingInterests: QuantConnect.Data.Fundamental.NetIncomeIncludingNoncontrollingInterestsIncomeStatement

    NetInterestIncome: QuantConnect.Data.Fundamental.NetInterestIncomeIncomeStatement

    NetInvestmentIncome: QuantConnect.Data.Fundamental.NetInvestmentIncomeIncomeStatement

    NetNonOperatingInterestIncomeExpense: QuantConnect.Data.Fundamental.NetNonOperatingInterestIncomeExpenseIncomeStatement

    NetOccupancyExpense: QuantConnect.Data.Fundamental.NetOccupancyExpenseIncomeStatement

    NetPolicyholderBenefitsAndClaims: QuantConnect.Data.Fundamental.NetPolicyholderBenefitsAndClaimsIncomeStatement

    NetPremiumsWritten: QuantConnect.Data.Fundamental.NetPremiumsWrittenIncomeStatement

    NetRealizedGainLossOnInvestments: QuantConnect.Data.Fundamental.NetRealizedGainLossOnInvestmentsIncomeStatement

    NetTradingIncome: QuantConnect.Data.Fundamental.NetTradingIncomeIncomeStatement

    NonInterestExpense: QuantConnect.Data.Fundamental.NonInterestExpenseIncomeStatement

    NonInterestIncome: QuantConnect.Data.Fundamental.NonInterestIncomeIncomeStatement

    NormalizedEBITAsReported: QuantConnect.Data.Fundamental.NormalizedEBITAsReportedIncomeStatement

    NormalizedEBITDA: QuantConnect.Data.Fundamental.NormalizedEBITDAIncomeStatement

    NormalizedEBITDAAsReported: QuantConnect.Data.Fundamental.NormalizedEBITDAAsReportedIncomeStatement

    NormalizedIncome: QuantConnect.Data.Fundamental.NormalizedIncomeIncomeStatement

    NormalizedIncomeAsReported: QuantConnect.Data.Fundamental.NormalizedIncomeAsReportedIncomeStatement

    NormalizedOperatingProfitAsReported: QuantConnect.Data.Fundamental.NormalizedOperatingProfitAsReportedIncomeStatement

    NormalizedPreTaxIncome: QuantConnect.Data.Fundamental.NormalizedPreTaxIncomeIncomeStatement

    OccupancyAndEquipment: QuantConnect.Data.Fundamental.OccupancyAndEquipmentIncomeStatement

    OperatingExpense: QuantConnect.Data.Fundamental.OperatingExpenseIncomeStatement

    OperatingExpenseAsReported: QuantConnect.Data.Fundamental.OperatingExpenseAsReportedIncomeStatement

    OperatingIncome: QuantConnect.Data.Fundamental.OperatingIncomeIncomeStatement

    OperatingRevenue: QuantConnect.Data.Fundamental.OperatingRevenueIncomeStatement

    OperationAndMaintenance: QuantConnect.Data.Fundamental.OperationAndMaintenanceIncomeStatement

    OtherCostofRevenue: QuantConnect.Data.Fundamental.OtherCostofRevenueIncomeStatement

    OtherCustomerServices: QuantConnect.Data.Fundamental.OtherCustomerServicesIncomeStatement

    OtherGA: QuantConnect.Data.Fundamental.OtherGAIncomeStatement

    OtherIncomeExpense: QuantConnect.Data.Fundamental.OtherIncomeExpenseIncomeStatement

    OtherInterestExpense: QuantConnect.Data.Fundamental.OtherInterestExpenseIncomeStatement

    OtherInterestIncome: QuantConnect.Data.Fundamental.OtherInterestIncomeIncomeStatement

    OtherNonInterestExpense: QuantConnect.Data.Fundamental.OtherNonInterestExpenseIncomeStatement

    OtherNonInterestIncome: QuantConnect.Data.Fundamental.OtherNonInterestIncomeIncomeStatement

    OtherNonOperatingExpenses: QuantConnect.Data.Fundamental.OtherNonOperatingExpensesIncomeStatement

    OtherNonOperatingIncome: QuantConnect.Data.Fundamental.OtherNonOperatingIncomeIncomeStatement

    OtherNonOperatingIncomeExpenses: QuantConnect.Data.Fundamental.OtherNonOperatingIncomeExpensesIncomeStatement

    OtherOperatingExpenses: QuantConnect.Data.Fundamental.OtherOperatingExpensesIncomeStatement

    OtherOperatingIncomeTotal: QuantConnect.Data.Fundamental.OtherOperatingIncomeTotalIncomeStatement

    OtherSpecialCharges: QuantConnect.Data.Fundamental.OtherSpecialChargesIncomeStatement

    OtherStaffCosts: QuantConnect.Data.Fundamental.OtherStaffCostsIncomeStatement

    OtherTaxes: QuantConnect.Data.Fundamental.OtherTaxesIncomeStatement

    OtherunderPreferredStockDividend: QuantConnect.Data.Fundamental.OtherunderPreferredStockDividendIncomeStatement

    PensionCosts: QuantConnect.Data.Fundamental.PensionCostsIncomeStatement

    PolicyAcquisitionExpense: QuantConnect.Data.Fundamental.PolicyAcquisitionExpenseIncomeStatement

    PolicyholderBenefitsCeded: QuantConnect.Data.Fundamental.PolicyholderBenefitsCededIncomeStatement

    PolicyholderBenefitsGross: QuantConnect.Data.Fundamental.PolicyholderBenefitsGrossIncomeStatement

    PolicyholderDividends: QuantConnect.Data.Fundamental.PolicyholderDividendsIncomeStatement

    PolicyholderInterest: QuantConnect.Data.Fundamental.PolicyholderInterestIncomeStatement

    PreferredStockDividends: QuantConnect.Data.Fundamental.PreferredStockDividendsIncomeStatement

    PretaxIncome: QuantConnect.Data.Fundamental.PretaxIncomeIncomeStatement

    ProfessionalExpenseAndContractServicesExpense: QuantConnect.Data.Fundamental.ProfessionalExpenseAndContractServicesExpenseIncomeStatement

    ProvisionForDoubtfulAccounts: QuantConnect.Data.Fundamental.ProvisionForDoubtfulAccountsIncomeStatement

    ReconciledCostOfRevenue: QuantConnect.Data.Fundamental.ReconciledCostOfRevenueIncomeStatement

    ReconciledDepreciation: QuantConnect.Data.Fundamental.ReconciledDepreciationIncomeStatement

    ReinsuranceRecoveriesClaimsandBenefits: QuantConnect.Data.Fundamental.ReinsuranceRecoveriesClaimsandBenefitsIncomeStatement

    ReinsuranceRecoveriesofInsuranceLiabilities: QuantConnect.Data.Fundamental.ReinsuranceRecoveriesofInsuranceLiabilitiesIncomeStatement

    ReinsuranceRecoveriesofInvestmentContract: QuantConnect.Data.Fundamental.ReinsuranceRecoveriesofInvestmentContractIncomeStatement

    RentAndLandingFees: QuantConnect.Data.Fundamental.RentAndLandingFeesIncomeStatement

    RentandLandingFeesCostofRevenue: QuantConnect.Data.Fundamental.RentandLandingFeesCostofRevenueIncomeStatement

    RentExpenseSupplemental: QuantConnect.Data.Fundamental.RentExpenseSupplementalIncomeStatement

    ResearchAndDevelopment: QuantConnect.Data.Fundamental.ResearchAndDevelopmentIncomeStatement

    ResearchAndDevelopmentExpensesSupplemental: QuantConnect.Data.Fundamental.ResearchAndDevelopmentExpensesSupplementalIncomeStatement

    RestructuringAndMergernAcquisition: QuantConnect.Data.Fundamental.RestructuringAndMergernAcquisitionIncomeStatement

    SalariesAndWages: QuantConnect.Data.Fundamental.SalariesAndWagesIncomeStatement

    SecuritiesActivities: QuantConnect.Data.Fundamental.SecuritiesActivitiesIncomeStatement

    SecuritiesAmortization: QuantConnect.Data.Fundamental.SecuritiesAmortizationIncomeStatement

    SellingAndMarketingExpense: QuantConnect.Data.Fundamental.SellingAndMarketingExpenseIncomeStatement

    SellingGeneralAndAdministration: QuantConnect.Data.Fundamental.SellingGeneralAndAdministrationIncomeStatement

    ServiceChargeOnDepositorAccounts: QuantConnect.Data.Fundamental.ServiceChargeOnDepositorAccountsIncomeStatement

    SocialSecurityCosts: QuantConnect.Data.Fundamental.SocialSecurityCostsIncomeStatement

    SpecialIncomeCharges: QuantConnect.Data.Fundamental.SpecialIncomeChargesIncomeStatement

    StaffCosts: QuantConnect.Data.Fundamental.StaffCostsIncomeStatement

    StockBasedCompensation: QuantConnect.Data.Fundamental.StockBasedCompensationIncomeStatement

    TaxEffectOfUnusualItems: QuantConnect.Data.Fundamental.TaxEffectOfUnusualItemsIncomeStatement

    TaxProvision: QuantConnect.Data.Fundamental.TaxProvisionIncomeStatement

    TaxRateForCalcs: QuantConnect.Data.Fundamental.TaxRateForCalcsIncomeStatement

    TotalDividendPaymentofEquityShares: QuantConnect.Data.Fundamental.TotalDividendPaymentofEquitySharesIncomeStatement

    TotalDividendPaymentofNonEquityShares: QuantConnect.Data.Fundamental.TotalDividendPaymentofNonEquitySharesIncomeStatement

    TotalExpenses: QuantConnect.Data.Fundamental.TotalExpensesIncomeStatement

    TotalMoneyMarketInvestments: QuantConnect.Data.Fundamental.TotalMoneyMarketInvestmentsIncomeStatement

    TotalOperatingIncomeAsReported: QuantConnect.Data.Fundamental.TotalOperatingIncomeAsReportedIncomeStatement

    TotalOtherFinanceCost: QuantConnect.Data.Fundamental.TotalOtherFinanceCostIncomeStatement

    TotalPremiumsEarned: QuantConnect.Data.Fundamental.TotalPremiumsEarnedIncomeStatement

    TotalRevenue: QuantConnect.Data.Fundamental.TotalRevenueIncomeStatement

    TotalRevenueAsReported: QuantConnect.Data.Fundamental.TotalRevenueAsReportedIncomeStatement

    TotalUnusualItems: QuantConnect.Data.Fundamental.TotalUnusualItemsIncomeStatement

    TotalUnusualItemsExcludingGoodwill: QuantConnect.Data.Fundamental.TotalUnusualItemsExcludingGoodwillIncomeStatement

    TradingGainLoss: QuantConnect.Data.Fundamental.TradingGainLossIncomeStatement

    TrustFeesbyCommissions: QuantConnect.Data.Fundamental.TrustFeesbyCommissionsIncomeStatement

    UnderwritingExpenses: QuantConnect.Data.Fundamental.UnderwritingExpensesIncomeStatement

    WagesandSalaries: QuantConnect.Data.Fundamental.WagesandSalariesIncomeStatement

    WriteOff: QuantConnect.Data.Fundamental.WriteOffIncomeStatement
