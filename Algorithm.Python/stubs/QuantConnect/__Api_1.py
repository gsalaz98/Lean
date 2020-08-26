import QuantConnect.Api
import typing
import System
import QuantConnect.Packets
import QuantConnect.API
import QuantConnect
import Newtonsoft.Json.Linq
import Newtonsoft.Json
import datetime

class BacktestList(QuantConnect.Api.RestResponse):
    """
    Collection container for a list of backtests for a project
    
    BacktestList()
    """
    Backtests: typing.List[QuantConnect.Api.Backtest]

class BacktestReport(QuantConnect.Api.RestResponse):
    """
    Backtest Report Response wrapper
    
    BacktestReport()
    """
    Report: str



class Compile(QuantConnect.Api.RestResponse):
    """
    Response from the compiler on a build event
    
    Compile()
    """
    CompileId: str
    Logs: typing.List[str]
    State: QuantConnect.Api.CompileState

class CompileState(System.Enum, System.IComparable, System.IConvertible, System.IFormattable):
    """
    State of the compilation request
    
    enum CompileState, values: BuildError (2), BuildSuccess (1), InQueue (0)
    """
    value__: int
    BuildError: 'CompileState'
    BuildSuccess: 'CompileState'
    InQueue: 'CompileState'


class Link(QuantConnect.Api.RestResponse):
    """
    Response from reading purchased data
    
    Link()
    """
    DataLink: str



class Project(QuantConnect.Api.RestResponse):
    """
    Response from reading a project by id.
    
    Project()
    """
    Created: datetime.datetime
    Language: QuantConnect.Language
    Modified: datetime.datetime
    Name: str
    ProjectId: int

class ProjectFile(System.object):
    """
    File for a project
    
    ProjectFile()
    """
    DateModified: datetime.datetime

    Code: str
    Name: str


class ProjectFilesResponse(QuantConnect.Api.RestResponse):
    """
    Response received when reading all files of a project
    
    ProjectFilesResponse()
    """
    Files: typing.List[QuantConnect.Api.ProjectFile]

class ProjectResponse(QuantConnect.Api.RestResponse):
    """
    Project list response
    
    ProjectResponse()
    """
    Projects: typing.List[QuantConnect.Api.Project]
