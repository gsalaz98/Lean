#pragma once
#include "QCAlgorithm.hpp"


extern "C" DLL_PUBLIC QCAlgorithm* init();
extern "C" DLL_PUBLIC void Initialize(QCAlgorithm* algorithm, QCAlgorithmFunctions* self);
extern "C" DLL_PUBLIC void OnData(QCAlgorithm* algorithm, QCAlgorithmFunctions* self, void* message, int length);
extern "C" DLL_PUBLIC void finalize(QCAlgorithm* algorithm);