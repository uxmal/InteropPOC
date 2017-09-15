#pragma once

class IExpVisitor;

class Exp
{
public: 
	virtual ~Exp() {}

	virtual void accept(IExpVisitor * visitor) = 0;
	virtual void write(std::wostream & stm) = 0;
	
};

class Id;
class Const;
class BinOp;

class IExpVisitor
{
public:
	virtual void visitId(Id * id) = 0;
	virtual void visitConst(Const * id) = 0;
	virtual void visitBin(BinOp * id) = 0;
};

class Id : public Exp
{
public:
	Id(DataTypeEnum dt, wchar_t * name, int n) : Name(name)
	{
	}

	virtual void accept(IExpVisitor * visitor) override {
		return visitor->visitId(this);
	}

	virtual void write(std::wostream & stm) override {
		stm << Name.c_str();
	}
public:
	std::wstring Name;
};

class Const : public Exp
{
public:
	Const(DataTypeEnum dt, int value) : Value(value)
	{
	}

	virtual void accept(IExpVisitor * visitor) override {
		return visitor->visitConst(this);
	}

	virtual void write(std::wostream & stm) override {
		stm << Value;
	}
public:
	int Value;
};

class BinOp : public Exp
{
public:
	BinOp(PrimitiveOp op, Exp * left, Exp * right) :
		Operator(op), Left(left), Right(right) {}

	virtual void accept(IExpVisitor * visitor) override {
		return visitor->visitBin(this);
	}

	virtual void write(std::wostream & stm) override;

public:
	PrimitiveOp Operator;
	Exp * Left;
	Exp * Right;
};
