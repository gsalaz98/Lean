typedef void (*m_SetDate)(int, int, int);
typedef void (*m_AddData)(const char*, int);
typedef void (*m_History)(const char*, int, int);

extern "C" struct QCAlgorithmFunctions {
    m_SetDate SetStartDate;
    m_SetDate SetEndDate;
    m_AddData AddEquity;
    m_History History;
};