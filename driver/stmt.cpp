#include <memory>
#include <stack>
#include <vector>
#include <ostream>
#include "types.h"
#include "RekoInterfaces.h"
#include "exp.h"
#include "stmt.h"
#include "NativeFactory.h"

void Assign::write(std::wostream & stm)
{
	this->Dst->write(stm);
	stm << L" = ";
	this->Src->write(stm);
}
