// driver.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

#include "RekoInterfaces.h"

extern "C"
{
	void __declspec(dllexport) __cdecl Build(IUnknown * arg)
	{
		IFactory * f = nullptr;
		arg->QueryInterface<IFactory>(&f);
		
		f->Reg(L"eax", 0);
		f->Const(3);
		f->Bin(PrimitiveOp::IAdd);
		f->Reg(L"ecx", 1);
		f->Assign();

		f->Release();
	}
}
