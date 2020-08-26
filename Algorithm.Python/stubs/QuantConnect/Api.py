from .__Api_1 import *
import QuantConnect.Api
import typing
import System
import QuantConnect.Packets
import QuantConnect.API
import QuantConnect
import Newtonsoft.Json.Linq
import Newtonsoft.Json
import datetime

# no functions
# classes

class BaseLiveAlgorithmSettings(System.object):
    """
    Base class for settings that must be configured per Brokerage to create new algorithms via the API.
    
    BaseLiveAlgorithmSettings(user: str, password: str, environment: BrokerageEnvironment, account: str)
    BaseLiveAlgorithmSettings(user: str, password: str)
    BaseLiveAlgorithmSettings(environment: BrokerageEnvironment, account: str)
    BaseLiveAlgorithmSettings(account: str)
    """
    @staticmethod # known case of __new__
    @typing.overload
    def __new__(self, user: str, password: str, environment: QuantConnect.BrokerageEnvironment, account: str) -> None:
        pass

    @typing.overload
    def __new__(self, user: str, password: str) -> None:
        pass

    @typing.overload
    def __new__(self, environment: QuantConnect.BrokerageEnvironment, account: str) -> None:
        pass

    @typing.overload
    def __new__(self, account: str) -> None:
        pass

    def __new__(self, *args) -> None:
        pass

    Account: str

    Environment: QuantConnect.BrokerageEnvironment

    Id: str

    Password: str

    User: str



class CreatedNode(QuantConnect.Api.RestResponse):
    """
    Rest api response wrapper for node/create, reads in the nodes information into a 
                node object
    
    CreatedNode()
    """
    Node: QuantConnect.API.Node



class DefaultLiveAlgorithmSettings(QuantConnect.API.BaseLiveAlgorithmSettings):
    """
    Default live algorithm settings
    
    DefaultLiveAlgorithmSettings(user: str, password: str, environment: BrokerageEnvironment, account: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, user: str, password: str, environment: QuantConnect.BrokerageEnvironment, account: str) -> None:
        pass


class Dividend(System.object):
    """
    Dividend returned from the api
    
    Dividend()
    """
    Date: datetime.datetime

    DividendPerShare: float

    ReferencePrice: float

    Symbol: QuantConnect.Symbol

    SymbolID: str



class DividendList(QuantConnect.Api.RestResponse):
    """
    Collection container for a list of dividend objects
    
    DividendList()
    """
    Dividends: typing.List[QuantConnect.API.Dividend]



class FXCMLiveAlgorithmSettings(QuantConnect.API.BaseLiveAlgorithmSettings):
    """
    Algorithm setting for trading with FXCM
    
    FXCMLiveAlgorithmSettings(user: str, password: str, environment: BrokerageEnvironment, account: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, user: str, password: str, environment: QuantConnect.BrokerageEnvironment, account: str) -> None:
        pass


class InteractiveBrokersLiveAlgorithmSettings(QuantConnect.API.BaseLiveAlgorithmSettings):
    """
    Live algorithm settings for trading with Interactive Brokers
    
    InteractiveBrokersLiveAlgorithmSettings(user: str, password: str, account: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, user: str, password: str, account: str) -> None:
        pass


class LiveAlgorithm(QuantConnect.Api.RestResponse):
    """
    Live algorithm instance result from the QuantConnect Rest API.
    
    LiveAlgorithm()
    """
    Brokerage: str
    DeployId: str
    Error: str
    Launched: datetime.datetime
    ProjectId: int
    Status: QuantConnect.AlgorithmStatus
    Stopped: typing.Optional[datetime.datetime]
    Subscription: str

class LiveAlgorithmApiSettingsWrapper(System.object):
    """
    Helper class to put BaseLiveAlgorithmSettings in proper format.
    
    LiveAlgorithmApiSettingsWrapper(projectId: int, compileId: str, serverType: str, settings: BaseLiveAlgorithmSettings, version: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, projectId: int, compileId: str, serverType: str, settings: QuantConnect.API.BaseLiveAlgorithmSettings, version: str) -> None:
        pass

    Brokerage: QuantConnect.API.BaseLiveAlgorithmSettings

    CompileId: str

    ProjectId: int

    ServerType: str

    VersionId: str



class LiveAlgorithmResults(QuantConnect.Api.RestResponse):
    """
    Details a live algorithm from the "live/read" Api endpoint
    
    LiveAlgorithmResults()
    """
    LiveResults: QuantConnect.API.LiveResultsData



class LiveAlgorithmResultsJsonConverter(Newtonsoft.Json.JsonConverter):
    """
    Custom JsonConverter for LiveResults data for live algorithms
    
    LiveAlgorithmResultsJsonConverter()
    """
    def CanConvert(self, objectType: type) -> bool:
        pass

    @staticmethod
    def CreateLiveResultsFromJObject(jObject: Newtonsoft.Json.Linq.JObject) -> QuantConnect.API.LiveAlgorithmResults:
        pass

    def ReadJson(self, reader: Newtonsoft.Json.JsonReader, objectType: type, existingValue: object, serializer: Newtonsoft.Json.JsonSerializer) -> object:
        pass

    def WriteJson(self, writer: Newtonsoft.Json.JsonWriter, value: object, serializer: Newtonsoft.Json.JsonSerializer) -> None:
        pass

    CanWrite: bool



