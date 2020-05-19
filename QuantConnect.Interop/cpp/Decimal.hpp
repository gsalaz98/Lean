#pragma once


struct DecimalType {
    unsigned long long int lo;
    unsigned long int hi;
    unsigned long int sign_scale;
};

extern "C" double to_f64(unsigned long long lo, unsigned long hi, unsigned long signScale);
extern "C" DecimalType to_decimal(double value);