from .__Fundamental_26 import *
import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Data.Fundamental.MultiPeriodField
import QuantConnect.Data.Fundamental
import QuantConnect.Data
import QuantConnect
import datetime


class FinanceLeaseReceivablesNonCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Accounts owed to the bank in relation to capital leases to be received beyond the next accounting PeriodAsByte. Capital/ finance lease
                obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
    
    FinanceLeaseReceivablesNonCurrentBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialAssetsBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Fair values as of the balance sheet date of all assets resulting from contracts that meet the criteria of being accounted for as
                derivative instruments, net of the effects of master netting arrangements.
    
    FinancialAssetsBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    NineMonths: float

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialAssetsDesignatedasFairValueThroughProfitorLossTotalBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial assets that are held at fair value through profit or loss comprise assets held for trading and those financial assets
                designated as being held at fair value through profit or loss.
    
    FinancialAssetsDesignatedasFairValueThroughProfitorLossTotalBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialInstrumentsSoldUnderAgreementsToRepurchaseBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The carrying value as of the balance sheet date of securities that an institution sells and agrees to repurchase (the identical or
                substantially the same securities) as a seller-borrower at a specified date for a specified price, also known as a repurchase
                agreement.  This item is typically available for bank industry.
    
    FinancialInstrumentsSoldUnderAgreementsToRepurchaseBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    SixMonths: float

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialLeverage(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Refers to the ratio of Total Assets to Common Equity. Morningstar calculates the ratio by using the underlying data reported in the
                Balance Sheet within the company filings or reports:    Total Assets / Common Equity.   [Note: Common Equity = Total
                Shareholder's Equity - Preferred Stock]
    
    FinancialLeverage(store: IDictionary[str, Decimal])
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

    OneYear: float

    SixMonths: float

    ThreeMonths: float

    TwoMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialLiabilitiesCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial related liabilities due within one year, including short term and current portions of long-term debt, capital leases and
                derivative liabilities.
    
    FinancialLiabilitiesCurrentBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialLiabilitiesDesignatedasFairValueThroughProfitorLossTotalBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial liabilities that are held at fair value through profit or loss.
    
    FinancialLiabilitiesDesignatedasFairValueThroughProfitorLossTotalBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialLiabilitiesMeasuredatAmortizedCostTotalBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial liabilities carried at amortized cost.
    
    FinancialLiabilitiesMeasuredatAmortizedCostTotalBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialLiabilitiesNonCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial related liabilities due beyond one year, including long term debt, capital leases and derivative liabilities.
    
    FinancialLiabilitiesNonCurrentBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialOrDerivativeInvestmentCurrentLiabilitiesBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Financial instruments that are linked to a specific financial instrument or indicator or commodity, and through which specific
                financial risks can be traded in financial markets in their own right, such as financial options, futures, forwards, etc.
    
    FinancialOrDerivativeInvestmentCurrentLiabilitiesBalanceSheet(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    ThreeMonths: float

    TwelveMonths: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinancialStatements(System.object):
    """
    Definition of the FinancialStatements class
    
    FinancialStatements()
    """
    def UpdateValues(self, update: QuantConnect.Data.Fundamental.FinancialStatements) -> None:
        pass

    AccessionNumber: str

    AuditorReportStatus: str

    BalanceSheet: QuantConnect.Data.Fundamental.BalanceSheet

    CashFlowStatement: QuantConnect.Data.Fundamental.CashFlowStatement

    FileDate: datetime.datetime

    FormType: str

    IncomeStatement: QuantConnect.Data.Fundamental.IncomeStatement

    InventoryValuationMethod: str

    NumberOfShareHolders: int

    PeriodAuditor: str

    PeriodEndingDate: datetime.datetime

    PeriodType: str

    TotalRiskBasedCapital: QuantConnect.Data.Fundamental.TotalRiskBasedCapital



class FinancingCashFlowCashFlowStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The net cash inflow (outflow) from financing activity for the period, which involve changes to the long-term liabilities and
                stockholders' equity.
    
    FinancingCashFlowCashFlowStatement(store: IDictionary[str, Decimal])
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
