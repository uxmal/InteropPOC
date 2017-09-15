#pragma once

class Exp;

class Stmt
{
public:
	virtual ~Stmt() {}
};

class Assign : public Stmt
{
public:
	Assign(std::unique_ptr<Exp> && dst, std::unique_ptr<Exp> && src) : 
		Dst(std::move(dst)),
		Src(std::move(src))
	{}
public:
	std::unique_ptr<Exp> Dst;
	std::unique_ptr<Exp> Src;
};