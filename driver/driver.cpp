// driver.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

[uuid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360")]
class IFactory : public IUnknown
{
public:
	virtual int __stdcall Const(int c) = 0;
	virtual int __stdcall Reg(int reg) = 0;
	virtual int __stdcall IAdd() = 0;
	virtual int __stdcall Assign() = 0;
};

extern "C"
{

	void __declspec(dllexport) __cdecl Build(IUnknown * arg)
	{
		IFactory * factory = nullptr;
		arg->QueryInterface<IFactory>(&factory);
		
		factory->Reg(0);
		factory->Const(3);
		factory->IAdd();
		factory->Reg(1);
		factory->Assign();
		factory->Release();
	}

	int __declspec(dllexport) __cdecl Frob(int n) {
		return n * 2;
		::OutputDebugStringA("Hello Build\r\n");
		IUnknown * arg = reinterpret_cast<IUnknown *>(n);
		Build(arg);
		return 0;
	}
}
