// driver.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

#include "RekoInterfaces.h"

extern "C"
{
	void __declspec(dllexport) __cdecl Build(
		IFactory * f,
		unsigned long long uAddr, 
		unsigned const char * bytes,
		int offset)
	{
		int word = *reinterpret_cast<const int *>(bytes + offset);

		f->Reg(DataTypeEnum::Word32, L"eax", 0);
		f->Const(DataTypeEnum::Word32, word);
		f->Bin(PrimitiveOp::IAdd);
		f->Reg(DataTypeEnum::Word32, L"ecx", 1);
		f->Assign();
	}
}
