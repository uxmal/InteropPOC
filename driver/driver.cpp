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
		IFactory * f = nullptr;
		arg->QueryInterface<IFactory>(&f);
		
		f->Reg(0);
		f->Const(3);
		f->IAdd();
		f->Reg(1);
		f->Assign();

		f->Release();
	}

	int __declspec(dllexport) __cdecl Frob(int n) {
		return n * 2;
	}
}
