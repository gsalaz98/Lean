#pragma once

#define PROTOBUF_USE_DLLS
#define BUILDING_DLL

#include "Decimal.hpp"
#include "Exports.hpp"
#include "QCAlgorithmFunctions.hpp"
#include "protoc/qc.pb.h"


class DLL_PUBLIC QCAlgorithm {
public:
    QCAlgorithm();
    ~QCAlgorithm();
    void Initialize(QCAlgorithmFunctions* self);
    void OnData(QCAlgorithmFunctions* self, google::protobuf::RepeatedPtrField<BaseData> data);
};