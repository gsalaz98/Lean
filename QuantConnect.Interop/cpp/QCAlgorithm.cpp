#include <cmath>
#include <iostream>
#include "QCAlgorithm.hpp"

double to_double(bcl::Decimal rhs) {
    return to_f64(
        rhs.lo(),
        rhs.hi(),
        rhs.signscale());
}

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

void QCAlgorithm::OnData(QCAlgorithmFunctions* self, google::protobuf::RepeatedPtrField<BaseData> data) {
    for (auto it = data.begin(); it != data.end(); ++it) {
        if (it->has_tradebar()) {
            auto tb = it->tradebar();
            auto o = std::to_string(to_double(tb.open()));
            auto h = std::to_string(to_double(tb.high()));
            auto l = std::to_string(to_double(tb.low()));
            auto c = std::to_string(to_double(tb.close()));
            auto v = std::to_string(to_double(tb.volume()));

            //std::cout << " O: " << o << " H :" << h << " L: " << l << " C: " << c << " V: " << v << std::endl;
        }
        if (it->has_tick()) {
            auto t = it->tick();
            auto q = std::to_string(to_double(t.quantity()));
            auto p = std::to_string(to_double(it->value()));
            auto s = it->symbol().id();
            auto time = it->endtime();

            std::cout << s._symbol() << " " << encode_base_36(s._properties()) << " - Price: " << p << " Qty: " << q << std::endl;
        }
    }
}
