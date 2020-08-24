from .__Fundamental_25 import *
import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Data.Fundamental.MultiPeriodField
import QuantConnect.Data.Fundamental
import QuantConnect.Data
import QuantConnect
import datetime


class FCFtoCFO(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Indicates the percentage of a company's operating cash flow is free to be invested in its business after capital expenditures.
    
    FCFtoCFO(store: IDictionary[str, Decimal])
    """
    def GetPeriodValue(self, period: str) -> float:
        pass

    def SetPeriodValue(self, period: str, value: float) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, store: System.Collections.Generic.IDictionary[str, float]) -> None:
        pass

    OneYear: float

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FederalFundsPurchasedAndSecuritiesSoldUnderAgreementToRepurchaseBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    This liability refers to the amount shown on the books that a bank with insufficient reserves borrows, at the federal funds rate, from
                another bank to meet its reserve requirements; and the amount of securities that an institution sells and agrees to repurchase at a
                specified date for a specified price, net of any reductions or offsets.
    
    FederalFundsPurchasedAndSecuritiesSoldUnderAgreementToRepurchaseBalanceSheet(store: IDictionary[str, Decimal])
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


class FederalFundsPurchasedBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The amount borrowed by a bank, at the federal funds rate, from another bank to meet its reserve requirements.  This item is
                typically available for the bank industry.
    
    FederalFundsPurchasedBalanceSheet(store: IDictionary[str, Decimal])
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


class FederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    This asset refers to very-short-term loans of funds to other banks and securities dealers.
    
    FederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellBalanceSheet(store: IDictionary[str, Decimal])
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


class FederalFundsSoldBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Federal funds transactions involve lending (federal funds sold) or borrowing (federal funds purchased) of immediately available
                reserve balances.  This item is typically available for the bank industry.
    
    FederalFundsSoldBalanceSheet(store: IDictionary[str, Decimal])
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


class FederalHomeLoanBankStockBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Federal Home Loan Bank stock represents an equity interest in a FHLB. It does not have a readily determinable fair value because
                its ownership is restricted and it lacks a market (liquidity).  This item is typically available for the bank industry.
    
    FederalHomeLoanBankStockBalanceSheet(store: IDictionary[str, Decimal])
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


class FeeRevenueAndOtherIncomeIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    The aggregate amount of fees, commissions, and other income.
    
    FeeRevenueAndOtherIncomeIncomeStatement(store: IDictionary[str, Decimal])
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


class FeesandCommissionExpenseIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Cost incurred by bank and insurance companies for fees and commission income.
    
    FeesandCommissionExpenseIncomeStatement(store: IDictionary[str, Decimal])
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


class FeesandCommissionIncomeIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Fees and commission income earned by bank and insurance companies on the rendering services.
    
    FeesandCommissionIncomeIncomeStatement(store: IDictionary[str, Decimal])
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


class FeesAndCommissionsIncomeStatement(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Total fees and commissions earned from providing services such as leasing of space or maintaining: (1) depositor accounts; (2)
                transfer agent; (3) fiduciary and trust; (4) brokerage and underwriting; (5) mortgage; (6) credit cards; (7) correspondent clearing;
                and (8) other such services and activities performed for others. This item is usually available for bank and insurance industries.
    
    FeesAndCommissionsIncomeStatement(store: IDictionary[str, Decimal])
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

    Store: typing.List[QuantConnect.Data.Fundamental.MultiPeriodField.PeriodField]


class FinanceLeaseReceivablesBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Accounts owed to the bank in relation to capital leases. Capital/ finance lease obligation are contractual obligations that arise from
                obtaining the use of property or equipment via a capital lease contract.
    
    FinanceLeaseReceivablesBalanceSheet(store: IDictionary[str, Decimal])
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


class FinanceLeaseReceivablesCurrentBalanceSheet(QuantConnect.Data.Fundamental.MultiPeriodField):
    """
    Accounts owed to the bank in relation to capital leases to be received within the next accounting PeriodAsByte. Capital/ finance lease
                obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
    
    FinanceLeaseReceivablesCurrentBalanceSheet(store: IDictionary[str, Decimal])
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
