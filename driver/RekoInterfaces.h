#pragma once

// These interfaces and enumerations are genereated by CppHeaderGenerator.cs

enum PrimitiveOp {
	IAdd = 0,
	ISub = 1,
	IMul = 2,
	SMul = 3,
	UMul = 4,
	IDiv = 5,
	SDiv = 6,
	UDiv = 7,
	And = 8,
	Or = 9,
	Xor = 10,
	FAdd = 11,
	FSub = 12,
	FMul = 13,
	FDiv = 14,
	Eq = 15,
	Ne = 16,
	Lt = 17,
	Le = 18,
	Ge = 19,
	Gt = 20,
	Ult = 21,
	Ule = 22,
	Uge = 23,
	Ugt = 24,
};

[uuid(e40ffd0d-3019-4adf-ac48-800f3acfa360)]
class IFactory : public IUnknown {
public:
	virtual void __stdcall Const(int c) = 0;
	virtual void __stdcall Reg(LPWSTR name, int number) = 0;
	virtual void __stdcall FlagGroup(LPWSTR name, int regNumber, int flagMask) = 0;
	virtual void __stdcall Bin(PrimitiveOp op) = 0;
	virtual void __stdcall Unary(PrimitiveOp op) = 0;
	virtual void __stdcall Apply() = 0;
	virtual void __stdcall Assign() = 0;
	virtual void __stdcall Call() = 0;
	virtual void __stdcall SideEffect() = 0;
	virtual void __stdcall If() = 0;
	virtual void __stdcall Goto() = 0;
};

