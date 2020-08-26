from .__Fundamental_22 import *
import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Data.Fundamental.MultiPeriodField
import QuantConnect.Data.Fundamental
import QuantConnect.Data
import QuantConnect
import datetime


class DPSGrowth(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The growth in the company's dividends per share (DPS) on a percentage basis. Morningstar calculates the annualized growth
                percentage based on the underlying DPS from its dividend database.  Morningstar collects its DPS from company filings and
                reports, as well as from third party sources.
    
    DPSGrowth(store: IDictionary[str, Decimal])
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

    ThreeMonths: float

    ThreeYears: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class DueFromRelatedPartiesBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    For an unclassified balance sheet, carrying amount as of the balance sheet date of obligations due all related parties.
    
    DueFromRelatedPartiesBalanceSheet(store: IDictionary[str, Decimal])
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


class DuefromRelatedPartiesCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Amounts owed to the company from a non-arm's length entity, due within the company's current operating cycle.
    
    DuefromRelatedPartiesCurrentBalanceSheet(store: IDictionary[str, Decimal])
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


class DuefromRelatedPartiesNonCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Amounts owed to the company from a non-arm's length entity, due after the company's current operating cycle.
    
    DuefromRelatedPartiesNonCurrentBalanceSheet(store: IDictionary[str, Decimal])
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


class DuetoRelatedPartiesBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Amounts owed by the company to a non-arm's length entity.
    
    DuetoRelatedPartiesBalanceSheet(store: IDictionary[str, Decimal])
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


class DuetoRelatedPartiesCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Amounts owed by the company to a non-arm's length entity that has to be repaid within the company's current operating cycle.
    
    DuetoRelatedPartiesCurrentBalanceSheet(store: IDictionary[str, Decimal])
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


class DuetoRelatedPartiesNonCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Amounts owed by the company to a non-arm's length entity that has to be repaid after the company's current operating cycle.
    
    DuetoRelatedPartiesNonCurrentBalanceSheet(store: IDictionary[str, Decimal])
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


class EarningRatios(System.object):
    """
    Definition of the EarningRatios class
    
    EarningRatios()
    """
    def UpdateValues(self, update: QuantConnect.Data.Fundamental.EarningRatios) -> None:
        pass

    BookValuePerShareGrowth: QuantConnect.Data.Fundamental.BookValuePerShareGrowth

    DilutedContEPSGrowth: QuantConnect.Data.Fundamental.DilutedContEPSGrowth

    DilutedEPSGrowth: QuantConnect.Data.Fundamental.DilutedEPSGrowth

    DPSGrowth: QuantConnect.Data.Fundamental.DPSGrowth

    EquityPerShareGrowth: QuantConnect.Data.Fundamental.EquityPerShareGrowth

    FCFPerShareGrowth: QuantConnect.Data.Fundamental.FCFPerShareGrowth

    NormalizedBasicEPSGrowth: QuantConnect.Data.Fundamental.NormalizedBasicEPSGrowth

    NormalizedDilutedEPSGrowth: QuantConnect.Data.Fundamental.NormalizedDilutedEPSGrowth

    RegressionGrowthofDividends5Years: QuantConnect.Data.Fundamental.RegressionGrowthofDividends5Years



class EarningReports(System.object):
    """
    Definition of the EarningReports class
    
    EarningReports()
    """
    def UpdateValues(self, update: QuantConnect.Data.Fundamental.EarningReports) -> None:
        pass

    AccessionNumber: str

    BasicAccountingChange: QuantConnect.Data.Fundamental.BasicAccountingChange

    BasicAverageShares: QuantConnect.Data.Fundamental.BasicAverageShares

    BasicContinuousOperations: QuantConnect.Data.Fundamental.BasicContinuousOperations

    BasicDiscontinuousOperations: QuantConnect.Data.Fundamental.BasicDiscontinuousOperations

    BasicEPS: QuantConnect.Data.Fundamental.BasicEPS

    BasicEPSOtherGainsLosses: QuantConnect.Data.Fundamental.BasicEPSOtherGainsLosses

    BasicExtraordinary: QuantConnect.Data.Fundamental.BasicExtraordinary

    ContinuingAndDiscontinuedBasicEPS: QuantConnect.Data.Fundamental.ContinuingAndDiscontinuedBasicEPS

    ContinuingAndDiscontinuedDilutedEPS: QuantConnect.Data.Fundamental.ContinuingAndDiscontinuedDilutedEPS

    DilutedAccountingChange: QuantConnect.Data.Fundamental.DilutedAccountingChange

    DilutedAverageShares: QuantConnect.Data.Fundamental.DilutedAverageShares

    DilutedContinuousOperations: QuantConnect.Data.Fundamental.DilutedContinuousOperations

    DilutedDiscontinuousOperations: QuantConnect.Data.Fundamental.DilutedDiscontinuousOperations

    DilutedEPS: QuantConnect.Data.Fundamental.DilutedEPS

    DilutedEPSOtherGainsLosses: QuantConnect.Data.Fundamental.DilutedEPSOtherGainsLosses

    DilutedExtraordinary: QuantConnect.Data.Fundamental.DilutedExtraordinary

    DividendCoverageRatio: QuantConnect.Data.Fundamental.DividendCoverageRatio

    DividendPerShare: QuantConnect.Data.Fundamental.DividendPerShare

    FileDate: datetime.datetime

    FormType: str

    NormalizedBasicEPS: QuantConnect.Data.Fundamental.NormalizedBasicEPS

    NormalizedDilutedEPS: QuantConnect.Data.Fundamental.NormalizedDilutedEPS

    PeriodEndingDate: datetime.datetime

    PeriodType: str

    ReportedNormalizedBasicEPS: QuantConnect.Data.Fundamental.ReportedNormalizedBasicEPS

    ReportedNormalizedDilutedEPS: QuantConnect.Data.Fundamental.ReportedNormalizedDilutedEPS

    TaxLossCarryforwardBasicEPS: QuantConnect.Data.Fundamental.TaxLossCarryforwardBasicEPS

    TaxLossCarryforwardDilutedEPS: QuantConnect.Data.Fundamental.TaxLossCarryforwardDilutedEPS

    TotalDividendPerShare: QuantConnect.Data.Fundamental.TotalDividendPerShare



class EarningsFromEquityInterestIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The earnings from equity interest can be a result of any of the following: Income from earnings distribution of the business, either
                as dividends paid to corporate shareholders or as drawings in a partnership; Capital gain realized upon sale of the business; Capital
                gain realized from selling his or her interest to other partners. This item is usually not available for bank and insurance industries.
    
    EarningsFromEquityInterestIncomeStatement(store: IDictionary[str, Decimal])
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


class EarningsfromEquityInterestNetOfTaxIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Income from other equity interest reported after Provision of Tax. This applies to all industries.
    
    EarningsfromEquityInterestNetOfTaxIncomeStatement(store: IDictionary[str, Decimal])
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
