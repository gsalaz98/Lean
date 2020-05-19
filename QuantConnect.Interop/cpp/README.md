If compiling on windows, compile with:

* `%INCLUDEPATH%` is the protobuf include path
* `%LIBPATH%` is the protobuf lib path

Ensure that you're linking the libprotobuf library and including the protoc *.cc files in the compile command.

`clang-cl /EHsc -I%INCLUDEPATH% QCAlgorithm.cpp QCInterop.cpp protoc/*.cc %LIBPATH/libprotobuf.lib /LD`

Example build on my OS (with a lot of optimizations enabled):

```
cl /EHsc -I"C:/Users/gsala/bin/installed/x64-windows/include" *.cpp protoc/*.cc C:/Users/gsala/bin/installed/x64-windows/lib/libprotobuf.lib decimal.dll.lib /LD /O2 /GL
```

Once the binaries have built, copy the following DLLs to the 
Lean Launcher project's Debug or Release folder (under bin):

* Rename QCAlgorithm.dll to QCInteropAlgorithm.dll and copy to the Launcher Debug or Release folder
* decimal.dll - (built from the `decimal` Rust project. Used to convert C# decimal instances to doubles)
* libproto.dll - (built via vcpkg and copied from the vcpkg install directory)

Those DLLs are required to run the interop algorithm.

Once that's been done, edit the `config.json` file in the Lean Launcher project and change the following properties:
* `algorithm-type-name` - `InteropAlgorithm`
* `algorithm-location` - `QuantConnect.Interop.dll`

The InteropAlgorithm expects to find the DLL you've provided with the following naming scheme for other platforms:

* Mac OSX - DLL will be searched for as `libQCInteropAlgorithm.dylib`
* Linux - DLL will be search for as `libQCInteropAlgorithm.so`

If you've tried running the algorithm and it didn't find the QuantConnect.InteropAlgorithm 
algorithm, try copying the `QuantConnect.Interop.dll` explicitly from the interop project's Debug or Release folder.