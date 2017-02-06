// driver.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

#include "RekoInterfaces.h"

extern "C"
{
	void __declspec(dllexport) __cdecl Build(IFactory * f)
	{
		f->Reg(DataTypeEnum::Word32, L"eax", 0);
		f->Const(DataTypeEnum::Word32, 3);
		f->Bin(PrimitiveOp::IAdd);
		f->Reg(DataTypeEnum::Word32, L"ecx", 1);
		f->Assign();
	}
}
