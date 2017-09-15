#include <memory>
#include <stack>
#include <vector>
#include "types.h"
#include "exp.h"
#include "stmt.h"
#include "RekoInterfaces.h"
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

HRESULT STDAPICALLTYPE NativeFactory::Const(DataTypeEnum dt, int c)
{
	return S_OK;
}
HRESULT STDAPICALLTYPE NativeFactory::Reg(DataTypeEnum dt, wchar_t *name, int number)
{
	return S_OK;

}
HRESULT STDAPICALLTYPE NativeFactory::FlagGroup(wchar_t *name, int regNumber, int flagMask)
{
	return S_OK;

}
HRESULT STDAPICALLTYPE NativeFactory::Bin(PrimitiveOp op)
{
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