class LiveList(QuantConnect.Api.RestResponse):
    """
    List of the live algorithms running which match the requested status
    
    LiveList()
    """
    Algorithms: typing.List[QuantConnect.API.LiveAlgorithm]

class LiveLog(QuantConnect.Api.RestResponse):
    """
    Logs from a live algorithm
    
    LiveLog()
    """
    Logs: typing.List[str]



class LiveResultsData(System.object):
    """
    Holds information about the state and operation of the live running algorithm
    
    LiveResultsData()
    """
    Resolution: QuantConnect.Resolution

    Results: QuantConnect.Packets.LiveResult

    Version: int



class Node(System.object):
    """
    Node class built for API endpoints nodes/read and nodes/create.
                Converts JSON properties from API response into data members for the class.
                Contains all relevant information on a Node to interact through API endpoints.
    
    Node()
    """
    Busy: bool

    CpuCount: int

    Description: str

    Id: str

    Name: str

    Prices: QuantConnect.API.NodePrices

    ProjectName: str

    Ram: float

    SKU: str

    Speed: float

    UsedBy: str



class NodeList(QuantConnect.Api.RestResponse):
    """
    Rest api response wrapper for node/read, contains sets of node lists for each
                target environment. List are composed of QuantConnect.API.Node objects.
    
    NodeList()
    """
    BacktestNodes: typing.List[QuantConnect.API.Node]
    LiveNodes: typing.List[QuantConnect.API.Node]
    ResearchNodes: typing.List[QuantConnect.API.Node]

class NodePrices(System.object):
    """
    Class for deserializing node prices from node object
    
    NodePrices()
    """
    Monthly: int

    Yearly: int



class NodeType(System.Enum, System.IComparable, System.IConvertible, System.IFormattable):
    """
    NodeTypes enum for all possible options of target environments
                Used in conjuction with SKU class as a NodeType is a required parameter for SKU
    
    enum NodeType, values: Backtest (0), Live (2), Research (1)
    """
    value__: int
    Backtest: 'NodeType'
    Live: 'NodeType'
    Research: 'NodeType'


class OandaLiveAlgorithmSettings(QuantConnect.API.BaseLiveAlgorithmSettings):
    """
    Live algorithm settings for trading with Oanda
    
    OandaLiveAlgorithmSettings(accessToken: str, environment: BrokerageEnvironment, account: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, accessToken: str, environment: QuantConnect.BrokerageEnvironment, account: str) -> None:
        pass

    AccessToken: str

    DateIssued: str



class Prices(System.object):
    """
    Prices rest response wrapper
    
    Prices()
    """
    Price: float

    Symbol: QuantConnect.Symbol

    SymbolID: str

    Updated: datetime.datetime


class PricesList(QuantConnect.Api.RestResponse):
    """
    Collection container for a list of prices objects
    
    PricesList()
    """
    Prices: typing.List[QuantConnect.API.Prices]

class SKU(System.object):
    """
    Class for generating a SKU for a node with a given configuration
                Every SKU is made up of 3 variables: 
                - Target environment (L for live, B for Backtest, R for Research)
                - CPU core count
                - Dedicated RAM (GB)
    
    SKU(cores: int, memory: int, target: NodeType)
    """
    def ToString(self) -> str:
        pass

    @staticmethod # known case of __new__
    def __new__(self, cores: int, memory: int, target: QuantConnect.API.NodeType) -> None:
        pass

    Cores: int
    Memory: int
    Target: QuantConnect.API.NodeType

class Split(System.object):
    """
    Split returned from the api
    
    Split()
    """
    Date: datetime.datetime

    ReferencePrice: float

    SplitFactor: float

    Symbol: QuantConnect.Symbol

    SymbolID: str



class SplitList(QuantConnect.Api.RestResponse):
    """
    Collection container for a list of split objects
    
    SplitList()
    """
    Splits: typing.List[QuantConnect.API.Split]



class TradierLiveAlgorithmSettings(QuantConnect.API.BaseLiveAlgorithmSettings):
    """
    Live algorithm settings for trading with Tradier
    
    TradierLiveAlgorithmSettings(accessToken: str, dateIssued: str, refreshToken: str, account: str)
    """
    @staticmethod # known case of __new__
    def __new__(self, accessToken: str, dateIssued: str, refreshToken: str, account: str) -> None:
        pass

    AccessToken: str

    DateIssued: str

    Lifetime: str

    RefreshToken: str

# no functions
# classes

class RestResponse(System.object):
    """
    Base API response class for the QuantConnect API.
    
    RestResponse()
    """
    Errors: typing.List[str]
    Success: bool

class AuthenticationResponse(QuantConnect.Api.RestResponse):
    """
    Verify if the credentials are OK.
    
    AuthenticationResponse()
    """

class Backtest(QuantConnect.Api.RestResponse):
    """
    Backtest response packet from the QuantConnect.com API.
    
    Backtest()
    """
    BacktestId: str
    Completed: bool
    Created: datetime.datetime
    Error: str
    Name: str
    Note: str
    Progress: float
    Result: QuantConnect.Packets.BacktestResult
    StackTrace: str
