#pragma once

class Stmt;

class NativeFactory : public IFactory
{
public:
	NativeFactory();
	~NativeFactory();

	virtual HRESULT STDAPICALLTYPE QueryInterface(REFIID iid, void ** ppvOut);
	virtual ULONG STDAPICALLTYPE AddRef();
	virtual ULONG STDAPICALLTYPE Release();

	virtual HRESULT  STDAPICALLTYPE Const(DataTypeEnum dt, int c);
	virtual HRESULT  STDAPICALLTYPE Reg(DataTypeEnum dt, wchar_t *name, int number);
	virtual HRESULT  STDAPICALLTYPE FlagGroup(wchar_t *name, int regNumber, int flagMask);
	virtual HRESULT  STDAPICALLTYPE Bin(PrimitiveOp op);
	virtual HRESULT  STDAPICALLTYPE Unary(PrimitiveOp op);
	virtual HRESULT  STDAPICALLTYPE Mem(DataTypeEnum dt);
	virtual HRESULT  STDAPICALLTYPE Apply();

	virtual HRESULT  STDAPICALLTYPE Assign();
	virtual HRESULT  STDAPICALLTYPE Call();
	virtual HRESULT  STDAPICALLTYPE SideEffect();
	virtual HRESULT  STDAPICALLTYPE If();
	virtual HRESULT  STDAPICALLTYPE Goto();
private:
	int cRef;

	std::vector<std::unique_ptr<Stmt>> stmts;
	std::stack<std::unique_ptr<Exp>> expStack;
};

