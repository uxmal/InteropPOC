#pragma once

// These interfaces and enumerations are genereated by CppHeaderGenerator.cs

enum PrimitiveOp {
    Not = 0,
    Cmp = 1,
    Neg = 2,
    AddrOf = 3,
    IAdd = 4,
    ISub = 5,
    IMul = 6,
    SMul = 7,
    UMul = 8,
    IDiv = 9,
    SDiv = 10,
    UDiv = 11,
    Shl = 12,
    Shr = 13,
    Sar = 14,
    And = 15,
    Or = 16,
    Xor = 17,
    FAdd = 18,
    FSub = 19,
    FMul = 20,
    FDiv = 21,
    Eq = 22,
    Ne = 23,
    Lt = 24,
    Le = 25,
    Ge = 26,
    Gt = 27,
    Ult = 28,
    Ule = 29,
    Uge = 30,
    Ugt = 31,
};

enum DataTypeEnum {
    Void = 0,
    Bool = 1,
    Byte = 2,
    Int8 = 3,
    Word16 = 4,
    Int16 = 5,
    UInt16 = 6,
    Ptr16 = 7,
    Word32 = 8,
    Int32 = 9,
    UInt32 = 10,
    Real32 = 11,
    Ptr32 = 12,
    FarPtr32 = 13,
    Word64 = 14,
    Int64 = 15,
    UInt64 = 16,
    Real64 = 17,
    Ptr64 = 18,
};


class IFactory : public IUnknown {
public:
    virtual HRESULT STDAPICALLTYPE Const(DataTypeEnum dt, int c) = 0;
    virtual HRESULT STDAPICALLTYPE Reg(DataTypeEnum dt, wchar_t *name, int number) = 0;
    virtual HRESULT STDAPICALLTYPE FlagGroup(wchar_t *name, int regNumber, int flagMask) = 0;
    virtual HRESULT STDAPICALLTYPE Bin(PrimitiveOp op) = 0;
    virtual HRESULT STDAPICALLTYPE Unary(PrimitiveOp op) = 0;
    virtual HRESULT STDAPICALLTYPE Mem(DataTypeEnum dt) = 0;
    virtual HRESULT STDAPICALLTYPE Apply() = 0;
    virtual HRESULT STDAPICALLTYPE Assign() = 0;
    virtual HRESULT STDAPICALLTYPE Call() = 0;
    virtual HRESULT STDAPICALLTYPE SideEffect() = 0;
    virtual HRESULT STDAPICALLTYPE If() = 0;
    virtual HRESULT STDAPICALLTYPE Goto() = 0;
};

