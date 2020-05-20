#include <cmath>
#include <iostream>
#include "QCAlgorithm.hpp"

std::string encode_base_36(unsigned long long data) {
    std::vector<char> stack;
    while (data != 0) {
        auto value = data % 36;
        auto c = value < 10
            ? (char)(value + '0')
            : (char)(value - 10 + 'A');

        stack.push_back(c);
        data /= 36;
    }

    std::string out(stack.rbegin(), stack.rend());
    return out;
}

QCAlgorithm::QCAlgorithm() {}
QCAlgorithm::~QCAlgorithm() {}

void QCAlgorithm::Initialize(QCAlgorithmFunctions* self) {
    self->SetStartDate(2013, 10, 7);
    self->SetEndDate(2013, 10, 11);

    self->AddEquity("IBM", 0); // 0 == Resolution.Tick here. TODO

    std::cout << "Hello from C++" << std::endl;
}

void QCAlgorithm::OnData(QCAlgorithmFunctions* self, const BaseDataCollection* data) {
    auto tradebars = data->TradeBars();
    auto ticks = data->Ticks();
    //for (auto it = tradebars->begin(); it != tradebars->end(); ++it) {
    //    auto o = std::to_string(it->Open());
    //    auto h = std::to_string(it->High());
    //    auto l = std::to_string(it->Low());
    //    auto c = std::to_string(it->Close());
    //    auto v = std::to_string(it->Volume());
    //    
    //    std::cout << " O: " << o << " H :" << h << " L: " << l << " C: " << c << " V: " << v << std::endl;
    //}
    for (auto tick = ticks->begin(); tick != ticks->end(); ++tick) {
        auto q = std::to_string(tick->Quantity());
        auto p = std::to_string(tick->Value());
        auto s = tick->Symbol();
        auto time = tick->EndTime();

        std::cout << s->Value()->str() << " " << encode_base_36(s->ID()->_properties()) << " - Price: " << p << " Qty: " << q << std::endl;
    }
}
