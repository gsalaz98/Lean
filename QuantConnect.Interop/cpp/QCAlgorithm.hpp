#pragma once

#define PROTOBUF_USE_DLLS
#define BUILDING_DLL

#include "Exports.hpp"
#include "QCAlgorithmFunctions.hpp"
#include "fbc/qc_generated.h"


class DLL_PUBLIC QCAlgorithm {
public:
    QCAlgorithm();
    ~QCAlgorithm();
    void Initialize(QCAlgorithmFunctions* self);
    void OnData(QCAlgorithmFunctions* self, const BaseDataCollection* data);
};