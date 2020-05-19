#include <iostream>
#define BUILDING_DLL
#include "Exports.hpp"
#include "QCInterop.hpp"


extern "C" DLL_PUBLIC QCAlgorithm* init() {
    // Leak memory on purpose, but we'll have the pointer passed back to us
    // from C#. We don't lose the handle, and it will remain alive until
    // the algorithm terminates.
    return new QCAlgorithm();
}

extern "C" DLL_PUBLIC void Initialize(QCAlgorithm* algorithm, QCAlgorithmFunctions* self) {
    algorithm->Initialize(self);
}

extern "C" DLL_PUBLIC void OnData(QCAlgorithm* algorithm, QCAlgorithmFunctions* self, void* message, int length) {
    List_BaseData data;
    {
        auto* input_stream = new google::protobuf::io::ArrayInputStream(message, length);
        data.ParseFromZeroCopyStream(input_stream);
        delete input_stream;
    }

    auto items = data.items();
    algorithm->OnData(self, items);
}

extern "C" DLL_PUBLIC void finalize(QCAlgorithm* algorithm) {
    delete algorithm;
}