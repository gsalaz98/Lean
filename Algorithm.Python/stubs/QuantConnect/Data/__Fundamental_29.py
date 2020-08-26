from .__Fundamental_30 import *
import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Data.Fundamental.MultiPeriodField
import QuantConnect.Data.Fundamental
import QuantConnect.Data
import QuantConnect
import datetime


class GrossDividendPaymentIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Total amount paid in dividends to investors- this includes dividends paid on equity and non-equity shares.
    
    GrossDividendPaymentIncomeStatement(store: IDictionary[str, Decimal])
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


class GrossLoanBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Represents the sum of all loans (commercial, consumer, mortgage, etc.) as well as leases before any provisions for loan losses or
                unearned discounts.
    
    GrossLoanBalanceSheet(store: IDictionary[str, Decimal])
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


class GrossMargin(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Refers to the ratio of gross profit to revenue. Morningstar calculates the ratio by using the underlying data reported in the company
                filings or reports:   (Revenue - Cost of Goods Sold) / Revenue.
    
    GrossMargin(store: IDictionary[str, Decimal])
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


class GrossMargin5YrAvg(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    This is the simple average of the company's Annual Gross Margin over the last 5 years. Gross Margin is Total Revenue minus Cost
                of Goods Sold divided by Total Revenue and is expressed as a percentage.
    
    GrossMargin5YrAvg(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    FiveYears: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class GrossNotesReceivableBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    An amount representing an agreement for an unconditional promise by the maker to pay the entity (holder) a definite sum of money
                at a future date(s) within one year of the balance sheet date or the normal operating cycle. Such amount may include accrued
                interest receivable in accordance with the terms of the note. The note also may contain provisions including a discount or premium,
                payable on demand, secured, or unsecured, interest bearing or non-interest bearing, among myriad other features and
                characteristics. This item is typically available for bank industry.
    
    GrossNotesReceivableBalanceSheet(store: IDictionary[str, Decimal])
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


class GrossPPEBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Carrying amount at the balance sheet date for long-lived physical assets used in the normal conduct of business and not intended
                for resale. This can include land, physical structures, machinery, vehicles, furniture, computer equipment, construction in progress,
                and similar items. Amount does not include depreciation.
    
    GrossPPEBalanceSheet(store: IDictionary[str, Decimal])
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


class GrossPremiumsWrittenIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Total premiums generated from all policies written by an insurance company within a given period of time. This item is usually only
                available for insurance industry.
    
    GrossPremiumsWrittenIncomeStatement(store: IDictionary[str, Decimal])
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


class GrossProfitAnnual5YrGrowth(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    This is the compound annual growth rate of the company's Gross Profit over the last 5 years.
    
    GrossProfitAnnual5YrGrowth(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    FiveYears: float

    OneYear: float

    ThreeYears: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class GrossProfitIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Total revenue less cost of revenue. The number is as reported by the company on the income statement; however, the number will
                be calculated if it is not reported. This field is null if the cost of revenue is not given.
                Gross Profit = Total Revenue - Cost of Revenue.
    
    GrossProfitIncomeStatement(store: IDictionary[str, Decimal])
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


class HedgingAssetsCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    A security transaction which expires within a 12 month period that reduces the risk on an existing investment position.
    
    HedgingAssetsCurrentBalanceSheet(store: IDictionary[str, Decimal])
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


class HeldToMaturitySecuritiesBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Debt securities that a firm has the ability and intent to hold until maturity.
    
    HeldToMaturitySecuritiesBalanceSheet(store: IDictionary[str, Decimal])
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


class ImpairmentLossesReversalsFinancialInstrumentsNetIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Impairment or reversal of impairment on financial instrument such as derivative. This is a contra account under Total Revenue in
                banks.
    
    ImpairmentLossesReversalsFinancialInstrumentsNetIncomeStatement(store: IDictionary[str, Decimal])
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
