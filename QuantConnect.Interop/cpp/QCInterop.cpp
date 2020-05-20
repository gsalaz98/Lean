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
    //auto base_data = GetBaseDataCollection(message);
    //algorithm->OnData(self, base_data);
}

extern "C" DLL_PUBLIC void finalize(QCAlgorithm* algorithm) {
    delete algorithm;
}