#include <memory>
#include <stack>
#include <vector>
#include <ostream>
#include "types.h"
#include "RekoInterfaces.h"
#include "exp.h"
#include "stmt.h"
#include "NativeFactory.h"

void BinOp::write(std::wostream & stm)
{
	stm << '(';
	this->Left->write(stm);
	wchar_t * s;
	switch (this->Operator)
	{
	case PrimitiveOp::IAdd: s = L" + "; break;
	case PrimitiveOp::ISub: s = L" - "; break;
	default: s = L"?unknown?";
	}
	stm << s;
	this->Right->write(stm);
	stm << ')';
}
