#pragma once

class Exp;

class Stmt
{
public:
	virtual ~Stmt() {}
	virtual void write(std::wostream & stm) = 0;
};

class Assign : public Stmt
{
public:
	Assign(Exp * dst, Exp * src) : 
		Dst(std::move(dst)),
		Src(std::move(src))
	{}
	virtual void write(std::wostream & stm) override;
public:
	Exp * Dst;
	Exp * Src;
};