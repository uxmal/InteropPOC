// plugin.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "reko.h"
#include "MyPlugin.h"

extern "C"
{
	
#if _WINDOWS
	__declspec(dllexport) IRekoPlugin * __cdecl
#else
	extern void IRekoPlugin *
#endif
	LoadPlugin(IRekoProgram * program)
	{
		return new MyPlugin(program);
	}
}