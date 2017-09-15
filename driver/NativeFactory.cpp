#include <memory>
#include <stack>
#include <vector>
#include <ostream>
#include <sstream>
#include "types.h"
#include "RekoInterfaces.h"
#include "exp.h"
#include "stmt.h"
#include "NativeFactory.h"

// {E40FFD0D-3019-4ADF-AC48-800F3ACFA360}
static const GUID IID_IFactory =
{ 0xE40FFD0D, 0x3019, 0x4ADF,{ 0xAC, 0x48, 0x80, 0x0F, 0x3A, 0xCF, 0xA3, 0x60 } };


NativeFactory::NativeFactory()
{
	OutputDebugStringA("Native factory created\r\n");
	cRef = 0;
}


NativeFactory::~NativeFactory()
{
	OutputDebugStringA("Native factory destroyed\r\n");
}

HRESULT NativeFactory::QueryInterface(REFIID iid, void ** ppvOut)
{
	OutputDebugStringA("NativeFactory::QI\r\n");

	if (iid == IID_IUnknown || iid == IID_IFactory)
	{
		AddRef();

		*ppvOut = this;
		return S_OK;
	}
	return E_NOINTERFACE;
}

ULONG STDAPICALLTYPE NativeFactory::AddRef()
{
	return ++this->cRef;
}

ULONG STDAPICALLTYPE NativeFactory::Release()
{
	if (--this->cRef < 0)
	{
		delete this;
		return 0;
	}
	return this->cRef;
}

HRESULT STDAPICALLTYPE NativeFactory::Const(DataTypeEnum dt, int value)
{
	auto con = new ::Const(dt, value);
	this->exprs.push_back(std::unique_ptr<Exp>(con));
	this->expStack.push(con);
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::Reg(DataTypeEnum dt, wchar_t *name, int number)
{
	auto reg = new Id(dt, name, number);
	this->exprs.push_back(std::unique_ptr<Exp>(reg));
	this->expStack.push(reg);
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::FlagGroup(wchar_t *name, int regNumber, int flagMask)
{
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::Bin(PrimitiveOp op)
{
	auto right = this->expStack.top();
	expStack.pop();
	auto left = this->expStack.top();
	expStack.pop();
	auto bin = new BinOp(op, left, right);
	this->exprs.push_back(std::unique_ptr<Exp>(bin));
	this->expStack.push(bin);

	return S_OK;

}
HRESULT STDAPICALLTYPE NativeFactory::Unary(PrimitiveOp op)
{
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::Mem(DataTypeEnum dt)
{
	return S_OK;

}

HRESULT STDAPICALLTYPE NativeFactory::Apply()
{
	return S_OK;

}
HRESULT STDAPICALLTYPE NativeFactory::Assign()
{
	auto dst = this->expStack.top();
	expStack.pop();
	auto src = this->expStack.top();
	expStack.pop();

	this->stmts.push_back(std::make_unique<::Assign>(dst, src));

	for (const auto & s : this->stmts)
	{
		std::wostringstream stm;
		s->write(stm);

		::OutputDebugStringW(stm.str().c_str());
		::OutputDebugStringW(L"\r\n");
	}
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::Call()
{
	return S_OK;
}

HRESULT STDAPICALLTYPE NativeFactory::SideEffect()
{
	return S_OK;
}
HRESULT STDAPICALLTYPE NativeFactory::If()
{
	return S_OK;

}
HRESULT STDAPICALLTYPE NativeFactory::Goto()
{
	return S_OK;
}

