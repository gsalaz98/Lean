import typing
import System.IO
import System.Collections.Generic
import System
import QuantConnect.Indicators
import QuantConnect.Data.Market
import QuantConnect.Data
import QuantConnect
import Python.Runtime
import datetime



class TripleExponentialMovingAverage(QuantConnect.Indicators.IndicatorBase[IndicatorDataPoint], System.IComparable, System.IComparable[IIndicator[IndicatorDataPoint]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IndicatorDataPoint], QuantConnect.Indicators.IIndicator):
    """
    This indicator computes the Triple Exponential Moving Average (TEMA). 
                The Triple Exponential Moving Average is calculated with the following formula:
                EMA1 = EMA(t,period)
                EMA2 = EMA(EMA(t,period),period)
                EMA3 = EMA(EMA(EMA(t,period),period),period)
                TEMA = 3 * EMA1 - 3 * EMA2 + EMA3
    
    TripleExponentialMovingAverage(name: str, period: int)
    TripleExponentialMovingAverage(period: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class Trix(QuantConnect.Indicators.Indicator, System.IComparable, System.IComparable[IIndicator[IndicatorDataPoint]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IndicatorDataPoint], QuantConnect.Indicators.IIndicator):
    """
    This indicator computes the TRIX (1-period ROC of a Triple EMA)
                The TRIX is calculated as explained here:
                http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:trix
    
    Trix(name: str, period: int)
    Trix(period: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class TrueRange(QuantConnect.Indicators.BarIndicator, System.IComparable, System.IComparable[IIndicator[IBaseDataBar]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IBaseDataBar], QuantConnect.Indicators.IIndicator):
    """
    This indicator computes the True Range (TR).
                The True Range is the greatest of the following values:
                value1 = distance from today's high to today's low.
                value2 = distance from yesterday's close to today's high.
                value3 = distance from yesterday's close to today's low.
    
    TrueRange()
    TrueRange(name: str)
    """
    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self) -> None:
        pass

    @typing.overload
    def __new__(self, name: str) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class UltimateOscillator(QuantConnect.Indicators.BarIndicator, System.IComparable, System.IComparable[IIndicator[IBaseDataBar]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IBaseDataBar], QuantConnect.Indicators.IIndicator):
    """
    This indicator computes the Ultimate Oscillator (ULTOSC)
                The Ultimate Oscillator is calculated as explained here:
                http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:ultimate_oscillator
    
    UltimateOscillator(period1: int, period2: int, period3: int)
    UltimateOscillator(name: str, period1: int, period2: int, period3: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, period1: int, period2: int, period3: int) -> None:
        pass

    @typing.overload
    def __new__(self, name: str, period1: int, period2: int, period3: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class VolumeWeightedAveragePriceIndicator(QuantConnect.Indicators.TradeBarIndicator, System.IComparable, System.IComparable[IIndicator[TradeBar]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[TradeBar], QuantConnect.Indicators.IIndicator):
    """
    Volume Weighted Average Price (VWAP) Indicator:
                It is calculated by adding up the dollars traded for every transaction (price multiplied
                by number of shares traded) and then dividing by the total shares traded for the day.
    
    VolumeWeightedAveragePriceIndicator(period: int)
    VolumeWeightedAveragePriceIndicator(name: str, period: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class WilderMovingAverage(QuantConnect.Indicators.Indicator, System.IComparable, System.IComparable[IIndicator[IndicatorDataPoint]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IndicatorDataPoint], QuantConnect.Indicators.IIndicator):
    """
    Represents the moving average indicator defined by Welles Wilder in his book:
                New Concepts in Technical Trading Systems.
    
    WilderMovingAverage(name: str, period: int)
    WilderMovingAverage(period: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    WarmUpPeriod: int



class WilliamsPercentR(QuantConnect.Indicators.BarIndicator, System.IComparable, System.IComparable[IIndicator[IBaseDataBar]], QuantConnect.Indicators.IIndicatorWarmUpPeriodProvider, QuantConnect.Indicators.IIndicator[IBaseDataBar], QuantConnect.Indicators.IIndicator):
    """
    Williams %R, or just %R, is the current closing price in relation to the high and low of
                the past N days (for a given N). The value of this indicator fluctuates between -100 and 0.
                The symbol is said to be oversold when the oscillator is below -80%,
                and overbought when the oscillator is above -20%.
    
    WilliamsPercentR(period: int)
    WilliamsPercentR(name: str, period: int)
    """
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool

    Maximum: QuantConnect.Indicators.Maximum

    Minimum: QuantConnect.Indicators.Minimum

    WarmUpPeriod: int



class WindowIdentity(QuantConnect.Indicators.WindowIndicator[IndicatorDataPoint], System.IComparable, System.IComparable[IIndicator[IndicatorDataPoint]], QuantConnect.Indicators.IIndicator[IndicatorDataPoint], QuantConnect.Indicators.IIndicator):
    """
    Represents an indicator that is a ready after ingesting enough samples (# samples > period) 
                and always returns the same value as it is given.
    
    WindowIdentity(name: str, period: int)
    WindowIdentity(period: int)
    """
    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, name: str, period: int) -> None:
        pass

    @typing.overload
    def __new__(self, period: int) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    IsReady: bool



class WindowIndicator(QuantConnect.Indicators.IndicatorBase[T], System.IComparable, System.IComparable[IIndicator[T]], QuantConnect.Indicators.IIndicator[T], QuantConnect.Indicators.IIndicator):
    # no doc
    def Reset(self) -> None:
        pass

    @staticmethod # known case of __new__
    def __new__(self, *args): #cannot find CLR constructor
        pass

    IsReady: bool

    Period: int
